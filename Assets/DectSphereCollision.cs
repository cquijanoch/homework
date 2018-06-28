using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectSphereCollision : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.SetActive(false);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.SetActive(true);
        }
    }
}
