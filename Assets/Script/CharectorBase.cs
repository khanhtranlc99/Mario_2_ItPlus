using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ActionType
{
    Left,
    Right, 
    Jump
}
public enum HitType
{
    RedMusrom,
    GreenMusrom,
    Star,
    Flower,
    Enemy,
    Brick,
    DieZone
}

public abstract class CharectorBase : MonoBehaviour
{
    public CharectorType CharectorType;
    public Animator animator;
    public SpriteRenderer spriteRender;
    public Rigidbody2D rigidbody2D;
    public float jumpForce;
    public float speed;
    public bool groundCheck;
  
    public abstract void Init();
    public abstract void Hit(HitType hitType);
    public virtual void Die()
    {
        GamePlaycontroller.instance.ChangeCharector(CharectorType.Small);
        GamePlaycontroller.instance.HandleSetCurrentToFirstPossition();
    }

    public bool isLeft;
    public bool isRight;

    private void Update()
    {
#if UNITY_ANDROID
        if (isLeft)
        {
            Move(ActionType.Left);
        }
        if (isRight)
        {
            Move(ActionType.Right);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move(ActionType.Jump);
        }

        if (!isLeft && !isRight)
        {
            if (groundCheck) // cham dat
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Jump");
            }
        }
        if (!groundCheck)
        {
            animator.Play("Jump");
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                spriteRender.transform.localScale = new Vector3(-1, 1, 1);
                rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                spriteRender.transform.localScale = new Vector3(1, 1, 1);
                rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
            }

        }
#elif UNITY_STANDALONE_WIN
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(ActionType.Left);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(ActionType.Right);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move(ActionType.Jump);
        }

        if (!Input.anyKey)
        {
            if (groundCheck) // cham dat
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Jump");
            }
        }
        if (!groundCheck)
        {
            animator.Play("Jump");
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                spriteRender.transform.localScale = new Vector3(-1, 1, 1);
                rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                spriteRender.transform.localScale = new Vector3(1, 1, 1);
                rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
            }

        }
#endif



    }

    public virtual void Move(ActionType actionTypeParam)
    {
        if(!groundCheck)
        {
            return;
        }
       
        switch (actionTypeParam)
        {
            case ActionType.Left:
              
                    rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y) ;
                    spriteRender.transform.localScale = new Vector3(-1, 1, 1);
                if(groundCheck)
                {
                    animator.Play("Move");
                }
                else
                {
                    animator.Play("Jump");
                }
                  
             
                break;
            case ActionType.Right:
                rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y) ;
                spriteRender.transform.localScale = new Vector3(1, 1, 1);
                if (groundCheck)
                {
                    animator.Play("Move");
                }
                else
                {
                    animator.Play("Jump");
                }
                break;
            case ActionType.Jump:

                    animator.Play("Jump");
                    rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, 2 * jumpForce), ForceMode2D.Impulse     );
                   
               
                break;

        }    


    }    

}
