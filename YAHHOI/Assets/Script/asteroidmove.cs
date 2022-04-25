using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidmove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-100, -100, 0) * Time.deltaTime;
    }

}