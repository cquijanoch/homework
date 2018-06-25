using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ScatterplotRotation : MonoBehaviour {

    public GameObject myFPS;
    public FirstPersonController myFPSControllerScript;
    
    float rotationSpeed = 20;
    public GameObject obj;



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


    }



    void OnMouseDrag()
    {
          myFPSControllerScript.useMouseLook = false;
          float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
          float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        obj.transform.RotateAround(Vector3.up, rotationX);
        obj.transform.RotateAround(Vector3.right, rotationY) ;
        //myFPSControllerScript.useMouseLook = true;


        // obj.transform.Rotate(Vector3.up, -rotationX);
        //obj.transform.Rotate(Vector3.right, rotationY);
        //Debug.Log("Achou o mouse");


    }

}
