using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main_menu_controler : MonoBehaviour
{
  public Button loadlastGameButton;
  public Button newGameButton;

  private void Awake()
  {
    loadlastGameButton.onClick.AddListener(loadlastGameButtonClicked);
    newGameButton.onClick.AddListener(newGameButtonClicked);
  }
    // Update is called once per frame
    void Update()
    {

    }

    void loadlastGameButtonClicked()
    {
      save_data.instance.LoadGame();
    }

    void newGameButtonClicked()
    {
      save_data.instance.ResetGame();
      level_controler.instance.loadLevel(1);
    }
}
