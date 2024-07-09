using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    float wait = 0.3f;
    public GameObject FallingObject;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fall", wait, wait);
    }

    // Update is called once per frame
    void Fall()
    { 
        Instantiate (FallingObject, new Vector3(Random.Range(-10, 10), 10, 0), Quaternion.identity);
    }
}
