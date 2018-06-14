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
                    clickFunction(artistName.GetComponent<ArtistObj>());
                }
            );
        } 
            //artistName.transform.SetParent(artistName_t); 
        
    }
	    
    void clickFunction(ArtistObj artist)
    {
        Debug.Log(artist.nameArtist);
    }
}
