using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingStarCount : MonoBehaviour
{
    public Text ShootingStarText;

    public int BasketIncount;

    // Update is called once per frame
    void Update()
    {
        ShootingStarText.text = "êØÇÃêî:" + BasketIncount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag==("Star"))
        {
            BasketIncount++;
        }
    }
}
