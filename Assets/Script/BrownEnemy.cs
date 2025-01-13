using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BrownEnemy : MonoBehaviour
{
    public Transform postA;
    public Transform postB;
    bool isAction = false;

    private void Start()
    {
        Move();
    }

    private void Move()
    {
 
        this.transform.DOMoveX(postA.transform.position.x, 2).OnComplete(delegate
        {
            this.transform.DOMoveX(postB.transform.position.x, 2).OnComplete(delegate
            {
                Move();

            });

        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Foot")
        {
            if (!isAction)
            {
                isAction = true;
              
                Destroy(this.gameObject);
            }


        }

        if (collision.gameObject.tag == "Player")
        {
            if (!isAction)
            {
                isAction = true;
                GamePlaycontroller.instance.currentCharector.Hit(HitType.Enemy);
                Destroy(this.gameObject);
            }


        }
    }
}
