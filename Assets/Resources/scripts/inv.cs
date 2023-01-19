using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inv : MonoBehaviour
{
  public invui invUi;
  public bool inventoryon;
  public Transform dropPoint;
  public GameObject drop;
  public GameObject Throw;
  public itemui SelectedItem;
  public player_controller player;
  public player_debug playerDebug;
  public bool noinv;
  public string itemString;
  [HideInInspector]public List<Item> player_items = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.I)) if(noinv == false) inventoryon = !inventoryon;
      if (inventoryon == true) invUi.gameObject.SetActive(true);
      if (inventoryon == false) invUi.gameObject.SetActive(false);
    }

    public void GiveItem(int id)
    {
      Item itemToAdd = ItemDatabase.instance.GetItem(id);
      player_items.Add(itemToAdd);
      invUi.AddNewItem(itemToAdd);
      if(itemToAdd.stats.Count > 0) {
        bool throwable = false;
        foreach(KeyValuePair<string,int> item in itemToAdd.stats){
          if (item.Key == "defence") player.defence += item.Value;
          else if (item.Key == "throwable")throwable = true;
          else if (throwable != true) {
            if (item.Key == "damage") player.attack += item.Value;
          }
        }
      }
      Debug.Log("Added item: " + itemToAdd.title);
      playerDebug.random = itemToAdd.title;
      itemString += "," + itemToAdd.id;
    }

    public void GiveItem(string itemName)
    {
      Item itemToAdd = ItemDatabase.instance.GetItem(itemName);
      player_items.Add(itemToAdd);
      invUi.AddNewItem(itemToAdd);
      if(itemToAdd.stats.Count > 0) {
        bool throwable = false;
        foreach(KeyValuePair<string,int> item in itemToAdd.stats){
          if (item.Key == "defence") player.defence += item.Value;
          else if (item.Key == "throwable") throwable = true;
          else if (throwable != true) {
            if (item.Key == "damage") player.attack += item.Value;
          }
        }
      }
      Debug.Log("Added item: " + itemToAdd.title);
      playerDebug.random = itemToAdd.title;
      itemString += "," + itemToAdd.id;
    }

    public void additemlist(string list)
    {
      string[] itemIds = list.Split(',');
      foreach(var id in itemIds){
        bool Result;
        int number;
        Result = int.TryParse(id, out number);
        if(Result){
          int idInt = int.Parse(id);
          GiveItem(idInt);
        }
      }
    }

    public Item CheckForItem(int id)
    {
      return player_items.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
      Item itemtoRemove = CheckForItem(id);
      if (itemtoRemove != null) {
          player_items.Remove(itemtoRemove);
          invUi.RemoveItem(itemtoRemove);
          if(itemtoRemove.stats.Count > 0) {
            bool throwable = false;
            foreach(KeyValuePair<string,int> item in itemtoRemove.stats){
              if (item.Key == "defence") player.defence -= item.Value;
              else if (item.Key == "throwable") throwable = true;
              else if (throwable != true) {
                if (item.Key == "damage") player.attack -= item.Value;
              }
            }
          }
          Debug.Log("Item Removed: " + itemtoRemove.title);
          playerDebug.random = itemtoRemove.title;
          removeFromItemString("," + itemtoRemove.id);
      }
    }

    public void DropItem(int id)
    {
      Item item = CheckForItem(id);
      if (item != null) {
        var ditem = (GameObject)Instantiate(drop, dropPoint.position, dropPoint.rotation);
        ditem.name = item.title + "(droped)";
        ditem.GetComponent<dropeditem>().RecieveItemInfo(id , item.icon);
        RemoveItem(id);
      }
    }

    public void throwItem(int id)
    {
      Item item = CheckForItem(id);
      if (item != null) {
        foreach(KeyValuePair<string,int> sitem in item.stats){
          if (sitem.Key == "throwable") {
            var titem = (GameObject)Instantiate(Throw , dropPoint.position, dropPoint.rotation);
            titem.name = item.title + "(thrown)";
            titem.GetComponent<thrownitem>().RecieveInfo(id , item , item.icon , player.Throwspeed , player.LeftOrRight);
            RemoveItem(id);
          }
        }
      }
    }

    public void UseItem(int id)
    {
      Item item = CheckForItem(id);
      if(item != null){
        bool canuse = false;
        foreach(KeyValuePair<string,int> uitem in item.stats){
          if (uitem.Key == "useable") canuse = true;
          if (canuse == true) {
              if (uitem.Key == "healing") {
                player.heal(uitem.Value);
              }else if (uitem.Key == "poison") {
                player.magicdamege(uitem.Value, "poison");
              }else if (uitem.Key == "fire") {
                player.magicdamege(uitem.Value, "fire");
              }
            }
        RemoveItem(id);
      }
    }
  }

  public void removeFromItemString(string strTwo)
  {
	   itemString = itemString.Replace(strTwo, "");
  }
}
