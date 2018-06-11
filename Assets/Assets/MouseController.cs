using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
    GameObject selectedObject;
	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo))
        {

            GameObject hitObject = hitInfo.transform.root.gameObject;
            Debug.Log("Mouse is over: " + hitInfo.collider.name);
            if (hitInfo.collider.name != "Plane")
                SelectObject(hitObject, hitInfo);
                
        }
        else
       {
            ClearSelection();
        }
		
	}

    void SelectObject(GameObject obj, RaycastHit point)
    {


        if (selectedObject != null)
        {
            if (obj == selectedObject)
                return;

            ClearSelection();
        }
        selectedObject = obj;

       Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
      
      
        foreach (Renderer r in rs)
        {
            if (point.transform.name == r.name)
            { 
       
                Material m = r.material;
                m.color = Color.green;
                r.material = m;
            }
        }
        
    }

    void ClearSelection()
    {

        if (selectedObject == null)
            return;
        Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();


        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.white;
            r.material = m;
        }
        selectedObject = null;
    }
}
