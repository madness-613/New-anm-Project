using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
public static ItemDatabase instance = null;
public GameObject drop;
private inv inv;
public List<Item> items = new List<Item>();

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
  BuildDatabase();
  inv = GameObject.Find("player").GetComponent<inv>();
}

public Item GetItem(int id)
{
  return items.Find(item => item.id == id);
}

public Item GetItem(string title)
{
  return items.Find(item => item.title == title);
}

public GameObject SpawnItem(int id , Transform spawnpoint)
{
  Item item = GetItem(id);
  var ditem = (GameObject)Instantiate(drop, spawnpoint.position, spawnpoint.rotation);
  ditem.name = item.title + "(droped)";
  ditem.GetComponent<dropeditem>().RecieveItemInfo(id , item.icon);
  Debug.Log("spawned " + item.title);
  return ditem;
}

void BuildDatabase()
{
  items = new List<Item>(){
    new Item(0, "basic shield", "a basic shield made of wood with a iron trim",
    new Dictionary<string, int>
    {
      {"defence", 1}
    }),
    new Item(1, "glass bottle", "a empty bottle",
    new Dictionary<string, int>
    {
      {"throwable", 1},
      {"damage", 1}
    }),
    new Item(2, "water bottle", "a bottle full of water",
    new Dictionary<string, int>
    {
      {"throwable", 1},
      {"useable", 1},
      {"damage", 1},
      {"water", 3}
    }),
    new Item(3, "staby stab", "a sword made of a vary sharp alloy",
    new Dictionary<string, int>
    {
      {"damage", 5}
    }),
    new Item(4, "fire vile", "a sealed vile full of liquid fire",
    new Dictionary<string, int>
    {
      {"throwable", 2},
      {"damage", 1},
      {"fire", 2}
    }),
    new Item(5, "poison bottle", "a bottle full of poison",
    new Dictionary<string, int>
    {
      {"throwable", 1},
      {"useable", 1},
      {"damage", 1},
      {"poison", 3}
    }),
    new Item(6, "poison vile", "a sealed vial full of poison",
    new Dictionary<string, int>
      {
        {"throwable", 2},
        {"damage", 1},
        {"poison", 2}
      }),
      new Item(7, "water vile", "a sealed vial full of water",
      new Dictionary<string, int>
        {
          {"throwable", 2},
          {"damage", 1},
          {"water", 2}
      }),
      new Item(8, "healing bottle", "a bottle full of a healing potion",
      new Dictionary<string, int>
        {
          {"throwable", 1},
          {"useable", 1},
          {"damage", 1},
          {"healing", 5}
      }),
      new Item(9, "healing vile", "a sealed vial full of a healing potion",
      new Dictionary<string, int>
        {
          {"throwable", 2},
          {"damage", 1},
          {"healing", 2}
      }),
      new Item(10, "shattered sword", "a sword held together more by mana then steel",
      new Dictionary<string, int>
        {
          {"damage", 3}
      }),
      new Item(11, "fire sword", "a sword with a fire crystal aiding it",
      new Dictionary<string, int>
        {
          {"damage", 4},
          {"fire", 2}
      }),
      new Item(12, "femboy shark", "a shark that is infused with the power of the femboy",
      new Dictionary<string, int>
        {
          {"defence", 10},
          {"magic defence", 10},
          {"regeneration", 2}
      })
  };
}
}
