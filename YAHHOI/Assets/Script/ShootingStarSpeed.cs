using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStarSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float speed = 5f;//��΂��Ƃ��̏����x
        float maxSpeedY = -10f;//��΂��Ƃ���Y�����̍ō����x(�傫���قǊp�x���傫���Ȃ�)

        Vector3 vel = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized * speed;
        vel.y = maxSpeedY;
        GetComponent<Rigidbody2D>().velocity = vel;
    }
}
