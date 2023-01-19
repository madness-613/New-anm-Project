using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
  public string thing;
  public string type;
  public float spawnTime;
  public float maxSpawns;
  public float numberofthings = 1;
  private float spawns;
  private float savedMaxSpawns;
  public  bool canspawn = true;
  public bool spawntrigger;
  public bool triggerReg;
  public Transform spawnPoint;
  public trigger start;
  public trigger end;
      // Start is called before the first frame update
    void Start()
    {
      if (maxSpawns == 0) maxSpawns = -1;
      if (triggerReg == true){
        savedMaxSpawns = maxSpawns;
        maxSpawns = 0;
      }
      if (triggerReg == false){
        Destroy(start.gameObject);
        Destroy(end.gameObject);
      }
    }

    // Update is called once per frame
    void Update()
    {
      if (triggerReg == true) if (start.triggerd == true) if (start.triggerer.tag == "Player"){
         spawntrigger = true;
         canspawn = true;
         Destroy(start.gameObject);
         maxSpawns = savedMaxSpawns;
    }
      if (triggerReg == true) if (end.triggerd == true) if (end.triggerer.tag == "Player"){
       spawntrigger = false;
       maxSpawns = spawns;
     }
      if (spawns == maxSpawns) canspawn = false;
      if (canspawn == true) StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
      canspawn = false;
      spawns += 1;
      for (int i=0; i<numberofthings; i++) {
      enemy_database.instance.SpawnEnemy(thing, type, spawnPoint);
    }
      yield return new WaitForSeconds (spawnTime);
      canspawn = true;
    }
}
