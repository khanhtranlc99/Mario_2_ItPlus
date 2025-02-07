using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Brick : MonoBehaviour
{
    [SerializeField] SpriteRenderer icon;
    [SerializeField] GameObject gift;
    [SerializeField] Sprite block;
    bool isActive;

    public void CheckBrick()
    {
        if (gift != null)
        {
            if (!isActive)
            {
                isActive = true;
                var temp = Instantiate(gift);
                temp.transform.position = transform.position;
                temp.transform.DOMoveY(transform.position.y + 0.75f, 0.5f);
                icon.sprite = block;
            }

        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogError("");
        }
    }
 
}
