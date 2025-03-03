using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BrownEnemy : MonoBehaviour
{
    public Transform postA;
    public Transform postB;
    bool isAction = false;

    public SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public Sprite diaSprite;


    private void Start()
    {
        spriteRenderer.sprite = normalSprite;
        Move();
    }

    private void Move()
    {
 
        this.transform.DOMoveX(postA.transform.position.x, 10).SetEase(Ease.Linear).OnComplete(delegate
        {
            if(postB != null)
            {
                this.transform.DOMoveX(postB.transform.position.x, 4).OnComplete(delegate
                {
                    Move();

                });
            }
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Foot")
        {
            if (!isAction)
            {
                isAction = true;
                spriteRenderer.sprite = diaSprite;
              
                this.transform.DOKill();
                this.transform.position -= new Vector3(0, 0.25f, 0);
                //Destroy(this.gameObject);
            }


        }

        if (collision.gameObject.tag == "Player")
        {
            if (!isAction)
            {
                isAction = true;
                GamePlaycontroller.instance.currentCharector.Hit(HitType.Enemy);
               
            }


        }
    }
}
