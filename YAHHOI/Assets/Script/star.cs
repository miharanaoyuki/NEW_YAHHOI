using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    public GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // 60�t���[�����ɃV�[���Ƀv���n�u�𐶐�
        if (Time.frameCount % 60 == 0)
        {
            //// �v���n�u�̈ʒu�������_���Őݒ�
         //float x = Random.Range(-5.0f, 5.0f);
         //   float y = 5.0f;

            Vector3 pos = new Vector3(0,200, 0.0f);

            // �v���n�u�𐶐�
            GameObject ball = Instantiate(Prefab, pos, Quaternion.identity);

            //3�b��ɍ폜����
            Destroy(ball, 3.0f);
        }
    }
}