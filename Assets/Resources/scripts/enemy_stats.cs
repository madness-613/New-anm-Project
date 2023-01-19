using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_stats : MonoBehaviour
{
  public string Name;
  public string Race;
  public float hp = 0;
  public float maxHp = 0;
  public float defence = 0;
  public float damege = 0;
  public string specal;
  public float specalTime;
  public float magicDamege = 0;
  public string weekness;
  public string strength;
  public string boost;
  public string ExtraMerge;
  public string ExtraMergeTo;
  public bool stuned = false;
  public float stunTime = 5f;
  public float moveSpead = 5;
  public string type = "physical";
  public int itemDrop = -1;
  public int dropAmount;
  public int mergeamount = 1;
  public bool elite;
  bool poisoned = false;

  public IEnumerator stun()
  {
    yield return new WaitForSeconds (0.2f);
    stuned = true;
    yield return new WaitForSeconds (stunTime);
    stuned = false;
  }
    // Start is called before the first frame update
    void Start()
    {
      Element Type = type_database.instance.GetElement(this.type);
      foreach(KeyValuePair<string,float> type in Type.stats){
        if (type.Key == "SpecalTime") this.specalTime = type.Value;
      }
      foreach(KeyValuePair<string,string> type in Type.stats2){
        if (type.Key == "Weekness") this.weekness = type.Value;
        if (type.Key == "Strength") this.strength = type.Value;
        if (type.Key == "Boost") this.boost = type.Value;
        if (type.Key == "Specal") this.specal = type.Value;
        if (type.Key == "ExtraMerge") this.ExtraMerge = type.Value;
        if (type.Key == "ExtraMergeto") this.ExtraMergeTo = type.Value;
      }
    }

    void OnTriggerEnter2D(Collider2D Trigger)
    {
      if(Trigger.tag == "kill") hp = 0;
    }

    public void physicaldamege(float damege)
    {
      float damegeamount = damege - this.defence;
      if (damegeamount <= 0) damegeamount = 0;
      this.hp -= damegeamount;
    }

    public void magicdamege(float damege , string type)
    {
      if (this.type == type) {
        heal(damege);
        damege = 0;
      }
      if (type == weekness) damege = damege * 2;
      if (damege <= 0) damege = 0;
      this.hp -= damege;
    }

    public IEnumerator lingerdamege(float time , float damege , string type)
    {
      poisoned = true;
      StartCoroutine(lingerdamegetimer(time));
      while (poisoned == true) {
        yield return new WaitForSeconds (1);
        if (damege != 0) magicdamege(damege , type);
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
      if (healing + hp >= maxHp){
        this.hp = maxHp;
        }else this.hp += healing;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      if (stuned != true){
      if (collision.gameObject.CompareTag("Player")) {
        if (damege != 0) collision.gameObject.GetComponent<player_controller>().physicaldamege(damege);
        if (magicDamege != 0) collision.gameObject.GetComponent<player_controller>().magicdamege(magicDamege , type);
        if (specal == "lingering") StartCoroutine(collision.gameObject.GetComponent<player_controller>().lingerdamege(specalTime , magicDamege , type));
      }else if (collision.gameObject.CompareTag("Enemy")) {
        if (damege != 0) collision.gameObject.GetComponent<enemy_stats>().physicaldamege(damege);
        if (magicDamege != 0) collision.gameObject.GetComponent<enemy_stats>().magicdamege(magicDamege , type);
        if (specal == "lingering") StartCoroutine(collision.gameObject.GetComponent<enemy_stats>().lingerdamege(specalTime , magicDamege , type));
      }
      }
    }
    // Update is called once per frame
    void Update()
    {
      if (hp <= 0){
        for (int i=0; i<dropAmount; i++) {
        if (itemDrop != -1) ItemDatabase.instance.SpawnItem(itemDrop , gameObject.GetComponent<Transform>());
        }
        Destroy(gameObject);
      }
    }
}
