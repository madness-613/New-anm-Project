using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropeditem : MonoBehaviour
{
public int id;
public SpriteRenderer itemSprite;
public trigger Trigger;

    // Update is called once per frame
    void Update()
    {
      if (Trigger.triggerd == true) if (Trigger.triggerer.tag == "Player"){
        Trigger.triggerer.transform.parent.gameObject.GetComponent<inv>().GiveItem(id);
        Destroy(gameObject);
      }
    }

    public void RecieveItemInfo(int id , Sprite icon)
    {
      this.id = id;
      itemSprite.sprite = icon;
    }
}
