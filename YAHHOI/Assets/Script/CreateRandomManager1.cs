using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateRandomManager1 : MonoBehaviour
{

    [SerializeField]
    [Tooltip("��������GameObject")]
    private GameObject createPrefab;
    [SerializeField]
    [Tooltip("��������͈�A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("��������͈�B")]
    private Transform rangeB;

    // �o�ߎ���
    private float time;

    void Start()
    {
        StartCoroutine("ChangeColor");
    }

    IEnumerator ChangeColor()
    {
      
            // �O�t���[������̎��Ԃ����Z���Ă���
            time = time + Time.deltaTime;
        //3�b��~
        yield return new WaitForSeconds(3);

        // ��3�b�u���Ƀ����_���ɐ��������悤�ɂ���B
        if (time > Random.Range(3,7))
            {
                // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float x = Random.Range(rangeA.position.x, rangeB.position.x);
                // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float y = Random.Range(rangeA.position.y, rangeB.position.y);

                //// rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
                //float z = Random.Range(rangeA.position.z, rangeB.position.z);

                // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                GameObject ball = Instantiate(createPrefab, new Vector3(x, y, 0), createPrefab.transform.rotation);

                //// �o�ߎ��ԃ��Z�b�g
                time = 1f;

                ////8�b��ɍ폜����
                Destroy(ball, 8.0f);
               

            }
        }

}