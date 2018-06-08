using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPloter : MonoBehaviour {

    public string inputfile;
    private List<Dictionary<string, object>> pointList;
    // Use this for initialization
    void Start () {
        pointList = CSVReader.Read(inputfile);
        //Log to console
        Debug.Log(pointList);
    }
	
	

}
