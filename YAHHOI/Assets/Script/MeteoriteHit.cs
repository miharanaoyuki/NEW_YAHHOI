using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteHit : MonoBehaviour
{
    public GameObject Player;
    PlayerMovement script;

    void Start()
    {
        Player = GameObject.Find("Player");
        script = Player.GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Meteorite") && script.Speed > 0.1f)
        {
            script.Speed -= 0.3f;
            Destroy(collision.gameObject);
        }
    }
}