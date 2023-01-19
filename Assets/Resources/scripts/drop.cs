using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class drop : MonoBehaviour, IPointerDownHandler
{
public inv inv;
public int id;
public itemui SelectedItem;
public invui invui;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
          inv.DropItem(id);
        }
        if (Input.GetKeyDown(KeyCode.T)){
          inv.throwItem(id);
        }
        if (Input.GetKeyDown(KeyCode.U)) {
          inv.UseItem(id);
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData EventData)
    {

    }
}
