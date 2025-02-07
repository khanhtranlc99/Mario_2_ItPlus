using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ShellObj : MonoBehaviour
{
   [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    float coolDownTime = 3;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Foot" )
        {
            var temp = collision.gameObject.transform.position;

            if (temp.x < transform.position.x)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                Debug.LogError("left");
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                Debug.LogError("right");
            }
            StartCoroutine(countCoolDown());

        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogError(collision.gameObject.name);
        if (collision.gameObject.tag == "Pile")
        {
            var temp = collision.gameObject.transform.position;

            if (temp.x < transform.position.x)
            {
                rb.velocity = new Vector2(speed, 0);
                Debug.LogError("left");
            }
            else
            {
                rb.velocity = new Vector2(-speed,0);
                Debug.LogError("right");
            }

     
        }

        if (collision.gameObject.tag == "Player")
        {  
            if(coolDownTime == 3)
            {
                GamePlaycontroller.instance.currentCharector.Hit(HitType.Enemy);
            }
           
        }
    }
 
    public void OnCollisionExit2D(Collision2D collision)
    {
        Debug.LogError(collision.gameObject.name);
        if (collision.gameObject.tag == "GroundTile")
        {

            rb.constraints = RigidbodyConstraints2D.None;
            
        }

       
        
    }

    private IEnumerator countCoolDown()
    {
        coolDownTime -= 1;
        yield return new WaitForSeconds(1);
       if(coolDownTime >0)
        {
            StartCoroutine(countCoolDown());
        }
       else
        {
            coolDownTime = 3;
        }
    }
}
