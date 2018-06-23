using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterplotRotation : MonoBehaviour {

  //  FirstPersonController FPS;
    float rotationSpeed = 20;
    public GameObject obj;

    private void Start()
    {
        obj = transform.parent.gameObject;
    }
    void OnMouseDrag()
    {

          float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
          float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        obj.transform.RotateAround(Vector3.up, rotationX);
        obj.transform.RotateAround(Vector3.right, rotationY) ;
        

        // obj.transform.Rotate(Vector3.up, -rotationX);
        //obj.transform.Rotate(Vector3.right, rotationY);
        //Debug.Log("Achou o mouse");

   
    }
}
