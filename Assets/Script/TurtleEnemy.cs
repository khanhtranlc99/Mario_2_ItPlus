using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleEnemy : MonoBehaviour
{
    public Animator animator;
    public Transform postA;
    public Transform postB;
    bool isAction = false;
    public GameObject shellObj;



    private void Start()
    {
        animator.Play("Move");
        Move();
    }

    private void Move()
    {

        this.transform.localScale = new Vector3(1,1,1);
        this.transform.DOMoveX(postA.transform.position.x, 10).SetEase(Ease.Linear).OnComplete(delegate
        {
            if (postB != null)
            {
                this.transform.localScale = new Vector3(-1, 1, 1);
                this.transform.DOMoveX(postB.transform.position.x, 10).OnComplete(delegate
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
          

                this.transform.DOKill();
                this.transform.position -= new Vector3(0, 0.15f, 0);
                this.gameObject.SetActive(false);
                var shell = Instantiate(shellObj);

                shell.transform.position = this.transform.position;


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
