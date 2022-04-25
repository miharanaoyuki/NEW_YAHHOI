using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject StarPrefab; // 星プレハブ
    Shot shot; // Shotスクリプト

    void Start()
    {
        Instantiate(StarPrefab, transform.position, Quaternion.identity);
        shot = StarPrefab.GetComponent<Shot>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");//x軸方向移動の設定

        transform.position += new Vector3(x, 0, 0) * Time.deltaTime * 4.0f;//移動
    }

    public void Clone()
    {
        Instantiate(StarPrefab, transform.position, Quaternion.identity);
    }
}
