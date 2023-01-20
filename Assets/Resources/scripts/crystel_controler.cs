using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystel_controler : MonoBehaviour
{
  public trigger Trigger;
  public SpriteRenderer spriteRenderer;
  public int type;
  Color color;
  float ColorR;
  float ColorG;
  float ColorB;
  float ColorA;

    // Start is called before the first frame update
    void Start()
    {
      Element element = type_database.instance.GetElement(this.type);
      foreach(KeyValuePair<string,float> Type in element.stats){
        if (Type.Key == "ColorR") this.ColorR = Type.Value;
        if (Type.Key == "ColorG") this.ColorG = Type.Value;
        if (Type.Key == "ColorB") this.ColorB = Type.Value;
        if (Type.Key == "ColorA") this.ColorA = Type.Value;
      }
      color = new Color(ColorR, ColorG, ColorB, ColorA);
      spriteRenderer.color = color;
    }

    // Update is called once per frame
    void Update()
    {
      if (Trigger.triggerd == true) if (Trigger.triggerer.tag == "Player"){
        Trigger.triggerer.transform.parent.gameObject.GetComponent<magic_inv>().GiveCrystel(type);
        Destroy(gameObject);
      }
    }
}
