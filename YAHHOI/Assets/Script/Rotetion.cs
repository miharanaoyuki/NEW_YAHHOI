using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotetion : MonoBehaviour
{
    void Update()
    {
        // スティック入力角度取得(横)
        var h = Input.GetAxis("R_Horizontal");
        // スティック入力角度取得(縦)
        var v = Input.GetAxis("R_Vertical");
        // 星が飛んでいく角度(度数法)
        float radian = Mathf.Atan2(-v, h) * Mathf.Rad2Deg;
        // z軸に星が飛んでいく角度だけ回転
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radian);
    }
}
