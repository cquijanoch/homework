using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViveEventsController : MonoBehaviour {

    private bool firstOfMultipleSelection = true;
    public GameObject myFPS;
    public GameObject selectedObject = null;
    public List<MusicObj> selectedObjects = null;
    [SerializeField] public Text musicCurrentText;
    [SerializeField] public Text artistCurrentText;
    [SerializeField] public Text genreCurrentText;
    //[SerializeField] public Text durationCurrentText;

    string specifier = "G";

    void Update ()
    {

    }


    public  void rightHandTrigger(GameObject objectTarget)
    {
        ClearAllSelections();
        if (objectTarget.transform.name != "Plane")
        {
            SelectSingleObject(objectTarget);
            firstOfMultipleSelection = true;
        }
    }

    public void leftRightHandTrigger(GameObject objectTarget)
    {
        
        if (objectTarget.transform.name != "Plane")
        {
            SelectMultipleObjects(objectTarget);

            firstOfMultipleSelection = false;
        }
        
    }

    void SelectMultipleObjects(GameObject objectTarget)
    {
        if (firstOfMultipleSelection == true)
            ClearSelection();
        MusicObj musicObj = objectTarget.GetComponent<MusicObj>();
        selectedObjects.Add(musicObj);
        musicObj.GetComponent<Renderer>().material.color = Color.green;
        
    }

    void SelectSingleObject(GameObject objectTarget)
    {
        if (selectedObject != null)
        {
            ClearSelection();
        }
        selectedObject = objectTarget;
        MusicObj musicObj = selectedObject.GetComponent<MusicObj>();
        musicObj.GetComponent<Renderer>().material.color = Color.green;
        musicCurrentText.text = musicObj.ColumnTitle;
        artistCurrentText.text = musicObj.ColumnArtistName;
        genreCurrentText.text = musicObj.ColumnTerms;
        //durationCurrentText.text = musicObj.ColumnDuration + "";
    }

    void ClearSelection()
    {
        if (selectedObject == null)
            return;
        selectedObject.GetComponent<Renderer>().material.color = selectedObject.GetComponent<MusicObj>().CurrentColor;
        selectedObject = null;
        musicCurrentText.text = "";
        artistCurrentText.text = "";
        genreCurrentText.text = "";
        //durationCurrentText.text = "";
    }

    public void ClearAllSelections ()
    {
        foreach (MusicObj obj in selectedObjects)
        {
            obj.GetComponent<Renderer>().material.color = obj.CurrentColor;
        }
        ClearSelection();
    }
}
