using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class invui : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
  public List<itemui> UIitems = new List<itemui>();
  public GameObject slotprefab;
  public Transform slotPanel;
  public int numberOFslots = 1;
  public bool ininv;

  public  void Awake()
  {
    for(int i = 0; i < numberOFslots; i++)
    {
      GameObject instance = Instantiate(slotprefab);
      instance.transform.SetParent(slotPanel);
      instance.GetComponentInChildren<itemui>().slotnum = i;
      UIitems.Add(instance.GetComponentInChildren<itemui>());
    }
  }
  public void UpdateSlot(int slot, Item item)
  {
    UIitems[slot].updateitem(item);
  }

  public void AddNewItem(Item item)
  {
    UpdateSlot(UIitems.FindIndex(i => i.item == null), item);
  }

  public void RemoveItem(Item item)
  {
    UpdateSlot(UIitems.FindIndex(i => i.item == item), null);
  }

  public void OnPointerEnter(PointerEventData eventData)
  {
   ininv = true;
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    ininv = false;
  }
}
