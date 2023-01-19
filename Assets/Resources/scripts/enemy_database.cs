using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_database : MonoBehaviour
{
public static enemy_database instance = null;
public int enemyNum = 0;
[SerializeField] private GameObject blob;

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

    public GameObject GetEnemy(string title)
    {
      if(title == "blob")return this.blob;
      else return null;
    }

    public GameObject SpawnEnemy(string Enemy, int element, Transform spawnpoint)
    {
      Element Type = type_database.instance.GetElement(element);
      GameObject spawn = GetEnemy(Enemy);
      if(spawn == null) return null;
      GameObject enemySpawn = Instantiate(spawn, spawnpoint.position, spawnpoint.rotation);
      enemySpawn.GetComponent<enemy_stats>().Name = Type.title + " " + Enemy;
      enemySpawn.GetComponent<enemy_stats>().type = Type.title;
      enemySpawn.GetComponent<enemy_stats>().Race = Enemy;
      enemySpawn.name = enemySpawn.GetComponent<enemy_stats>().Name;
      enemy_controler.instance.AddEnemy(Enemy, enemySpawn);
      Debug.Log("spawned " + Type.title + " " + Enemy);
      return enemySpawn;
    }

    public GameObject SpawnEnemy(string Enemy, string element, Transform spawnpoint)
    {
      Element Type = type_database.instance.GetElement(element);
      GameObject spawn = GetEnemy(Enemy);
      if(spawn == null) return null;
      GameObject enemySpawn = Instantiate(spawn, spawnpoint.position, spawnpoint.rotation);
      enemySpawn.GetComponent<enemy_stats>().Name = Type.title + " " + Enemy;
      enemySpawn.GetComponent<enemy_stats>().type = Type.title;
      enemySpawn.GetComponent<enemy_stats>().Race = Enemy;
      enemySpawn.name = enemySpawn.GetComponent<enemy_stats>().Name;
      Debug.Log("spawned " + Type.title + " " + Enemy);
      return enemySpawn;
    }

}
