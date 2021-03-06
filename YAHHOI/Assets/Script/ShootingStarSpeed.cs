using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStarSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float speed = 5f;//飛ばすときの初速度
        float maxSpeedY = -2f;//飛ばすときのY方向の最高速度(大きいほど角度が大きくなる)

        Vector3 vel = new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(-0.5f, 0.5f)).normalized * speed;
        vel.y = maxSpeedY;
        GetComponent<Rigidbody2D>().velocity = vel;
    }
}
