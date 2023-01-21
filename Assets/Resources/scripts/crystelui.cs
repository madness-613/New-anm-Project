using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class crystelui : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
  private Image spriteImage;
  private tooltip toolTip;
  private crystelui SelectedItem;
  public int slotnum;
  public int crystel = -1;
  public Sprite Sprite;
  int clone;
  Color color;
  float ColorR;
  float ColorG;
  float ColorB;
  float ColorA;


  private void Awake()
  {
    spriteImage = GetComponent<Image>();
    SelectedItem = GameObject.Find("magicSelectedItem").GetComponent<crystelui>();
    toolTip = GameObject.Find("magic tooltip").GetComponent<tooltip>();
    updatecrystel(-1);
  }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updatecrystel(int crystel)
    {
      this.crystel = crystel;
      if(this.crystel != -1){
        Element Type = type_database.instance.GetElement(crystel);
        foreach(KeyValuePair<string,float> type in Type.stats){
          if (type.Key == "ColorR") this.ColorR = type.Value;
          if (type.Key == "ColorG") this.ColorG = type.Value;
          if (type.Key == "ColorB") this.ColorB = type.Value;
          if (type.Key == "ColorA") this.ColorA = type.Value;
        }
        color = new Color(ColorR, ColorG, ColorB, ColorA);
        spriteImage.color = color;
      }else spriteImage.color = Color.clear;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData EventData)
   {
     if(this.crystel != -1){
      if(SelectedItem.crystel == -1){
         SelectedItem.updatecrystel(this.crystel);
         this.updatecrystel(-1);
       }
      }else if(this.crystel == -1){
        if(SelectedItem.crystel != -1){
         this.updatecrystel(SelectedItem.crystel);
         SelectedItem.updatecrystel(-1);
        }
       }
     }

   public void OnPointerEnter(PointerEventData eventData)
   {
     if(this.crystel != -1){
       toolTip.GenerateMagicToolTip(this.crystel);
     }
   }

   public void OnPointerExit(PointerEventData eventData)
   {
     toolTip.gameObject.SetActive(false);
   }
}
