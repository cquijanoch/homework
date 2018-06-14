using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WriteArtistName : MonoBehaviour {

    [SerializeField]
    public GameObject artistPrefab;

    [SerializeField] Transform artistName_t;

    // Use this for initialization
    void Start () {
        Debug.Log("aaa");
        for (int y = 0; y < 5; y++)
        {
            GameObject artistName = Instantiate(artistPrefab,artistName_t) as GameObject;
            artistName.GetComponentInChildren<Text>().text = y + "";
            artistName.GetComponent<ArtistObj>().nameArtist = y + "";
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
