using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic_inv : MonoBehaviour
{
  public invui invUi;
  public bool inventoryon;
  public bool noinv;
  [HideInInspector]public List<int> player_items = new List<int>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.M)) if(noinv == false) inventoryon = !inventoryon;
      if (inventoryon == true) invUi.gameObject.SetActive(true);
      if (inventoryon == false) invUi.gameObject.SetActive(false);
    }

    public void GiveCrystel(int element)
    {
      Element type = type_database.instance.GetElement(element);
      
    }
}
