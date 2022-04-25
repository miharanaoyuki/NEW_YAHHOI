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


        //‚±‚±‚Éˆ—‚ğ‘‚­
        cancer.transform.position = new Vector3(1.0f, 0.0f, 0.0f);

        //¯‚ª‚·‚×‚Ä–„‚Ü‚é‚Ü‚Å’â~
        yield return new WaitUntil(() =>SignCountSpring.isFirst ==false);
        //yield return new WaitForSeconds(5);
        //‚±‚±‚ÉÄŠJŒã‚Ìˆ—‚ğ‘‚­
        Destroy(cancer);
        corvus.transform.position = new Vector3(1.0f, 0.0f, 0.0f);
        //’â~ˆ—
       // yield return new WaitForSeconds(5);
        //‚à‚¤ˆê“xÄŠJˆ—
        Destroy(corvus);

    }
}
