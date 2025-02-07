using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunEnemy : MonoBehaviour
{
    bool isAction = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            if (!isAction)
            {
                isAction = true;
            
               

                if (GamePlaycontroller.instance.currentCharector.CharectorType == CharectorType.Small)
                {
                    Debug.LogError("Lose");
                }
                else
                {
                    GamePlaycontroller.instance.currentCharector.Hit(HitType.Enemy);
                }
                 
                Destroy(this.gameObject);
            }


        }
    }
    
}
