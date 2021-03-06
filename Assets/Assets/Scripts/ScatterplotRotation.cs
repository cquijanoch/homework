﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.EventSystems;

public class ScatterplotRotation : MonoBehaviour, IPointerClickHandler
{

    public GameObject myFPS;
    public GameObject myPivot;
    public GameObject myHolder;
    public GameObject myDataPlotter;
    public GameObject myMouseController;
    public GameObject myTaskGuide;
    public TaskGuide TaskGuideScript;
    public FirstPersonController myFPSControllerScript;
    public MouseController mouseControllerScript;
    float rotationSpeed = 20;
    public GameObject obj;
    float rotationX;
    float rotationY;

    private void Start()
    {
        myHolder = transform.parent.gameObject;
        myFPS = GameObject.Find("FPSController");
        myPivot = GameObject.Find("Pivot");
        //  myMouseController = GameObject.Find("Mouse Controller");
        myFPSControllerScript = myFPS.GetComponent<FirstPersonController>();
       // myTaskGuide = GameObject.Find("Task Guide");
        //TaskGuideScript = myTaskGuide.GetComponent<TaskGuide>();
        // mouseControllerScript = myMouseController.GetComponent<MouseController>();


    }
    private void Update()
    {
        //if (Input.GetMouseButtonUp(0))
          //  myFPSControllerScript.useMouseLook = true;

        /*   if (Input.GetMouseButton(2))
           {
               rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
               rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

               obj.transform.RotateAround(Vector3.down, rotationX);
               obj.transform.RotateAround(Vector3.right, rotationY);
               Debug.Log("Button 2 down");
           }*/
    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("click");
        if (eventData.clickCount == 2)
        {
            UnityEngine.Debug.Log("double click");
        }
    }

    void OnMouseDrag()
    {

        //if (TaskGuideScript.VR == false)
        //{
            myFPSControllerScript.useMouseLook = false;
            /*
              float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
              float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

             obj.transform.RotateAround(Vector3.down, rotationX);
             obj.transform.RotateAround(Vector3.right, rotationY) ;
             //myFPSControllerScript.useMouseLook = true; 

             // obj.transform.Rotate(Vector3.up, -rotationX);
             //obj.transform.Rotate(Vector3.right, rotationY);
             //Debug.Log("Achou o mouse");
             */
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;
            myPivot.transform.position = transform.position;

            myHolder.transform.parent = myPivot.transform;

            myPivot.transform.RotateAround(Camera.main.transform.up, -rotX);
            myPivot.transform.RotateAround(Camera.main.transform.right, rotY);
        //}

    }

    void OnMouseUp()
    {
        myHolder.transform.parent = null;
        myFPSControllerScript.useMouseLook = true;
    }
}
