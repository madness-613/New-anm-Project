using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_controler : MonoBehaviour
{
  public static level_controler instance = null;
  public Transform player;
  public player_controller playerController;


  void Awake()
  {
      //Check if instance already exists
      if (instance == null)

    //if not, set instance to this
    instance = this;

    //If instance already exists and it's not this:
    else if (instance != this)

    //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
    Destroy(gameObject);

    //Sets this to not be destroyed when reloading scene
    DontDestroyOnLoad(gameObject);
  }

  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.Find("player").GetComponent<Transform>();
    playerController = GameObject.Find("player").GetComponent<player_controller>();
  }

  public void loadLevel(int level)
  {
  SceneManager.LoadScene (sceneBuildIndex:level);
  player.position = new Vector3(0 , 0 , 0);
  playerController.level = level;
  Debug.Log("level " + level + " loaded");
  Debug.Log(NameFromIndex(level) + " loaded");
  }

  private static string NameFromIndex(int BuildIndex)
{
    string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
    int slash = path.LastIndexOf('/');
    string name = path.Substring(slash + 1);
    int dot = name.LastIndexOf('.');
    return name.Substring(0, dot);
}
}
