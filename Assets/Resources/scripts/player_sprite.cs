using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_sprite : MonoBehaviour
{
  public SpriteRenderer AnimatorObject;
  public SpriteRenderer SmallAnimatorObject;
  public SpriteRenderer spriteRenderer;
  public bool small;
  public Sprite Front;
  public Sprite Right;
  public Sprite Left;
  public Sprite SmallFront;
  public Sprite SmallRight;
  public Sprite SmallLeft;

    public void showWalk()
    {
      if (small){
        SmallAnimatorObject.enabled = true;
        spriteRenderer.enabled = false;
      }else{
        AnimatorObject.enabled = true;
        spriteRenderer.enabled = false;
      }
    }

    public void hideWalk()
    {
      if (small){
        SmallAnimatorObject.enabled = false;
        spriteRenderer.enabled = true;
      }else{
        AnimatorObject.enabled = false;
        spriteRenderer.enabled = true;
      }
    }

    public void faceFront()
    {
      if (small){
        spriteRenderer.sprite = SmallFront;
      }else{
        spriteRenderer.sprite = Front;
      }
    }

    public void faceRight()
    {
      if (small){
        spriteRenderer.sprite = SmallRight;
        SmallAnimatorObject.transform.eulerAngles = new Vector3 (0, 0, 0);
      }else{
        spriteRenderer.sprite = Right;
        AnimatorObject.transform.eulerAngles = new Vector3 (0, 0, 0);
      }
    }

    public void faceLeft()
    {
      if (small){
        spriteRenderer.sprite = SmallLeft;
        SmallAnimatorObject.transform.eulerAngles = new Vector3 (0, 180, 0);
      }else{
        spriteRenderer.sprite = Left;
        AnimatorObject.transform.eulerAngles = new Vector3 (0, 180, 0);
      }
    }
}
