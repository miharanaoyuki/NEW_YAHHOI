using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStarSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float speed = 5f;//”ò‚Î‚·‚Æ‚«‚Ì‰‘¬“x
        float maxSpeedY = -10f;//”ò‚Î‚·‚Æ‚«‚ÌY•ûŒü‚ÌÅ‚‘¬“x(‘å‚«‚¢‚Ù‚ÇŠp“x‚ª‘å‚«‚­‚È‚é)

        Vector3 vel = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized * speed;
        vel.y = maxSpeedY;
        GetComponent<Rigidbody2D>().velocity = vel;
    }
}
