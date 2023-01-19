using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blob_controler : MonoBehaviour
{
public GameObject blob;
public enemy_stats stats;
public Rigidbody2D blobRigidbody;
public Animator blobAnimator;
public SpriteRenderer blobAnimatorObject;
public SpriteRenderer spriteRenderer;
public Sprite ballSprite;
public Collider2D ballHitbox;
public Sprite blobSprite;
public Collider2D blobHitbox;
public float tfTime = 1f;
public bool flip = false;
public bool moving = false;
public bool mode = false;
public int canbig;
public bool loop = true;
Color color;
float ColorR;
float ColorG;
float ColorB;
float ColorA;

// Start is called before the first frame update
    void Start()
      {
        Element Type = type_database.instance.GetElement(stats.type);
        foreach(KeyValuePair<string,float> type in Type.stats){
          if (type.Key == "ColorR") this.ColorR = type.Value;
          if (type.Key == "ColorG") this.ColorG = type.Value;
          if (type.Key == "ColorB") this.ColorB = type.Value;
          if (type.Key == "ColorA") this.ColorA = type.Value;
        }
        color = new Color(ColorR, ColorG, ColorB, ColorA);
          spriteRenderer.color = color;
          blobAnimatorObject.color = color;
          if (stats.type != "physical") stats.magicDamege = 2;
          stats.hp = stats.hp * stats.mergeamount;
          stats.maxHp = stats.maxHp * stats.mergeamount;
          stats.damege = stats.damege * stats.mergeamount;
          stats.magicDamege = stats.magicDamege * stats.mergeamount;
          gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * stats.mergeamount, gameObject.transform.localScale.y * stats.mergeamount);
      }

    IEnumerator SetMoving()
      {
        mode = true;
        spriteRenderer.enabled = false;
        spriteRenderer.sprite = ballSprite;
        blobAnimatorObject.enabled = true;
        blobAnimator.SetTrigger("ball-tf");
        ballHitbox.enabled = true;
        blobHitbox.enabled = false;
        yield return new WaitForSeconds (tfTime);
        spriteRenderer.enabled = true;
        blobAnimatorObject.enabled = false;
      }

      IEnumerator setStanding()
      {
        mode = false;
        spriteRenderer.enabled = false;
        spriteRenderer.sprite = blobSprite;
        blobAnimatorObject.enabled = true;
        blobAnimator.SetTrigger("blob-tf");
        ballHitbox.enabled = false;
        blobHitbox.enabled = true;
        yield return new WaitForSeconds (tfTime);
        spriteRenderer.enabled = true;
        blobAnimatorObject.enabled = false;
      }
    // Update is called once per frame
    void Update()
      {
        if (moving == true) if (mode == false) StartCoroutine(SetMoving());
        if (moving == false) if (mode == true) StartCoroutine(setStanding());
      }


      void CanBig(GameObject target)
      {
        canbig = Random.Range(0 , 2);
        Debug.Log(canbig);
          if (canbig == 0) if (target.GetComponent<blob_controler>().canbig == 1) type_database.instance.merge(gameObject, target, "blob", stats.type, target.GetComponent<enemy_stats>().type);
          else if (canbig == 1)type_database.instance.merge(target, gameObject, "blob", target.GetComponent<enemy_stats>().type, stats.type);
          else CanBig(target);
      }

    void OnCollisionEnter2D(Collision2D collision)
      {
        if (collision.gameObject.tag != "Ground") flip = !flip;
        if (collision.gameObject.tag == "Enemy") {
          enemy_controler.instance.tryMerge(gameObject, collision.gameObject);
          // CanBig(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player")){
          if (stats.stuned != true){
            StartCoroutine(stats.stun());
          }
          }
      }

      void FixedUpdate()
      {
        if (stats.stuned == false){
        moving = true;
          if (flip == true){
            blobRigidbody.velocity = new Vector2 (+stats.moveSpead, blobRigidbody.velocity.y);
          }else {
            blobRigidbody.velocity = new Vector2 (-stats.moveSpead, blobRigidbody.velocity.y);
          }
        }else{
          moving = false;
        }
      }
}
