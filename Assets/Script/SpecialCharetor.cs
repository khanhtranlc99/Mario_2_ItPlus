using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCharetor : CharectorBase
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
                Debug.Log("debug.log");
                break;
            case HitType.Enemy:
                GamePlaycontroller.instance.ChangeCharector(CharectorType.Big);
                break;
            case HitType.DieZone:
                Die();
                break;
        }
    }
}
