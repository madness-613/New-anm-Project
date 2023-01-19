using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.RemoteConfig;
using UnityEngine.SceneManagement;

public class player_controller : MonoBehaviour
{
[SerializeField] private menu_controler menus;
[SerializeField] private player_sprite player_sprite;
[SerializeField] private Transform player_Transform;
[SerializeField] private Rigidbody2D player_Rigidbody;
[SerializeField] private Collider2D player_Hitbox;
[SerializeField] private GameObject HP_UI;
[SerializeField] private GameObject lives_UI;
[SerializeField] private Transform respawn_point;
[SerializeField] private Transform dropPoint;
public int level;
public int lives = 1;
public float move_spead = 10f;
public float jump_velocity = 10f;
public float Max_Jumps = 2;
public float HP = 100;
public float max_hp = 100;
public float defence = 0;
public float attack = 0;
public float Throwspeed;
private float damegeamount;
[HideInInspector]public float NumberJumps = 0f;
public bool LeftOrRight;
public bool fly;
private bool respawn;
private bool poisoned = false;
[HideInInspector]public bool isgrounded;
[HideInInspector]public bool cant_move;
private Text HP_UI_text;
private Text lives_UI_text;

void Awake () {
//Sets this to not be destroyed when reloading scene
DontDestroyOnLoad(gameObject);
       // Add a listener to apply settings when successfully retrieved:
       ConfigManager.FetchCompleted += ApplyRemoteSettings;
   }

   void ApplyRemoteSettings (ConfigResponse configResponse) {
      // Conditionally update settings, depending on the response's origin:
      switch (configResponse.requestOrigin) {
          case ConfigOrigin.Default:
              Debug.Log ("No settings loaded this session; using default values.");
              break;
          case ConfigOrigin.Cached:
              Debug.Log ("No settings loaded this session; using cached values from a previous session.");
              break;
          case ConfigOrigin.Remote:
              Debug.Log ("New settings loaded this session; update values accordingly.");
              move_spead = ConfigManager.appConfig.GetInt ("movespead");
              jump_velocity = ConfigManager.appConfig.GetInt ("jumpvelocity");
              Max_Jumps = ConfigManager.appConfig.GetFloat ("MaxJumps");
              move_spead = ConfigManager.appConfig.GetFloat ("movespead");
              break;
      }
  }

    // Start is called before the first frame update
    void Start()
    {
      respawn_point.parent = null;
      HP_UI_text = HP_UI.GetComponent<Text>();
      lives_UI_text = lives_UI.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
      HP_UI_text.text="HP : " + HP + "/" + max_hp;
      lives_UI_text.text="lives : " + lives;
      if (HP <= 0) {
        cant_move = true;
        if (lives > 0) {
          respawn = true;
        }else {
          respawn = false;
          gameOver();
        }
        if (respawn == true) {
          player_Transform.position = respawn_point.transform.position;
          lives -= 1;
          HP = max_hp;
          cant_move = false;
        }
      }
      if (cant_move == true) return;
      if (NumberJumps > Max_Jumps - 1) {
        isgrounded = false;
      }
      if (Input.GetKeyDown(KeyCode.Space)){
        if (isgrounded == true) {
          player_Rigidbody.velocity = Vector2.up * jump_velocity;
          NumberJumps += 1;
        }
      }
  }

  public void physicaldamege(float damege)
  {
    damegeamount = damege - this.defence;
    if (damegeamount <= 0) damegeamount = 0;
    this.HP -= damegeamount;
  }

  public void magicdamege(float damege , string type)
  {
    if (type == "water") damege = 0;
    if (damege <= 0) damege = 0;
    this.HP -= damege;
  }

  public IEnumerator lingerdamege(float time , float damege , string type)
  {
    poisoned = true;
    StartCoroutine(lingerdamegetimer(time));
    while (poisoned == true) {
      if (damege != 0) magicdamege(damege , type);
      yield return new WaitForSeconds (1);
    }
  }

  IEnumerator lingerdamegetimer(float time)
  {
    CoroutineWithData cd = new CoroutineWithData(this , type_database.instance.timeing(time));
    yield return cd.coroutine;
    Debug.Log("result is " + cd.result);
    poisoned = false;
  }

  public void heal(float healing)
  {
    if (healing + HP >= max_hp){
      this.HP = max_hp;
      }else this.HP += healing;
  }
  void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Ground")){
      isgrounded = true;
      NumberJumps = 0;
    }
}

void OnCollisionExit2D(Collision2D collision)
{

}

void OnTriggerEnter2D(Collider2D Trigger)
{
  if(Trigger.tag == "kill") HP = 0;
  if(Trigger.tag == "Respawn") respawn_point.position = Trigger.transform.position;
}

    void FixedUpdate() {
      if (cant_move == true) return;
      if (fly){
        player_Rigidbody.gravityScale = 0;
        player_Rigidbody.velocity = new Vector2 (0, 0);
        if (Input.GetKey("left")) player_Transform.position = new Vector2 (player_Transform.position.x-0.5f, player_Transform.position.y);
        else if (Input.GetKey("right")) player_Transform.position = new Vector2 (player_Transform.position.x+0.5f, player_Transform.position.y);
        if (Input.GetKey("up")) player_Transform.position = new Vector2 (player_Transform.position.x, player_Transform.position.y+0.5f);
        else if (Input.GetKey("down")) player_Transform.position = new Vector2 (player_Transform.position.x, player_Transform.position.y-0.5f);
      }else player_Rigidbody.gravityScale = 2;
      if (Input.GetKey(KeyCode.S)){
        player_sprite.small = true;
        player_Hitbox.transform.localScale = new Vector3(player_Hitbox.transform.localScale.x, 0.8f);
        player_Hitbox.transform.position = new Vector2 (player_Hitbox.transform.position.x, player_Transform.position.y+0.1f);
      }else{
        player_sprite.small = false;
        player_Hitbox.transform.localScale = new Vector3(player_Hitbox.transform.localScale.x, 1);
        player_Hitbox.transform.position = new Vector2 (player_Hitbox.transform.position.x, player_Transform.position.y);
      }
      if (Input.GetKey(KeyCode.A)){
        LeftOrRight = false;
        player_sprite.showWalk();
        player_sprite.faceLeft();
        dropPoint.transform.position = new Vector2 (player_Transform.position.x-2, player_Transform.position.y);
        player_Rigidbody.velocity = new Vector2 (-move_spead, player_Rigidbody.velocity.y);
      }else if (Input.GetKey(KeyCode.D)){
        LeftOrRight = true;
        player_sprite.showWalk();
        player_sprite.faceRight();
        dropPoint.transform.position = new Vector2 (player_Transform.position.x+2, player_Transform.position.y);
        player_Rigidbody.velocity = new Vector2 (+move_spead, player_Rigidbody.velocity.y);
      }else {
        player_Rigidbody.velocity = new Vector2 (0, player_Rigidbody.velocity.y);
        player_sprite.hideWalk();
        player_sprite.faceFront();
      }
}

void gameOver()
{
  menus.gameOverOn = true;
  menus.updateGameOverMenu();
}

}
