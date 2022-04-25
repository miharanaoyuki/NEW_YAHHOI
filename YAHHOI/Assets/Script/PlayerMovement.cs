using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim = null;
    //↓Animatorのインスタンスを取得
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    [SerializeField] Transform CenterOfBalance;  // 重心
    public float Speed = 3.0f; // 移動速度
    void Update()
    {
         //右に進む
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position =
                transform.position +
                (transform.right * Speed * Time.deltaTime);
            //走るアニメーション
            transform.localScale = new Vector3(-0.17f, 0.17f, 1);//方向

            anim.SetBool("run", true);//アニメーション
        }
        //左に進む
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position =
                transform.position -
                (transform.right * Speed * Time.deltaTime);
            //走るアニメーション
            transform.localScale = new Vector3(0.17f, 0.17f, 1);//方向
            anim.SetBool("run", true);//アニメーション
        }
        //止まっている
        else
        {
            anim.SetBool("run", false);//runアニメーションが終わる
        }

        //光線を引く
        RaycastHit2D hit = Physics2D.Raycast(
                    CenterOfBalance.position,
                    -transform.up, 
                    float.PositiveInfinity);

        // Transformの真下の地形の法線を調べる
        if (hit.collider != null) 
        {
            string name = hit.collider.gameObject.name; // 衝突した相手オブジェクトの名前を取得

            if (name == "Earth (1)")
            {
                // 傾きの差を求める
                Quaternion q = Quaternion.FromToRotation(
                            transform.up,
                            hit.normal);

                // 自分を回転させる
                transform.rotation *= q;

                //地面から一定距離離れていたら落下
                if (hit.distance > 0.05f)
                {
                    transform.position =
                        transform.position +
                        (-transform.up * Physics2D.gravity.magnitude * Time.deltaTime);
                }
            }
        }
    }
}