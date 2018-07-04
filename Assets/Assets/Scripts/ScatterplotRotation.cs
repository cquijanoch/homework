using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ScatterplotRotation : MonoBehaviour {

    public GameObject myFPS;
    public GameObject myPivot;
    public FirstPersonController myFPSControllerScript;
    
    float rotationSpeed = 20;
    public GameObject obj;
    float rotationX;
    float rotationY;

    private void Start()
    {
        obj = transform.parent.gameObject;
        myFPS = GameObject.Find("FPSController");
        myFPSControllerScript = myFPS.GetComponent<FirstPersonController>();


    }
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
            myFPSControllerScript.useMouseLook = true;

     /*   if (Input.GetMouseButton(2))
        {
            rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
            rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

            obj.transform.RotateAround(Vector3.down, rotationX);
            obj.transform.RotateAround(Vector3.right, rotationY);
            Debug.Log("Button 2 down");
        }*/
    }

    void OnMouseDrag()
    {
       // myPivot = GameObject.Find("PointHolderPivot"); //might be slow
        myFPSControllerScript.useMouseLook = false;
        //myPivot = 
         float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
         float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        obj.transform.RotateAround(Vector3.down, rotationX);
        obj.transform.RotateAround(Vector3.right, rotationY) ;
        //myFPSControllerScript.useMouseLook = true; 

        // obj.transform.Rotate(Vector3.up, -rotationX);
        //obj.transform.Rotate(Vector3.right, rotationY);
        //Debug.Log("Achou o mouse");


    }

}
