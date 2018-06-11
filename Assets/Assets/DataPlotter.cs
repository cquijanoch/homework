using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataPlotter : MonoBehaviour

{

    public string inputfile;


    private List<Dictionary<string, object>> pointList;

    // Indices for columns to be assigned
    public int columnX = 0;
    public int columnY = 1;
    public int columnZ = 2;

    private int columnColor = 4;
    private string cColor;

    // Full column names
    public string xName;
    public string yName;
    public string zName;

    public float plotScale = 12;

    // The prefab for the data points that will be instantiated
    public GameObject PointPrefab;

    // Object which will contain instantiated prefabs in hiearchy
    public GameObject PointHolder;

    // Use this for initialization
    void Start()
    {

        // Set pointlist to results of function Reader with argument inputfile
        pointList = CSVReader.Read(inputfile);


        // Declare list of strings, fill with keys (column names)
        List<string> columnList = new List<string>(pointList[1].Keys);

        // Print number of keys (using .count)
        Debug.Log("There are " + columnList.Count + " columns in the CSV");

        foreach (string key in columnList)
            Debug.Log("Column name is " + key);

        // Assign column name from columnList to Name variables
        xName = columnList[columnX];
        yName = columnList[columnY];
        zName = columnList[columnZ];

        cColor = columnList[columnColor];

        // Get maxes of each axis
        float xMax = FindMaxValue(xName);
        float yMax = FindMaxValue(yName);
        float zMax = FindMaxValue(zName);

        // Get minimums of each axis
        float xMin = FindMinValue(xName);
        float yMin = FindMinValue(yName);
        float zMin = FindMinValue(zName);

        for (var i = 0; i < pointList.Count; i++)
        {
            // Get value in poinList at ith "row", in "column" Name, normalize
            float x = (System.Convert.ToSingle(pointList[i][xName]) - xMin) / (xMax - xMin);

            float y = (System.Convert.ToSingle(pointList[i][yName]) - yMin) / (yMax - yMin);

            float z = (System.Convert.ToSingle(pointList[i][zName]) - zMin) / (zMax - zMin);

            // Instantiate as gameobject variable so that it can be manipulated within loop
            GameObject dataPoint = Instantiate( PointPrefab, new Vector3(x, y, z) * plotScale,  Quaternion.identity);

            // Make child of PointHolder object, to keep points within container in hiearchy
            dataPoint.transform.parent = PointHolder.transform;

            // Assigns original values to dataPointName
            string dataPointName = pointList[i][xName] + " "  + pointList[i][yName] + " " + pointList[i][zName];
            string dataPointGenero = pointList[i][cColor] + "";
            // Assigns name to the prefab
            dataPoint.transform.name = dataPointName;
            
            //Debug.Log(System.Convert.ToString(pointList[i][cColor]));
          


        //    switch (System.Convert.ToString(pointList[i][cColor]))
        //    {
        //        case "Bal-musette":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(218, 72, 59);
        //            break;
        //        case "Ballad":
        //            dataPoint.GetComponent<Renderer>().material.color = ConvertColor(255, 158, 15);
        //            break;
        //        case "Bluegrass":
        //            dataPoint.GetComponent<Renderer>().material.color = ConvertColor(68, 134, 244);
        //            break;
        //        case "Blues":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(255, 199, 24);
        //            break;
        //        case "Cabaret":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(28, 164, 92);
        //            break;
        //        case "Celtic":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(141, 196, 79);
        //            break;
        //        case "Chanson":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(90, 237, 213);
        //            break;
        //        case "Charanga":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(48, 137, 172);
        //            break;
        //        case "Chinese":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(157, 231, 173);
        //            break;
        //        case "Classical":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(254, 196, 118);
        //            break;
        //        case "Country":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(209, 64, 109);
        //            break;
        //        case "Cumbia":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(163, 54, 180);
        //            break;
        //        case "Disco":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(211, 144, 79);
        //            break;
        //        case "Dubstep":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(246, 181, 71);
        //            break;
        //        case "Electronic":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(255, 236, 179);
        //            break;
        //        case "Folk":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(0, 0, 0);
        //            break;
        //        case "Funk":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(255, 130, 130);
        //            break;
        //        case "Gospel":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(244, 237, 216);
        //            break;
        //        case "Greek":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(140, 95, 61);
        //            break;
        //        case "Happy Hardcore":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(169, 124, 80);
        //            break;
        //        case "Heavy Metal":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(230, 177, 117);
        //            break;
        //        case "Hip Hop":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(227, 149, 129);
        //            break;
        //        case "House":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(255, 193, 173);
        //            break;
        //        case "Indie":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(18, 231, 114);
        //            break;
        //        case "Irish":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(53, 181, 53);
        //            break;
        //        case "Jazz":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(0, 107, 60);
        //            break;
        //        case "Metal":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(0, 86, 63);
        //            break;
        //        case "New Wave":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(1, 50, 32);
        //            break;
        //        case "Opera":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(81, 40, 136);
        //            break;
        //        case "Polka":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(191, 0, 255);
        //            break;
        //        case "Pop":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(223, 0, 255);
        //            break;
        //        case "Pop Rock":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(246, 94, 255);
        //            break;
        //        case "Punk":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(253, 179, 255);
        //            break;
        //        case "R&B":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(8, 57, 194);
        //            break;
        //        case "Rap":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(38, 110, 246);
        //            break;
        //        case "Reggae":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(71, 201, 255);
        //            break;
        //        case "Reggaeton":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(130, 233, 255);
        //            break;
        //        case "Religius":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(184, 242, 255);
        //            break;
        //        case "Rock":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(255, 176, 71);
        //            break;
        //        case "Salsa":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(255, 211, 0);
        //            break;
        //        case "Samba":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(255, 240, 0);
        //            break;
        //        case "Soukous":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(255, 254, 85);
        //            break;
        //        case "Soul":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(255, 255, 194);
        //            break;
        //        case "Soundtrack":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(199, 175, 113);
        //            break;
        //        case "Tango":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(121, 94, 23);
        //            break;
        //        case "Zouk":
        //            dataPoint.GetComponent<Renderer>().material.color =ConvertColor(0, 35, 116);
        //            break;
        //    }
        //}
    }

    private float FindMaxValue(string columnName)
    {
        float maxValue = Convert.ToSingle(pointList[0][columnName]);
        for (var i = 0; i < pointList.Count; i++)
        {
            if (maxValue < Convert.ToSingle(pointList[i][columnName]))
                maxValue = Convert.ToSingle(pointList[i][columnName]);
        }
        
        return maxValue;
    }

    private float FindMinValue(string columnName)
    {
        float minValue = Convert.ToSingle(pointList[0][columnName]);
        for (var i = 0; i < pointList.Count; i++)
        {
            if (Convert.ToSingle(pointList[i][columnName]) < minValue)
                minValue = Convert.ToSingle(pointList[i][columnName]);
        }
        return minValue;
    }

    public Color ConvertColor(int r, int g, int b, int a)
    {
        return new Color(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);
    }

    public Color ConvertColor(int r, int g, int b)
    {
        return new Color(r / 255.0f, g / 255.0f, b / 255.0f);
    }

}