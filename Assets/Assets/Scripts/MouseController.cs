using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseController : MonoBehaviour
{
    public GameObject selectedObject = null;
    public GameObject myTaskManager;
    public GameObject hitObject;
    TaskGuide myTaskGuideScript;
    public bool isSelected;
    public RaycastHit selectedCoordinate; //Stores the PCA coordinate 
    public List<MusicObj> selectedObjects = null;
    private bool firstOfMultipleSelection = true;
    [SerializeField] public Text musicCurrentText;
    [SerializeField] public Text artistCurrentText;
    [SerializeField] public Text genreCurrentText;
    //[SerializeField] public Text locationCurrentText;
    //[SerializeField] public Text familiarityCurrentText;
    //[SerializeField] public Text artistHotnessCurrentText;
    //[SerializeField] public Text tempoCurrentText;
    [SerializeField] public Text durationCurrentText;
    string specifier = "G";
    private int fingerID = -1;


    //private LineRenderer lr;

    private void Awake()
    {
        #if !UNITY_EDITOR
             fingerID = 0; 
        #endif
    }

    // Use this for initialization
    void Start()
    {
        // lr = GetComponent<LineRenderer>();
        myTaskGuideScript = myTaskManager.GetComponent<TaskGuide>();
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        //Debug.DrawRay(ray.origin, ray.direction, Color.red, 1000, false);
        if (EventSystem.current.IsPointerOverGameObject(fingerID))    // is the touch on the GUI
        {
            // GUI Action
            return;
        }
        /*Selecting multiple points*/
        if (Input.GetMouseButton(1)) // secondary (right)
       {
            if(Input.GetMouseButtonUp(0)) //primary (left)
            {
                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
                {
                    
                    hitObject = hitInfo.transform.root.gameObject;
                    if (hitInfo.transform.name != "Plane")
                    {

                        SelectMultipleObjects(hitObject, hitInfo);
                        myTaskGuideScript.CountMultipleSelection();
                        firstOfMultipleSelection = false;
                    }
                }
            }
        }

        /*Selecting one point*/

        else if (Input.GetMouseButtonUp(0))
        {
            ClearAllSelections();
            if (Physics.Raycast(ray, out hitInfo , Mathf.Infinity))
            {
                hitObject = hitInfo.transform.root.gameObject;
                if (hitInfo.transform.name != "Plane")
                {
                    myTaskGuideScript.CountSingleSelection();
                    SelectSingleObject(hitObject, hitInfo);
                    firstOfMultipleSelection = true;
                }
            }
            else
            {
                ClearSelection();
            }
        }

        /*Double clicking on the point*/
    }

    void SelectSingleObject(GameObject obj, RaycastHit point)
    {
        if (selectedObject != null)
        {
            isSelected = true;
            if (point.transform.name == selectedCoordinate.transform.name)
            {
              
                return;
            }

            ClearSelection();

        }
        selectedObject = obj;
        selectedCoordinate = point;
        GameObject r = point.transform.gameObject;
        //GameObject r = GameObject.Find(point.transform.name); //this might me slower than the foreach method
        MusicObj musicObj = r.GetComponent<MusicObj>();
        musicObj.GetComponent<Renderer>().material.color = Color.green;
        musicCurrentText.text = musicObj.ColumnTitle;
        artistCurrentText.text = musicObj.ColumnArtistName;
        //locationCurrentText.text = musicObj.ColumnLocation;
        genreCurrentText.text = musicObj.ColumnTerms;
        //familiarityCurrentText.text = musicObj.ColumnFamiliarity.ToString(specifier);
        //artistHotnessCurrentText.text = musicObj.ColumnArtistHotness.ToString(specifier);
        //tempoCurrentText.text = musicObj.ColumnTempo.ToString(specifier);
        durationCurrentText.text = musicObj.ColumnDuration + "";
    }

    void SelectMultipleObjects(GameObject obj, RaycastHit point)
    {
        if (firstOfMultipleSelection == true)
            ClearSelection();

        if (selectedObject != null)
        {
            isSelected = true;

            if (point.transform.name == selectedCoordinate.transform.name)
            {
                return;
            }
        }
        selectedObject = obj;
        selectedCoordinate = point;
        GameObject r = point.transform.gameObject;
        //GameObject r = GameObject.Find(point.transform.name); //this might me slower than the foreach method
        MusicObj musicObj = r.GetComponent<MusicObj>();
        musicObj.GetComponent<Renderer>().material.color = Color.green;
        selectedObjects.Add(musicObj);

    }

    void ClearSelection()
    {
        isSelected = false;

        if (selectedObject == null)
            return;
        Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
        //selectedObject.GetComponent<Renderer>().material.color = Color.clear;
        GameObject rh = selectedCoordinate.transform.gameObject;
        MusicObj musicObj = rh.GetComponent<MusicObj>();
        foreach (Renderer r in rs)
        {
            if (selectedCoordinate.transform.name == r.name)
            {
                r.material.color = musicObj.CurrentColor;
            }
        }
        selectedObject = null;
        musicCurrentText.text = "";
        artistCurrentText.text = "";
        //locationCurrentText.text = "";
        genreCurrentText.text = "";
        //familiarityCurrentText.text = "";
        //artistHotnessCurrentText.text = "";
        //tempoCurrentText.text = "";
        durationCurrentText.text = "";
        selectedObjects.Clear();
    }


    public void ClearAllSelections()
    {
        isSelected = false;

        foreach (MusicObj obj in selectedObjects)
        {
            obj.GetComponent<Renderer>().material.color = obj.CurrentColor;

        }
        ClearSelection();
    }
}
