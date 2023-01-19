using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controler : MonoBehaviour
{
  public static enemy_controler instance = null;
  public List<GameObject> enemys;
  public List<GameObject> blobs;

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

      public void AddEnemy(string type, GameObject enemy)
      {
        enemys.Add(enemy);
        if(type == "blob") blobs.Add(enemy);
      }

      public void RemoveEnemy(string type, GameObject enemy)
      {
        enemys.Remove(enemy);
        if(type == "blob") blobs.Remove(enemy);
        Destroy(enemy);
      }

      public string FindList(GameObject enemy)
      {
        if(blobs.Contains(enemy)) return "blobs";
        else return null;
      }

      public void tryMerge(GameObject enemy, GameObject target)
      {
        if(!enemys.Contains(enemy)) return;
        string Element = null;
        Transform pos = enemy.GetComponent<Transform>();
        if (!enemy.GetComponent<enemy_stats>().elite || !target.GetComponent<enemy_stats>().elite) if (enemy.GetComponent<enemy_stats>().mergeamount + target.GetComponent<enemy_stats>().mergeamount > 5) return;
        if (enemy.GetComponent<enemy_stats>().type == target.GetComponent<enemy_stats>().weekness) return;
        else if (enemy.GetComponent<enemy_stats>().weekness == target.GetComponent<enemy_stats>().type) return;
        else if (enemy.GetComponent<enemy_stats>().type == target.GetComponent<enemy_stats>().strength) return;
        else if (enemy.GetComponent<enemy_stats>().strength == target.GetComponent<enemy_stats>().type) return;
        if(enemy.GetComponent<enemy_stats>().type == target.GetComponent<enemy_stats>().ExtraMerge) Element = target.GetComponent<enemy_stats>().ExtraMergeTo;
        GameObject spawn = enemy_database.instance.SpawnEnemy(enemy.GetComponent<enemy_stats>().Race, Element, pos);
        spawn.GetComponent<enemy_stats>().mergeamount = enemy.GetComponent<enemy_stats>().mergeamount + target.GetComponent<enemy_stats>().mergeamount;
        RemoveEnemy(enemy.GetComponent<enemy_stats>().Race, enemy);
        RemoveEnemy(target.GetComponent<enemy_stats>().Race, target);
      }
}
