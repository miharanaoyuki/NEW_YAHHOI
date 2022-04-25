using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_dontdes : MonoBehaviour
{
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

   
}
