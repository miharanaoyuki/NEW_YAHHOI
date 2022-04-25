using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingStarCount : MonoBehaviour
{
    public Text ShootingStarText;

    public static int BasketIncount;

    public GameObject Player;
    PlayerMovement script;

    void Start()
    {
        Player = GameObject.Find("Player");
        script = Player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootingStarText.text = "êØÇÃêî:" + BasketIncount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Star"))
        {
            BasketIncount++;
            script.Speed -= 0.05f;
            Destroy(collision.gameObject);
        }
    }

    public static int StarCount()
    {
        return BasketIncount;
    }
}
