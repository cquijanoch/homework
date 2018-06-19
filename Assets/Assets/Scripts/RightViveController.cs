using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightViveController : MonoBehaviour
{
    public GameObject selectedObject = null;
    public RaycastHit selectedCoordinate; //Stores the PCA coordinate 
    public List<MusicObj> selectedObjects = null;
    private bool firstOfMultipleSelection = true;
    [SerializeField] public Text musicCurrentText;
    [SerializeField] public Text artistCurrentText;
    [SerializeField] public Text genreCurrentText;
    [SerializeField] public Text locationCurrentText;
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


       if(Input.GetMouseButton(1))
       {

            if(Input.GetMouseButton(0))
            {

                if (Physics.Raycast(ray, out hitInfo))
                {
                    GameObject hitObject = hitInfo.transform.root.gameObject;
                    if (hitInfo.transform.name != "Plane")
                    {
                        SelectMultipleObjects(hitObject, hitInfo);
                        firstOfMultipleSelection = false;
                    }
                }

            }
        }
      

        else if (Input.GetMouseButton(0))
        {

            ClearAllSelections();
            if (Physics.Raycast(ray, out hitInfo))
            {
                //Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
                GameObject hitObject = hitInfo.transform.root.gameObject;
                // lr.SetPosition(1, new Vector3(0, 0, hitInfo.distance));

                if (hitInfo.transform.name != "Plane")
                {
                    SelectSingleObject(hitObject, hitInfo);
                    firstOfMultipleSelection = true;
                }
            }
            else
            {
                // lr.SetPosition(1, new Vector3(0, 0, 5000));
                ClearSelection();
            }
        }

     //  else if()

        
    }

    void SelectSingleObject(GameObject obj, RaycastHit point)
    {
        Debug.Log("Objeto selecionado " + point.transform.name);
        
        if (selectedObject != null)
        {

            if (point.transform.name == selectedCoordinate.transform.name)
            {
              
                return;
            }

            ClearSelection();

        }
        selectedObject = obj;
        selectedCoordinate = point;
        
        GameObject r = GameObject.Find(point.transform.name); //this might me slower than the foreach method
        MusicObj musicObj = r.GetComponent<MusicObj>();
        musicObj.GetComponent<Renderer>().material.color = Color.green;
        musicCurrentText.text = musicObj.ColumnTitle;
        artistCurrentText.text = musicObj.ColumnArtistName;
        locationCurrentText.text = musicObj.ColumnLocation;
        genreCurrentText.text = musicObj.ColumnTerms;

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

    void SelectMultipleObjects(GameObject obj, RaycastHit point)
    {

        Debug.Log("Objeto selecionado " + point.transform.name);

        if (firstOfMultipleSelection == true)
            ClearSelection();

        if (selectedObject != null)
        {

            if (point.transform.name == selectedCoordinate.transform.name)
            {
                return;
            }
        }
        selectedObject = obj;
        selectedCoordinate = point;

        GameObject r = GameObject.Find(point.transform.name); //this might me slower than the foreach method
        MusicObj musicObj = r.GetComponent<MusicObj>();
        musicObj.GetComponent<Renderer>().material.color = Color.green;

        selectedObjects.Add(musicObj);

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
                m.color = Color.clear;
                r.material = m;
            }
        }
        selectedObject = null;
        musicCurrentText.text = "";
        artistCurrentText.text = "";
        locationCurrentText.text = "";
        genreCurrentText.text = "";
    }


    public void ClearAllSelections()
    {
        
        foreach (MusicObj obj in selectedObjects)
        {
            obj.GetComponent<Renderer>().material.color = Color.clear;

        }
        ClearSelection();


    }
}
