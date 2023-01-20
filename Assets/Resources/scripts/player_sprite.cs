using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_sprite : MonoBehaviour
{
  public SpriteRenderer AnimatorObject;
  public SpriteRenderer SmallAnimatorObject;
  public SpriteRenderer AnimatorObjectMaid;
  public SpriteRenderer SmallAnimatorObjectMaid;
  public SpriteRenderer spriteRenderer;
  public bool small;
  public bool maid;
  public Sprite Front;
  public Sprite Right;
  public Sprite Left;
  public Sprite SmallFront;
  public Sprite SmallRight;
  public Sprite SmallLeft;
  public Sprite FrontMaid;
  public Sprite RightMaid;
  public Sprite LeftMaid;
  public Sprite SmallFrontMaid;
  public Sprite SmallRightMaid;
  public Sprite SmallLeftMaid;


    public void showWalk()
    {
      if(maid){
        if (small){
          SmallAnimatorObjectMaid.enabled = true;
          spriteRenderer.enabled = false;
        }else{
          AnimatorObjectMaid.enabled = true;
          spriteRenderer.enabled = false;
        }
      }else{
        if (small){
          SmallAnimatorObject.enabled = true;
          spriteRenderer.enabled = false;
        }else{
          AnimatorObject.enabled = true;
          spriteRenderer.enabled = false;
        }
      }
    }

    public void hideWalk()
    {
      if(maid){
        if (small){
          SmallAnimatorObjectMaid.enabled = false;
          spriteRenderer.enabled = true;
        }else{
          AnimatorObjectMaid.enabled = false;
          spriteRenderer.enabled = true;
        }
      }else{
        if (small){
          SmallAnimatorObject.enabled = false;
          spriteRenderer.enabled = true;
        }else{
          AnimatorObject.enabled = false;
          spriteRenderer.enabled = true;
        }
      }
    }

    public void faceFront()
    {
      if(maid){
        if (small){
          spriteRenderer.sprite = SmallFrontMaid;
        }else{
          spriteRenderer.sprite = FrontMaid;
        }
      }else{
        if (small){
          SmallAnimatorObject.enabled = false;
          spriteRenderer.enabled = true;
        }else{
          AnimatorObject.enabled = false;
          spriteRenderer.enabled = true;
        }
      }
    }

    public void faceRight()
    {
      if(maid){
        if (small){
          spriteRenderer.sprite = SmallRightMaid;
          SmallAnimatorObjectMaid.transform.eulerAngles = new Vector3 (0, 0, 0);
        }else{
          spriteRenderer.sprite = RightMaid;
          AnimatorObjectMaid.transform.eulerAngles = new Vector3 (0, 0, 0);
        }
      }else{
        if (small){
          spriteRenderer.sprite = SmallRight;
          SmallAnimatorObject.transform.eulerAngles = new Vector3 (0, 0, 0);
        }else{
          spriteRenderer.sprite = Right;
          AnimatorObject.transform.eulerAngles = new Vector3 (0, 0, 0);
        }
      }
    }

    public void faceLeft()
    {
      if(maid){
        if (small){
          spriteRenderer.sprite = SmallLeftMaid;
          SmallAnimatorObjectMaid.transform.eulerAngles = new Vector3 (0, 180, 0);
        }else{
          spriteRenderer.sprite = LeftMaid;
          AnimatorObjectMaid.transform.eulerAngles = new Vector3 (0, 180, 0);
        }
      }else{
        if (small){
          spriteRenderer.sprite = SmallLeft;
          SmallAnimatorObject.transform.eulerAngles = new Vector3 (0, 180, 0);
        }else{
          spriteRenderer.sprite = Left;
          AnimatorObject.transform.eulerAngles = new Vector3 (0, 180, 0);
        }
      }
    }
}
