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


        //ここに処理を書く
        cancer.transform.position = new Vector3(1.0f, 0.0f, 0.0f);

        //星がすべて埋まるまで停止
        yield return new WaitUntil(() =>SignCountSpring.isFirst ==false);
        //yield return new WaitForSeconds(5);
        //ここに再開後の処理を書く
        Destroy(cancer);
        corvus.transform.position = new Vector3(1.0f, 0.0f, 0.0f);
        //停止処理
       // yield return new WaitForSeconds(5);
        //もう一度再開処理
        Destroy(corvus);

    }
}
