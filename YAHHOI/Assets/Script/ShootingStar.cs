using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour
{
    public GameObject ShootingStarPrefab;

    // Update is called once per frame
    void Update()
    {
        // 30�t���[�����ɃV�[���Ƀv���n�u�𐶐�
        if (Time.frameCount % 60 == 0)
        {
            // �v���n�u�̈ʒu�������_���Őݒ�
            float x = Random.Range(-5.0f, 5.0f);
            float y = 5.0f;
            Vector3 pos = new Vector3(x, y, 0.0f);

            // �v���n�u�𐶐�
            GameObject ball = Instantiate(ShootingStarPrefab, pos, Quaternion.identity);

            Destroy(ball, 1.0f);
        }
    }
}

