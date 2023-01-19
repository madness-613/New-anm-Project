using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu_controler : MonoBehaviour
{
  public GameObject pauseMenu;
  public bool pauseOn;
  public Button continueButton;
  public Button saveGameButton;
  public Button loadGameButton;
  public GameObject gameOverMenu;
  public bool gameOverOn;
  public Button restartbutton;
  public Button loadlastGameButton;


    private void Awake()
    {
      continueButton.onClick.AddListener(continueButtonClicked);
      saveGameButton.onClick.AddListener(saveGameButtonClicked);
      loadGameButton.onClick.AddListener(loadGameButtonClicked);
      restartbutton.onClick.AddListener(restartbuttonClicked);
      loadlastGameButton.onClick.AddListener(loadlastGameButtonClicked);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape)){
        pauseOn =! pauseOn;
        updatePauseMenu();
      }
    }

    public void updatePauseMenu()
    {
      pauseMenu.SetActive(pauseOn);
      if(pauseOn == true) Time.timeScale = 0;
      else if(pauseOn == false) Time.timeScale = 1;
    }

    public void continueButtonClicked()
    {
      pauseOn = false;
      updatePauseMenu();
    }

    public void saveGameButtonClicked()
    {
      save_data.instance.SaveGame();
    }

    public void loadGameButtonClicked()
    {
      save_data.instance.LoadGame();
    }

    public void updateGameOverMenu()
    {
      if(gameOverOn == true){
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
      } else if(gameOverOn == false){
        gameOverMenu.SetActive(false);
        Time.timeScale = 1;
     }
    }

    public void restartbuttonClicked()
    {

    }

    public void loadlastGameButtonClicked()
    {
      save_data.instance.LoadGame();
    }

}
