using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_start : MonoBehaviour
{
  public trigger trigger;
  private player_controller player;
  public inv playerInventory;
  public int lives;
  public bool invon;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("player").GetComponent<player_controller>();
      playerInventory = GameObject.Find("player").GetComponent<inv>();
    }

    // Update is called once per frame
    void Update()
    {
      if (trigger.triggerd == true) if (trigger.triggerer.tag == "Player") {
        player.lives = lives;
        playerInventory.noinv = !invon;
        Destroy(gameObject);
      }
    }
}
