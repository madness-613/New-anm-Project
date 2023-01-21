using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic_inv : MonoBehaviour
{
  public magic_inv_ui magicInvUi;
  public bool inventoryon;
  public bool noinv;
  public List<int> player_crystels = new List<int>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.M)) if(noinv == false) inventoryon = !inventoryon;
      if (inventoryon == true) magicInvUi.gameObject.SetActive(true);
      if (inventoryon == false) magicInvUi.gameObject.SetActive(false);
    }

    public void GiveCrystel(int id)
    {
      player_crystels.Add(id);
      magicInvUi.AddNewCrystel(id);
    }

    public int CheckForCrystel(int id)
    {
      return player_crystels.Find(Crystel => Crystel == id);
    }

    public void RemoveCrystel(int id)
    {
      if (id != -1) {
          player_crystels.Remove(id);
          magicInvUi.RemoveCrystel(id);
        }
    }
}
