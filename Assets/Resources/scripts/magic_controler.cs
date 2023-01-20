using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic_controler : MonoBehaviour
{
  public static magic_controler instance = null;
  public GameObject crystelPrefab;

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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject SpawnCrystel(int element, Transform spawnpoint)
    {
      Element Type = type_database.instance.GetElement(element);
      GameObject crystelSpawn = Instantiate(crystelPrefab, spawnpoint.position, spawnpoint.rotation);
      crystelSpawn.GetComponent<crystel_controler>().type = Type.id;
      Debug.Log("spawned " + Type.title + " crystel");
      crystelSpawn.name = Type.title + " crystel";
      return crystelSpawn;
    }
}
