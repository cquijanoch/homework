using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MouseController : MonoBehaviour
{

    DataPlotter dpScript;
    public GameObject myPlotter;
    GameObject selectedObject;
    RaycastHit selectedCoordinate; //Stores the PCA coordinate 
    private LineRenderer lr;
    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        dpScript = myPlotter.GetComponent<DataPlotter>();

    }

    // Update is called once per frame
    void Update()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 1000, false);
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject hitObject = hitInfo.transform.root.gameObject;
            lr.SetPosition(1, new Vector3(0, 0, hitInfo.distance));
            if (hitInfo.collider.name != "Plane" && Input.GetMouseButton(0))
            {
                // Debug.Log("Mouse is over: " + hitInfo.collider.name);
                SelectObject(hitObject, hitInfo);
            }
        }
        else
        {
            lr.SetPosition(1, new Vector3(0, 0, 5000));
            ClearSelection();
        }
    }

    void SelectObject(GameObject obj, RaycastHit point)
    {
        int i = 0;
        Dictionary<string, object> selectedPoint;
        Debug.Log("Objeto selecionado " + point.transform.name);

        if (selectedObject != null)
        {
            if (point.transform.name == selectedCoordinate.transform.name)
                return;

            ClearSelection();
        }
        selectedObject = obj;
        selectedCoordinate = point;

        Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
        //   GameObject r = GameObject.Find(point.transform.name);

        
        foreach (Renderer r in rs)
        {
            //    Debug.Log("Obj anterior " + r.name + "Obj atual: " + point.transform.name);

            if (point.transform.name == r.name)
            {

                Material m = r.material;
                m.color = Color.green;
                r.material = m;
                selectedPoint = dpScript.pointList.ElementAt(i);

                Debug.Log(selectedPoint["artist.name"]);
                Debug.Log("index: " + i);
                break;
            }
            i++;
        }

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
