using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class database_loader : MonoBehaviour
{
public GameObject databases;            //GameManager prefab to instantiate.



    void Awake ()
    {
    //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
    if (save_data.instance == null)

    //Instantiate gameManager prefab
    Instantiate(databases);
  }
}
