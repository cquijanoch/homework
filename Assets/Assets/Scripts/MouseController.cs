using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseController : MonoBehaviour
{
    GameObject selectedObject;
    RaycastHit selectedCoordinate; //Stores the PCA coordinate 
    //private LineRenderer lr;
    // Use this for initialization
    void Start()
    {
       // lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        //Debug.DrawRay(ray.origin, ray.direction, Color.red, 1000, false);

        if (Input.GetMouseButton(0))
        {

            if (Physics.Raycast(ray, out hitInfo) )
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
                GameObject hitObject = hitInfo.transform.root.gameObject;
                // lr.SetPosition(1, new Vector3(0, 0, hitInfo.distance));

                if(hitInfo.transform.name != "Plane")
                    SelectObject(hitObject, hitInfo);

            }
            else
            {
                // lr.SetPosition(1, new Vector3(0, 0, 5000));
                ClearSelection();
            }
        }

        
    }

    void SelectObject(GameObject obj, RaycastHit point)
    {
        Debug.Log("Objeto selecionado " + point.transform.name);

        if (selectedObject != null)
        {
            if (point.transform.name == selectedCoordinate.transform.name)
                return;

            ClearSelection();
        }
        selectedObject = obj;
        selectedCoordinate = point;
        
        GameObject r = GameObject.Find(point.transform.name);
        MusicObj musicObj = r.GetComponent<MusicObj>();
        musicObj.GetComponent<Renderer>().material.color = Color.green;


        //Material m = rs[0].material;
        //m.color = Color.green;
        //rs[0].material = m;

        //foreach (Renderer r in rs)
        //{
        //    //    Debug.Log("Obj anterior " + r.name + "Obj atual: " + point.transform.name);

        //    if (point.transform.name == r.name)
        //    {

        //        Material m = r.material;
        //        m.color = Color.green;
        //        r.material = m;
        //    }
        //}

    }

    void ClearSelection()
    {

        if (selectedObject == null)
            return;
        Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();


        foreach (Renderer r in rs)
        {

            if (selectedCoordinate.transform.name == r.name)
            {
                Material m = r.material;
                m.color = Color.white;
                r.material = m;
            }
        }
        selectedObject = null;
        //selectedCoordinate = null;
    }
}
