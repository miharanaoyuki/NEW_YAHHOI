using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject StarPrefab; // ���v���n�u
    Shot shot; // Shot�X�N���v�g

    void Start()
    {
        Instantiate(StarPrefab, transform.position, Quaternion.identity);
        shot = StarPrefab.GetComponent<Shot>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");//x�������ړ��̐ݒ�

        transform.position += new Vector3(x, 0, 0) * Time.deltaTime * 4.0f;//�ړ�
    }

    public void Clone()
    {
        Instantiate(StarPrefab, transform.position, Quaternion.identity);
    }
}
