using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterSearch : MonoBehaviour {

    DataPlotter dpScript;
    public GameObject myPlotter;

    WriteArtistName waScript;

    public GameObject gArtistNameContainer;
    GameObject gGenreNameContainer;
    GameObject[] buttonsArtistList;
    List<string> artistFiltered;
    GameObject[] buttonsGenreList;
    List<string> genreFiltered;

    void Start () {

        
       // waScript = GetComponent<WriteArtistName>().buttonArtistList;


        //filterSearchObj = GameObject.FindGameObjectWithTag("FilterSearch");
        //foreach (Transform child in artistNameContainer)
        //{
        //    filterSearchObj.GetComponent<Button>().onClick.AddListener(
        //    delegate
        //        {
        //            clickFunction();
        //        }
        //    );
        //}
    }

    public void clickFunction()
    {
        dpScript = myPlotter.GetComponent<DataPlotter>();
        waScript = GetComponent<WriteArtistName>();

        foreach (GameObject buttArt in waScript.buttonArtistList)
        {
            if (buttArt.GetComponent<ArtistObj>().selected)
            {
                artistFiltered.Add(buttArt.GetComponent<ArtistObj>().nameArtist);
            }
        }
        buttonsGenreList = gGenreNameContainer.GetComponentsInChildren<GameObject>();
        foreach (GameObject buttGenre in buttonsArtistList)
        {
            if (buttGenre.GetComponent<GenreObj>().selected)
            {
                genreFiltered.Add(buttGenre.GetComponent<GenreObj>().nameGenre);
            }
        }

        search();
       
    }

    void search()
    {
        foreach (GameObject point in dpScript.dataPointList)
        {
            MusicObj music = point.GetComponent<MusicObj>();
            foreach (string artist in artistFiltered)
            {
                if (artist.Equals(music.ColumnArtistName))
                {
                    music.GetComponent<Renderer>().material.color = Color.red;
                }
            }

            foreach (string genre in genreFiltered)
            {
                if (genre.Equals(music.ColumnTerms))
                {
                    music.GetComponent<Renderer>().material.color = Color.black;
                }
            }
        }
      
    }
}
