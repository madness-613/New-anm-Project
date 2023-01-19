using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_controler : MonoBehaviour
{
  public trigger trigger;
  public int id;
    // Update is called once per frame
    void Update()
    {
      if (trigger.triggerd == true) if (trigger.triggerer.tag == "Player") {
        trigger.triggerer.transform.parent.gameObject.GetComponent<player_controller>().level = id;
        level_controler.instance.loadLevel(id);
        save_data.instance.SaveGame();
      }
    }
}
