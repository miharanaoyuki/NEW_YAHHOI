using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject StarPrefab; // ���v���n�u
    Shot shot; // Shot�X�N���v�g
    public int Star = 0;

    void Start()
    {
        Star = ShootingStarCount.StarCount();
        Instantiate(StarPrefab, new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
        shot = StarPrefab.GetComponent<Shot>();
        Star--;
    }

    void Update()
    {

    }

    public void Clone()
    {
        Instantiate(StarPrefab, new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
        Star--;
    }
}