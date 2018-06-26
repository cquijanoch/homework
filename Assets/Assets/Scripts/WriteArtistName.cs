using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WriteArtistName : MonoBehaviour {

    [SerializeField]
    public GameObject artistPrefab;

    [SerializeField] Transform artistName_t;

    DataPlotter dpScript;
    public GameObject myPlotter;

    void Start () {
        dpScript = myPlotter.GetComponent<DataPlotter>();
    
        foreach(string artist in dpScript.dataArtist.Keys)
        {
            GameObject artistName = Instantiate(artistPrefab,artistName_t) as GameObject;
            artistName.GetComponentInChildren<Text>().text = artist;
            artistName.GetComponent<ArtistObj>().nameArtist = artist;
            artistName.GetComponent<ArtistObj>().selected = true;
            artistName.GetComponent<Image>().color = ConvertColor(255, 255, 255, 200);
            artistName.GetComponent<Button>().onClick.AddListener(
                delegate
                {
                    clickFunction(artistName);
                }
            );
            
        } 
            //artistName.transform.SetParent(artistName_t); 
        
    }
	    
    void clickFunction(GameObject artistName)
    {
        Debug.Log(artistName.GetComponent<ArtistObj>().nameArtist);
        artistName.GetComponent<ArtistObj>().selected = !artistName.GetComponent<ArtistObj>().selected;
        if(!artistName.GetComponent<ArtistObj>().selected)
            artistName.GetComponent<Image>().color = ConvertColor(255, 255, 255, 65);
        else
            artistName.GetComponent<Image>().color = ConvertColor(255, 255, 255, 200);
    }

    public Color ConvertColor(int r, int g, int b, int a)
    {
        return new Color(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);
    }
}
