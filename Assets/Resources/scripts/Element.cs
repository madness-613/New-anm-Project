using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element
{
  public int id;
  public string title;
  public string description;

  public Dictionary<string, float> stats = new Dictionary<string, float>();
  public Dictionary<string, string> stats2 = new Dictionary<string, string>();

  public Element(int id, string title, string description, Dictionary<string, float> stats, Dictionary<string, string> stats2)
  {
    this.id = id;
    this.title = title;
    this.description = description;
    this.stats = stats;
    this.stats2 = stats2;
  }


  public Element(Element element)
  {
    this.id = element.id;
    this.title = element.title;
    this.description = element.description;
    this.stats = element.stats;
    this.stats2 = element.stats2;
  }
}
