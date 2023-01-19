using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_data : MonoBehaviour
{
  public static save_data instance = null;
  public player_controller player;
  public menu_controler menu;
  public Transform playerTransform;
  public float playerTransformX;
  public float playerTransformY;
  public int playerLevel;
  public inv playerInventory;
  public float playerHP;
  public float playerMaxHP;
  public int playerLives;
  public float PlayerDefence;
  public float playerAttack;
  public string items;

  void Awake()
  {
      //Check if instance already exists
      if (instance == null)

    //if not, set instance to this
    instance = this;

    //If instance already exists and it's not this:
    else if (instance != this)

    //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
    Destroy(gameObject);

    //Sets this to not be destroyed when reloading scene
    DontDestroyOnLoad(gameObject);
  }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

  public void SaveGame()
{
  playerInventory = GameObject.Find("player").GetComponent<inv>();
  player = GameObject.Find("player").GetComponent<player_controller>();
  playerTransform = GameObject.Find("player").GetComponent<Transform>();
  playerTransformX = playerTransform.position.x;
  playerTransformY = playerTransform.position.y;
  playerLevel = player.level;
  playerHP = player.HP;
  playerMaxHP = player.max_hp;
  playerLives = player.lives;
  PlayerDefence = player.defence;
  playerAttack = player.attack;
  items = playerInventory.itemString;

  PlayerPrefs.SetFloat("playerTransformX", playerTransformX);
  PlayerPrefs.SetFloat("playerTransformY", playerTransformY);
  PlayerPrefs.SetInt("playerLevel", playerLevel);
	PlayerPrefs.SetFloat("playerHP", playerHP);
	PlayerPrefs.SetFloat("playerMaxHP", playerMaxHP);
	PlayerPrefs.SetInt("playerLives", playerLives);
  PlayerPrefs.SetFloat("PlayerDefence", PlayerDefence);
  PlayerPrefs.SetFloat("playerAttack", playerAttack);
  PlayerPrefs.SetString("items", items);
	PlayerPrefs.Save();
	Debug.Log("Game data saved!");
}

public void LoadGame()
{
  menu = GameObject.Find("player").GetComponent<menu_controler>();
  menu.pauseOn = false;
  menu.updatePauseMenu();
  playerLevel = PlayerPrefs.GetInt("playerLevel");
  level_controler.instance.loadLevel(playerLevel);

  this.playerInventory = GameObject.Find("player").GetComponent<inv>();
  this.player = GameObject.Find("player").GetComponent<player_controller>();
  playerTransform = GameObject.Find("player").GetComponent<Transform>();

  playerTransformX = PlayerPrefs.GetFloat("playerTransformX");
  playerTransformY = PlayerPrefs.GetFloat("playerTransformY");
  playerHP = PlayerPrefs.GetFloat("playerHP");
  playerMaxHP =  PlayerPrefs.GetFloat("playerMaxHP");
  playerLives = PlayerPrefs.GetInt("playerLives");
  PlayerDefence = PlayerPrefs.GetFloat("PlayerDefence");
  playerAttack = PlayerPrefs.GetFloat("playerAttack");
  items = PlayerPrefs.GetString("items");
  playerTransform.position = new Vector2(playerTransformX , playerTransformY);
  player.level = playerLevel;
  player.HP = playerHP;
  player.max_hp = playerMaxHP;
  player.lives = playerLives;
  player.defence = PlayerDefence;
  player.attack = playerAttack;
  playerInventory.itemString = items;
  playerInventory.additemlist(items);
  Debug.Log("Game data loaded!");

}

public void ResetGame()
{
  PlayerPrefs.SetFloat("playerTransformX", 0);
  PlayerPrefs.SetFloat("playerTransformY", 0);
  PlayerPrefs.SetInt("playerLevel", 1);
  PlayerPrefs.SetFloat("playerHP", 100);
  PlayerPrefs.SetFloat("playerMaxHP", 100);
  PlayerPrefs.SetInt("playerLives", 0);
  PlayerPrefs.SetFloat("PlayerDefence", 0);
  PlayerPrefs.SetFloat("playerAttack", 0);
  PlayerPrefs.SetString("items", null);
  PlayerPrefs.Save();
  Debug.Log("Game data reset!");
}

}
