using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotetion : MonoBehaviour
{
    void Update()
    {
        // �X�e�B�b�N���͊p�x�擾(��)
        var h = Input.GetAxis("R_Horizontal");
        // �X�e�B�b�N���͊p�x�擾(�c)
        var v = Input.GetAxis("R_Vertical");
        // �������ł����p�x(�x���@)
        float radian = Mathf.Atan2(-v, h) * Mathf.Rad2Deg;
        // z���ɐ������ł����p�x������]
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radian);
    }
}
