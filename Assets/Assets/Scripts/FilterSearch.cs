using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterSearch : MonoBehaviour {

    DataPlotter dpScript;
    public GameObject myPlotter;
    public GameObject gArtistNameContainer;
    GameObject gGenreNameContainer;
    GameObject[] buttonsArtistList;
    List<string> artistFiltered;
    GameObject[] buttonsGenreList;
    List<string> genreFiltered;

    void Start () {
        artistFiltered = new List<string>();
        genreFiltered = new List<string>();
       
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
        artistFiltered = new List<string>();
        genreFiltered = new List<string>();
        buttonsArtistList = GameObject.FindGameObjectsWithTag("ArtistButton");
        buttonsGenreList = GameObject.FindGameObjectsWithTag("GenreButton");
        dpScript = myPlotter.GetComponent<DataPlotter>();
       

        foreach (GameObject buttArt in buttonsArtistList)
        {
            ArtistObj artObj = buttArt.GetComponent<ArtistObj>();
            if (artObj.selected)
            {
                artistFiltered.Add(artObj.nameArtist);
            }
        }
        
        foreach (GameObject buttGenre in buttonsGenreList)
        {
            GenreObj genObj = buttGenre.GetComponent<GenreObj>();
            if (genObj.selected)
            {
                genreFiltered.Add(genObj.nameGenre);
            }
        }

        search();
       
    }

    void search()
    {
        foreach (GameObject point in dpScript.dataPointList)
        {
            MusicObj music = point.GetComponent<MusicObj>();
            music.GetComponent<Renderer>().material.color = Color.clear;
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
