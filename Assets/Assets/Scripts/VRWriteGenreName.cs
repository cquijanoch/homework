using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VRWriteGenreName : MonoBehaviour {

    [SerializeField]
    public GameObject genrePrefab;

    [SerializeField] Transform genreName_t;

    DataPlotter dpScript;
    public GameObject myPlotter;
    private bool isChecked = false;
    
    void Start () {
        
        dpScript = myPlotter.GetComponent<DataPlotter>();
        foreach (string genreN in dpScript.dataGenres.Keys )
        {
            GameObject genreName = Instantiate(genrePrefab,genreName_t) as GameObject;
            genreName.GetComponentInChildren<Text>().text = genreN;
            genreName.transform.GetChild(1).GetComponent<Image>().color = dpScript.dataGenres[genreN];
            genreName.GetComponent<GenreObj>().nameGenre = genreN;
            genreName.GetComponent<GenreObj>().selected = isChecked;
            if (isChecked) genreName.GetComponent<Image>().color = ConvertColor(255, 255, 255, 200);
            else genreName.GetComponent<Image>().color = ConvertColor(255, 255, 255, 65);
            genreName.GetComponent<Button>().onClick.AddListener(
                delegate
                {
                    clickFunction(genreName);
                }
            );
        } 
        
    }
	    
    void clickFunction(GameObject genreName)
    {
        Debug.Log(genreName.GetComponent<GenreObj>().nameGenre);
        genreName.GetComponent<GenreObj>().selected = !genreName.GetComponent<GenreObj>().selected;
        if(!genreName.GetComponent<GenreObj>().selected)
            genreName.GetComponent<Image>().color = ConvertColor(255, 255, 255, 65);
        else
            genreName.GetComponent<Image>().color = ConvertColor(255, 255, 255, 200);
    }

    public Color ConvertColor(int r, int g, int b, int a)
    {
        return new Color(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);
    }
    
}
