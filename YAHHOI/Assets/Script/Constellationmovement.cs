using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellationmovement : MonoBehaviour
{
   
    public GameObject cancer;
    public GameObject corvus;
    public GameObject crater;
    public GameObject leominor;
    public GameObject leo;
    public GameObject ursaminor;
    public GameObject ursamajor;
    public GameObject virgo;

    void Start()
    {
        StartCoroutine("Constellationsmovement");

    }

    IEnumerator Constellationsmovement()
    {


        //�����ɏ���������
        cancer.transform.position = new Vector3(1.0f, 0.0f, 0.0f);

        //�������ׂĖ��܂�܂Œ�~
        yield return new WaitUntil(() =>SignCountSpring.isFirst ==false);
        //yield return new WaitForSeconds(5);
        //�����ɍĊJ��̏���������
        Destroy(cancer);
        corvus.transform.position = new Vector3(1.0f, 0.0f, 0.0f);
        //��~����
       // yield return new WaitForSeconds(5);
        //������x�ĊJ����
        Destroy(corvus);

    }
}
