using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tooltip : MonoBehaviour
{
private Text toolTip;
public Text toolTipText;
      // Start is called before the first frame update
    void Start()
    {
      gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void GenerateToolTip(Item item)
    {
      string statText = "";
      if(item.stats.Count > 0) {
        foreach(KeyValuePair<string,int> Item in item.stats){
          if (Item.Key == "throwable") {
            statText += Item.Key + "\n";
          }else if(Item.Key != "useable") statText += Item.Key + ": " + Item.Value + "\n";
        }
      }
      string toolTip = string.Format("<b>{0}</b>\n{1}\n\n<b>{2}</b>", item.title, item.description, statText);
      toolTipText.text = toolTip;
      gameObject.SetActive(true);
    }

    public void GenerateMagicToolTip(int id)
    {
      string statText = "";
      Element Type = type_database.instance.GetElement(id);
      foreach(KeyValuePair<string,string> crystel in Type.stats2){
        statText += crystel.Key + ": " + crystel.Value + "\n";
      }
      string toolTip = string.Format("<b>{0}</b>\n{1}\n\n<b>{2}</b>", Type.title, Type.description, statText);
      toolTipText.text = toolTip;
      gameObject.SetActive(true);
    }
}
