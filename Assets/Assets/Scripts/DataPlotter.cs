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

    //private int columnArtistHotness = 0;
    //private int columnTempo = 1;
    //private int columnFamiliarity = 2;
    private int columnDuration = 16;
    //private int columnLoudness = 4;
    private int columnTerms = 9;
    //private int columnMode = 6;                 
    //private int columnKey = 7;
    //private int columnYear = 8;
    private int columnTitle = 8;
    //private int columnLocation = 10;
    private int columnArtistName = 7;
    //private int columnReleaseName = 12;
    //private int columnSongHotness = 13;
    
    //private int columnColor = 4;
    private string cColor;

    // Full column names
    public string xName;
    public string yName;
    public string zName;

    //private string artistHotnessName;
    //private string tempoName;
    //private string familiarityName;
    private string durationName;
    //private string loudnessName;
    private string termsName;
    //private string modeName;
    //private string keyName;
    //private string yearName;
    private string titleName;
    //private string locationName;
    private string artistName;
    //private string releaseName;
    //private string songHotnessName;

    public float plotScale = 12;
    
    public GameObject PointPrefab;
    
    public GameObject PointHolder;

    public List<GameObject> dataPointList;
    public SortedDictionary<string,Color> dataGenres;
    public SortedDictionary<string,string> dataArtist;

    void Awake()
    {
        pointList = CSVReader.Read(inputfile);
        dataGenres = new SortedDictionary<string,Color>();
        dataArtist = new SortedDictionary<string,string>();
        List<string> columnList = new List<string>(pointList[1].Keys);
        
        // Assign column name from columnList to Name variables
        xName = columnList[columnX];
        yName = columnList[columnY];
        zName = columnList[columnZ];
        //artistHotnessName = columnList[columnArtistHotness];
        //tempoName = columnList[columnTempo];
        //familiarityName = columnList[columnFamiliarity];
        durationName = columnList[columnDuration];
        //loudnessName = columnList[columnLoudness];
        termsName = columnList[columnTerms];
        //modeName = columnList[columnMode];
        //keyName = columnList[columnKey];
        //yearName = columnList[columnYear];
        titleName = columnList[columnTitle];
        //locationName = columnList[columnLocation];
        artistName = columnList[columnArtistName];
        //releaseName = columnList[columnReleaseName];
        //songHotnessName = columnList[columnSongHotness];

        //cColor = columnList[columnColor];

        // Get maxes of each axis
        float xMax = FindMaxValue(xName);
        float yMax = FindMaxValue(yName);
        float zMax = FindMaxValue(zName);

        // Get minimums of each axis
        float xMin = FindMinValue(xName);
        float yMin = FindMinValue(yName);
        float zMin = FindMinValue(zName);


        PointHolder.transform.position = new Vector3((xMax - xMin) / 2, (yMax - yMin) / 2, (zMax - zMin) / 2);

        int Ccolor = 0;

        for (var i = 0; i < pointList.Count; i++)
        {
          
            float x = (System.Convert.ToSingle(pointList[i][xName]) - xMin) / (xMax - xMin);
            float y = (System.Convert.ToSingle(pointList[i][yName]) - yMin) / (yMax - yMin);
            float z = (System.Convert.ToSingle(pointList[i][zName]) - zMin) / (zMax - zMin);

            GameObject dataPoint = Instantiate( PointPrefab, new Vector3(x, y, z) * plotScale,  Quaternion.identity);

            dataPoint.transform.parent = PointHolder.transform;
            dataPoint.AddComponent<ScatterplotRotation>();

            string dataPointName = i + "";// pointList[i][xName] + " "  + pointList[i][yName] + " " + pointList[i][zName];
            //string dataPointGenero = pointList[i][cColor] + "";
            dataPoint.transform.name = dataPointName;

            MusicObj musicObj = dataPoint.GetComponent<MusicObj>();
            musicObj.ColumnArtistName = System.Convert.ToString(pointList[i][artistName]);
            if(!dataArtist.ContainsKey(musicObj.ColumnArtistName))
            {
                dataArtist.Add(musicObj.ColumnArtistName, musicObj.ColumnArtistName);
            }
            
            //musicObj.ColumnArtistHotness = System.Convert.ToDecimal(pointList[i][artistHotnessName]);
            musicObj.ColumnDuration = System.Convert.ToDecimal(pointList[i][durationName]);
            //musicObj.ColumnFamiliarity = System.Convert.ToDecimal(pointList[i][familiarityName]);
            //musicObj.ColumnKey = System.Convert.ToDouble(pointList[i][keyName]);
            //musicObj.ColumnLocation = System.Convert.ToString(pointList[i][locationName]);
            //musicObj.ColumnLoudness = System.Convert.ToDecimal(pointList[i][loudnessName]);
            //musicObj.ColumnMode = System.Convert.ToInt32(pointList[i][modeName]);
            //musicObj.ColumnReleaseName = System.Convert.ToString(pointList[i][releaseName]);
            //musicObj.ColumnSongHotness = System.Convert.ToDecimal(pointList[i][songHotnessName]);
            //musicObj.ColumnTempo = System.Convert.ToDouble(pointList[i][tempoName]);
            musicObj.ColumnTerms = System.Convert.ToString(pointList[i][termsName]);
            musicObj.ColumnTitle = System.Convert.ToString(pointList[i][titleName]);
            //musicObj.ColumnX = System.Convert.ToDecimal(pointList[i][xName]);
            //musicObj.ColumnY = System.Convert.ToDecimal(pointList[i][yName]);
            //musicObj.ColumnZ = System.Convert.ToDecimal(pointList[i][zName]);
            musicObj.ColumnX = System.Convert.ToDecimal(x);
            musicObj.ColumnY = System.Convert.ToDecimal(y);
            musicObj.ColumnZ = System.Convert.ToDecimal(z);


            //dataPoint.GetComponent<Renderer>().material.color = Color.black;
            //musicObj.ColumnYear = System.Convert.ToInt32(pointList[i][yearName]);

            //Debug.Log(System.Convert.ToString(pointList[i][cColor]));

            if (!dataGenres.ContainsKey(musicObj.ColumnTerms))
            {
                switch (Ccolor)
                {
                    case 0:
                        dataPoint.GetComponent<Renderer>().material.color = ConvertColor(218, 72, 59);
                        musicObj.Color = ConvertColor(218, 72, 59);
                        break;
                    case 1:
                        dataPoint.GetComponent<Renderer>().material.color = ConvertColor(255, 158, 15);
                        musicObj.Color = ConvertColor(255, 158, 15);
                        break;
                    case 2:
                        dataPoint.GetComponent<Renderer>().material.color = ConvertColor(68, 134, 244);
                        musicObj.Color = ConvertColor(68, 134, 244);
                        break;
                    case 3:
                        dataPoint.GetComponent<Renderer>().material.color = ConvertColor(255, 199, 24);
                        musicObj.Color = ConvertColor(255, 199, 24);
                        break;
                    case 4:
                        dataPoint.GetComponent<Renderer>().material.color = ConvertColor(28, 164, 92);
                        musicObj.Color = ConvertColor(28, 164, 92);
                        break;
                    case 5:
                        dataPoint.GetComponent<Renderer>().material.color = ConvertColor(141, 196, 79);
                        musicObj.Color = ConvertColor(141, 196, 79);
                        break;
                    case 6:
                        dataPoint.GetComponent<Renderer>().material.color = ConvertColor(90, 237, 213);
                        musicObj.Color = ConvertColor(90, 237, 213);
                        break;
                    case 7:
                        dataPoint.GetComponent<Renderer>().material.color = ConvertColor(48, 137, 172);
                        musicObj.Color = ConvertColor(48, 137, 172);
                        break;
                    case 8:
                        dataPoint.GetComponent<Renderer>().material.color = ConvertColor(157, 231, 173);
                        musicObj.Color = ConvertColor(157, 231, 173);
                        break;
                    case 9:
                        dataPoint.GetComponent<Renderer>().material.color = ConvertColor(254, 196, 118);
                        musicObj.Color = ConvertColor(254, 196, 118);
                        break;
                    case 10:
                        dataPoint.GetComponent<Renderer>().material.color = ConvertColor(209, 64, 109);
                        musicObj.Color = ConvertColor(209, 64, 109);
                        break;
                    default:
                        Debug.Log("Error");
                        break;
                }
                dataGenres.Add(musicObj.ColumnTerms, musicObj.Color);
                Ccolor++;
            }
            else
            {
                dataPoint.GetComponent<Renderer>().material.color = dataGenres[musicObj.ColumnTerms];
                musicObj.Color = dataGenres[musicObj.ColumnTerms];
            }
            musicObj.CurrentColor = musicObj.Color;
            dataPointList.Add(dataPoint);
        }

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