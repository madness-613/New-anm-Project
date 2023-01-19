using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class itemui : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler

{
  public Item item;
  public int slotnum;
  private drop drop;
  private Image spriteImage;
  private itemui SelectedItem;
  private Item clone;
  private tooltip toolTip;

    private void Awake()
    {
      spriteImage = GetComponent<Image>();
      updateitem(null);
      SelectedItem = GameObject.Find("SelectedItem").GetComponent<itemui>();
      drop = GameObject.Find("SelectedItem").GetComponent<drop>();
      toolTip = GameObject.Find("tooltip").GetComponent<tooltip>();
    }

    public void updateitem(Item item)
    {
      this.item = item;
      if(this.item != null){
        spriteImage.color = Color.white;
        spriteImage.sprite = this.item.icon;
      }else{
        spriteImage.color = Color.clear;
      }
    }

     void IPointerDownHandler.OnPointerDown(PointerEventData EventData)
    {
      if (this.item != null) {
        if (SelectedItem.item != null){
          Item clone = new Item(SelectedItem.item);
          SelectedItem.updateitem(this.item);
          updateitem(clone);
        }else {
          SelectedItem.updateitem(this.item);
          updateitem(clone);
        }
      }else if (SelectedItem.item != null) {
        updateitem(SelectedItem.item);
        SelectedItem.updateitem(null);
      }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
      if(this.item != null){
        drop.id = this.item.id;
        toolTip.GenerateToolTip(this.item);
      }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
      toolTip.gameObject.SetActive(false);
      drop.id = -1;
    }
}
