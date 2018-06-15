using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterSearch : MonoBehaviour {

    GameObject filterSearchObj = GameObject.FindGameObjectWithTag("FilterSearch");

    void Start () {
        filterSearchObj.GetComponent<Button>().onClick.AddListener(
        delegate
            {
              //  clickFunction(genreName);
            }
        );
    }

    //void clickFunction(GameObject genreName)
    //{
    //    Debug.Log(genreName.GetComponent<GenreObj>().nameGenre);
    //    genreName.GetComponent<GenreObj>().selected = !genreName.GetComponent<ArtistObj>().selected;
    //    if (!genreName.GetComponent<GenreObj>().selected)
    //        genreName.GetComponent<Image>().color = ConvertColor(255, 255, 255, 65);
    //    else
    //        genreName.GetComponent<Image>().color = ConvertColor(255, 255, 255, 200);
    //}
}
