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
                    Color c = music.Color;
                    c.a = 100 / 255.0f;
                    music.GetComponent<Renderer>().material.color = c;
                }
            }
            foreach (string genre in genreFiltered)
            {
                if (genre.Equals(music.ColumnTerms))
                {
                    music.GetComponent<Renderer>().material.color = music.Color;
                }
            }
        }
      
    }
}
