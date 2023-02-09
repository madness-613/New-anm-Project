using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineWithData {
    public Coroutine coroutine { get; private set; }
    public object result;
    private IEnumerator target;
    public CoroutineWithData(MonoBehaviour owner, IEnumerator target) {
        this.target = target;
        this.coroutine = owner.StartCoroutine(Run());
    }

    private IEnumerator Run() {
        while(target.MoveNext()) {
            result = target.Current;
            yield return result;
        }
    }
}

public class type_database : MonoBehaviour
{
public List<Element> Elements = new List<Element>();
public bool done;
public static type_database instance = null;

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
    BuildDatabase();
    }

    public Element GetElement(int id)
    {
      return Elements.Find(Element => Element.id == id);
    }

    public Element GetElement(string title)
    {
      return Elements.Find(Element => Element.title == title);
    }

    public IEnumerator timeing(float specalTime)
    {
      done = false;
      yield return new WaitForSeconds (specalTime);
      done = true;
      yield return done;
    }

    public void merge(GameObject target , GameObject target2 , string enemy, string type1 , string type2)
    {
      if (target.GetComponent<enemy_stats>().type == target2.GetComponent<enemy_stats>().weekness) target2.GetComponent<enemy_stats>().hp = 0;
      else if (target.GetComponent<enemy_stats>().weekness == target2.GetComponent<enemy_stats>().type) target2.GetComponent<enemy_stats>().hp = 0;
      else if (type1 == type2){
        if (!target.GetComponent<enemy_stats>().elite || !target2.GetComponent<enemy_stats>().elite) if (target.GetComponent<enemy_stats>().mergeamount + target2.GetComponent<enemy_stats>().mergeamount > 5) return;
        var newThing = enemy_database.instance.SpawnEnemy(enemy, type1, target.transform);
        newThing.GetComponent<enemy_stats>().type = target.GetComponent<enemy_stats>().type;
        newThing.GetComponent<enemy_stats>().mergeamount = target.GetComponent<enemy_stats>().mergeamount + target2.GetComponent<enemy_stats>().mergeamount;
        newThing.name = target.GetComponent<enemy_stats>().type + " " + target.GetComponent<enemy_stats>().Name + " X" + newThing.GetComponent<enemy_stats>().mergeamount;
        Destroy(target);
        Destroy(target2);
      }
    }

    void BuildDatabase()
    {
      Elements = new List<Element>(){
        new Element(0, "null", "the element that conters all mana",
          new Dictionary<string, float>
          {
            {"ColorR", 1},
            {"ColorG", 1},
            {"ColorB", 1},
            {"ColorA", 1},
            {"SpecalTime", 1}
          },
          new Dictionary<string, string>
          {
            {"Weekness", "none"},
            {"Strength", "all"},
            {"Boost", "none"},
            {"Specal", "void"},
            {"ExtraMerge", "none"},
            {"ExtraMergeto", "none"}
        }),
        new Element(1, "poison", "the element that creates or controls things like diseases or poisons",
          new Dictionary<string, float>
          {
            {"ColorR", 0},
            {"ColorG", 0.5f},
            {"ColorB", 0},
            {"ColorA", 1},
            {"SpecalTime", 3}
          },
          new Dictionary<string, string>
          {
            {"Weekness", "plant"},
            {"Strength", "none"},
            {"Boost", "none"},
            {"Specal", "lingering"},
            {"ExtraMerge", "none"},
            {"ExtraMergeto", "none"}
        }),
        new Element(2, "water", "the element that creates or controls things like the lakes or rain",
          new Dictionary<string, float>
          {
            {"ColorR", 0},
            {"ColorG", 0},
            {"ColorB", 1.0f},
            {"ColorA", 1},
            {"SpecalTime", 0}
          },
          new Dictionary<string, string>
          {
            {"Weekness", "none"},
            {"Strength", "fire"},
            {"Boost", "none"},
            {"Specal", "none"},
            {"ExtraMerge", "fire"},
            {"ExtraMergeto", "air"}
        }),
        new Element(3, "fire", "the element that creates or controls things like heat and fire",
          new Dictionary<string, float>
          {
            {"ColorR", 1.0f},
            {"ColorG", 0},
            {"ColorB", 0},
            {"ColorA", 1},
            {"SpecalTime", 2}
          },
          new Dictionary<string, string>
          {
            {"Weekness", "water"},
            {"Strength", "ice"},
            {"Boost", "plant"},
            {"Specal", "lingering"},
            {"ExtraMerge", "fire"},
            {"ExtraMergeto", "air"}
        }),
        new Element(4, "ice", "the element that creates or controls things like heat and fire",
          new Dictionary<string, float>
          {
            {"ColorR", 0},
            {"ColorG", 0.5f},
            {"ColorB", 0.5f},
            {"ColorA", 0.5f},
            {"SpecalTime", 2}
          },
          new Dictionary<string, string>
          {
            {"Weekness", "fire"},
            {"Strength", "plant"},
            {"Boost", "none"},
            {"Specal", "freeze"},
            {"ExtraMerge", "none"},
            {"ExtraMergeto", "none"}
        }),
        new Element(5, "plant", "the element that creates or controls things like vines and plants",
          new Dictionary<string, float>
          {
            {"ColorR", 0},
            {"ColorG", 1.0f},
            {"ColorB", 0},
            {"ColorA", 1},
            {"SpecalTime", 0}
          },
          new Dictionary<string, string>
          {
            {"Weekness", "fire"},
            {"Strength", "none"},
            {"Boost", "water"},
            {"Specal", "none"},
            {"ExtraMerge", "none"},
            {"ExtraMergeto", "none"}
        }),
        new Element(6, "air", "the element that creates or controls things like weather and wind",
          new Dictionary<string, float>
          {
            {"ColorR", 0.5f},
            {"ColorG", 1.0f},
            {"ColorB", 0.5f},
            {"ColorA", 1},
            {"SpecalTime", 0}
          },
          new Dictionary<string, string>
          {
            {"Weekness", "none"},
            {"Strength", "none"},
            {"Boost", "none"},
            {"Specal", "none"},
            {"ExtraMerge", "none"},
            {"ExtraMergeto", "none"}
        }),
        new Element(7, "earth", "the element that creates or controls things like the ground or hills",
          new Dictionary<string, float>
          {
            {"ColorR", 0},
            {"ColorG", 0.3f},
            {"ColorB", 0},
            {"ColorA", 1},
            {"SpecalTime", 0}
          },
          new Dictionary<string, string>
          {
            {"Weekness", "none"},
            {"Strength", "lightning"},
            {"Boost", "none"},
            {"Specal", "none"},
            {"ExtraMerge", "none"},
            {"ExtraMergeto", "none"}
        }),
        new Element(8, "lightning", "the element that creates or controls things like lightning or electricity ",
          new Dictionary<string, float>
          {
            {"ColorR", 1.0f},
            {"ColorG", 1.0f},
            {"ColorB", 0},
            {"ColorA", 1},
            {"SpecalTime", 0}
          },
          new Dictionary<string, string>
          {
            {"Weekness", "none"},
            {"Strength", "none"},
            {"Boost", "water"},
            {"Specal", "none"},
            {"ExtraMerge", "none"},
            {"ExtraMergeto", "none"}
        })
      };
    }

}
