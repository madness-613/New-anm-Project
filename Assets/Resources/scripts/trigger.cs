using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
  public bool triggerd;
  public Collider2D triggerer;

    void OnTriggerEnter2D(Collider2D Trigger)
    {
      triggerd = true;
      triggerer = Trigger;
    }

    void OnTriggerExit2D(Collider2D Trigger)
    {
      triggerd = false;
      triggerer = Trigger;
    }
}
