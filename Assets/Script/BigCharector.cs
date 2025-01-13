using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCharector : CharectorBase
{


    public override void Init()
    {

    }
    public override void Hit(HitType hitType)
    {
        switch (hitType)
        {
            case HitType.RedMusrom:
                Debug.Log("debug.log");
                break;
            case HitType.Flower:
                GamePlaycontroller.instance.ChangeCharector(CharectorType.Special);
                break;
            case HitType.Enemy:
                GamePlaycontroller.instance.ChangeCharector(CharectorType.Small);
                break;
            case HitType.DieZone:
                Die();
                break;


        }
    }
    
}
