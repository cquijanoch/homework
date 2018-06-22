using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterplotRotation : MonoBehaviour {

    float rotationSpeed = 20;
    public GameObject obj;
    void OnMouseDrag()
    {

            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
            float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

            transform.RotateAround(Vector3.up, -rotationX);
            transform.RotateAround(Vector3.right, rotationY) ;
            Debug.Log("Achou o mouse");

   
    }
}
