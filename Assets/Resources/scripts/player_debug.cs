using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_debug : MonoBehaviour
{
  public player_controller player;
  public inv inventory;
  public GameObject debug_test_input;
  public GameObject console;
  private InputField debug_test_text;
  public bool debug_on = false;
  public Text log;
  public string result;
  public string random;
    // Start is called before the first frame update
    void Start()
    {
      DontDestroyOnLoad(gameObject);
      log.gameObject.SetActive(debug_on);
      debug_test_text = debug_test_input.GetComponent<InputField>();
      debug_test_input.SetActive(debug_on);
      console.SetActive(debug_on);
      debug_test_text.onValueChanged.AddListener(delegate {debugChangeCheck(); });
      debug_test_text.onEndEdit.AddListener(delegate {debugEndEditCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.BackQuote)){
          debug_on =! debug_on;
          log.gameObject.SetActive(debug_on);
          debug_test_input.SetActive(debug_on);
          console.SetActive(debug_on);
      }
    }

public void debugChangeCheck()
{
    player.cant_move = true;
    inventory.noinv = true;
    // result = "added " + random;
    inventory.inventoryon = false;
}

public void debugEndEditCheck()
{
  string cmd = debug_test_text.text;
  debug_test_text.text = "";
  string[] args = cmd.Split(' ');
  if (args[0] == "give"){
    int GI = int.Parse(args[1]);
    inventory.GiveItem(GI);
    result = "added " + random;
    }else if (args[0] == "remove") {
      int RI = int.Parse(args[1]);
      inventory.RemoveItem(RI);
      result = "removed " + random;
    }else if (args[0] == "set_jump_force") {
      float jv = float.Parse(args[1]);
      player.jump_velocity = jv;
      result = "jump force set to" + jv;
    }else if (args[0] == "set_max_jumps") {
      float mj = float.Parse(args[1]);
      player.Max_Jumps = mj;
      result = "max jumps set to" + mj;
    }else if (args[0] == "set_move_speed") {
      float ms = float.Parse(args[1]);
      player.move_spead = ms;
      result = "move speed set to" + ms;
    }else if (args[0] == "load") {
      level_controler.instance.loadLevel(int.Parse(args[1]));
      result = "loading level" + args[1];
    }
    player.cant_move = false;
    inventory.noinv = false;
    this.log.text = result;
}
}
