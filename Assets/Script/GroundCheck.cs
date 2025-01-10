using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public CharectorBase charector;
    private void OnTriggerStay2D(Collider2D collision)
    {
        charector.groundCheck = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        charector.groundCheck = false;
    }

}
