using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WriteSelectedName : MonoBehaviour {

    [SerializeField]
    public GameObject selectedPrefab;

    [SerializeField] Transform selectedName_t;

    MouseController dpScript;
    ViveEventsController dpvScript;
    public GameObject mouseController;

    //public bool isChecked = true;
    [SerializeField] public Text musicCurrentText;
    [SerializeField] public Text artistCurrentText;
    [SerializeField] public Text genreCurrentText;
    [SerializeField] public Text durationCurrentText;

    void OnEnable() {
        List<MusicObj> selecteds = new List<MusicObj>();
        if(mouseController.GetComponent<MouseController>())
        {
            dpScript = mouseController.GetComponent<MouseController>();
            selecteds = dpScript.selectedObjects;
        } else if (mouseController.GetComponent<ViveEventsController>())
        {
            dpvScript = mouseController.GetComponent<ViveEventsController>();
            selecteds = dpScript.selectedObjects;
        }
        

        foreach (MusicObj musicN in selecteds)
        {
            GameObject selectedName = Instantiate(selectedPrefab, selectedName_t) as GameObject;
            selectedName.GetComponentInChildren<Text>().text = musicN.ColumnTitle;
            selectedName.GetComponent<MusicObj>().ColumnTitle = musicN.ColumnTitle;
            selectedName.GetComponent<MusicObj>().ColumnArtistName = musicN.ColumnArtistName;
            selectedName.GetComponent<MusicObj>().ColumnTerms = musicN.ColumnTerms;
            selectedName.GetComponent<MusicObj>().ColumnDuration = musicN.ColumnDuration;
            selectedName.GetComponent<Button>().onClick.AddListener(
                delegate
                {
                    clickFunction(selectedName);
                }
            );
        }   
        
    }

    void OnDisable()
    {
        foreach (Transform child in selectedName_t)
        {
            Destroy(child.gameObject);
        }

    }

    void clickFunction(GameObject selectedName)
    {
        Debug.Log(selectedName.GetComponent<MusicObj>().ColumnTitle);
        musicCurrentText.text = selectedName.GetComponent<MusicObj>().ColumnTitle;
        artistCurrentText.text = selectedName.GetComponent<MusicObj>().ColumnArtistName;
        durationCurrentText.text = selectedName.GetComponent<MusicObj>().ColumnDuration + "";
        //locationCurrentText.text = musicObj.ColumnLocation;
        genreCurrentText.text = selectedName.GetComponent<MusicObj>().ColumnTerms;
    }
    
}
