using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diezone : MonoBehaviour
{
    bool isAction = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isAction)
            {
                isAction = true;
                GamePlaycontroller.instance.currentCharector.Hit(HitType.DieZone);
           
            }


        }
    }
}
