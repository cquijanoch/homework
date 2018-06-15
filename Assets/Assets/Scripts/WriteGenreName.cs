using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WriteGenreName : MonoBehaviour {

    [SerializeField]
    public GameObject genrePrefab;

    [SerializeField] Transform genreName_t;

    public string inputfile;
    private List<Dictionary<string, object>> genreList;
    private string genreName = "genero";

    void Start () {
        genreList = CSVReader.Read(inputfile);
        List<string> columnList = new List<string>(genreList[1].Keys);

        for(int i = 0; i < genreList.Count ; i++)
        {
            GameObject genreName = Instantiate(genrePrefab,genreName_t) as GameObject;
            genreName.GetComponentInChildren<Text>().text = System.Convert.ToString(genreList[i][columnList[0]]);
            genreName.GetComponent<GenreObj>().nameGenre = System.Convert.ToString(genreList[i][columnList[0]]);
            genreName.GetComponent<Button>().onClick.AddListener(
                delegate
                {
                    clickFunction(genreName);
                }
            );
        } 
            //artistName.transform.SetParent(artistName_t); 
        
    }
	    
    void clickFunction(GameObject genreName)
    {
        Debug.Log(genreName.GetComponent<GenreObj>().nameGenre);
        genreName.GetComponent<GenreObj>().selected = !genreName.GetComponent<ArtistObj>().selected;
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
