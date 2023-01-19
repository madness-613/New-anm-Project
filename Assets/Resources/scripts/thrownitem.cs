using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrownitem : MonoBehaviour
{
public int id;
public SpriteRenderer itemSprite;
public float speed;
public float damage = 0;
public bool magic;
public float magicdamege = 0;
public string magictype;
public bool LeftOrRight;
public Item item;
public Rigidbody2D Rigidbody;
    // Start is called before the first frame update
    void Start()
    {

    }

  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Enemy")){
      collision.gameObject.GetComponent<enemy_stats>().physicaldamege(damage);
      if (magic == true) collision.gameObject.GetComponent<enemy_stats>().magicdamege(magicdamege , magictype);
      Destroy(gameObject);
    }else if (collision.gameObject.CompareTag("Player")) {
      collision.gameObject.GetComponent<inv>().GiveItem(id);
      Destroy(gameObject);
    }
  }
    public void RecieveInfo(int id , Item titem , Sprite icon , float speed , bool LeftOrRight)
    {
      this.id = id;
      item = titem;
      itemSprite.sprite = icon;
      this.speed = speed;
      this.LeftOrRight = LeftOrRight;

      if(titem.stats.Count > 0) {
        foreach(KeyValuePair<string,int> item in titem.stats){
          Debug.Log(item.Key + ": " + item.Value);
         if (item.Key == "throwable") {
          this.speed = speed * item.Value;
        }else if (item.Key == "damage") {
          damage += item.Value;
        }else if (item.Key == "fire") {
          this.magic = true;
          magicdamege += item.Value;
          magictype = "fire";
        }else if (item.Key == "water") {
          this.magic = true;
          magicdamege += item.Value;
          magictype = "water";
        }else if (item.Key == "poison") {
          this.magic = true;
          magicdamege += item.Value;
          magictype = "poison";
            }
          }
        }

      if (LeftOrRight == false) {
      Rigidbody.velocity = new Vector2 (-this.speed, Rigidbody.velocity.y);
    }else if (LeftOrRight == true) {
      Rigidbody.velocity = new Vector2 (+this.speed, Rigidbody.velocity.y);
      }
    }
}
