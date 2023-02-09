using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class magic_inv_ui : MonoBehaviour
{
  public List<crystelui> UIcrystels = new List<crystelui>();
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
      instance.GetComponentInChildren<crystelui>().slotnum = i;
      UIcrystels.Add(instance.GetComponentInChildren<crystelui>());
    }
  }
  public void UpdateSlot(int slot, int id)
  {
    UIcrystels[slot].updatecrystel(id);
  }

  public void AddNewCrystel(int id)
  {
    UpdateSlot(UIcrystels.FindIndex(i => i.crystel == -1), id);
  }

  public void RemoveCrystel(int id)
  {
    UpdateSlot(UIcrystels.FindIndex(i => i.crystel == id), -1);
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
