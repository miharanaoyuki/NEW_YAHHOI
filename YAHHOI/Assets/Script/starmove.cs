using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starmove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-50, -50, 0) * Time.deltaTime;
    }

}