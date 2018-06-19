using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour {


    void Awake()
    {
       
    }
    void Update()
    {
        transform.eulerAngles = new Vector3(
            0,
            transform.eulerAngles.y,
            0
        );
    }
}
