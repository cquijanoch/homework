using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.XR;
using UnityEngine.EventSystems;

public class TaskGuide : MonoBehaviour {

    // Use this for initialization
    public GameObject myDataPlotter;
    public GameObject myMouseController;
    public GameObject myViveController;
    DataPlotter DataPlotterScript;
    public int taskID;
    public int userID;
    public int datasetID;
    public int singleSelectionCounter;
    public int multipleSelectionCounter;
    Stopwatch timer = new Stopwatch();
    Distance MatrixDistance;
    //PointerEventData pointer;


  //  List<GameObject> taskPoints;
    private GameObject []taskPoints = new GameObject[4];
    //private int []myvector = new int[2];
    public int[] itemSelectedT1 = { 23, 17, 43, 47 };
    public int[] itemSelectedT2 = { 101, 307, 443, 71 };


    //lista com os as musicas selecionadas

    //escala

    public bool VR; //0 se for 3D, 1 se for VR

    //------3d
    //seleção simples ou multipla
    //tempo
    //resultado
    //-------vr
    /// <summary>
    /// trigger
    /// tempo
    /// resultado
    /// </summary>

    private void Awake()
    {
        XRSettings.enabled = VR;
    }

    void Start() {

        //Start Experiment
     
        DataPlotterScript = myDataPlotter.GetComponent<DataPlotter>();
        MatrixDistance = new Distance(DataPlotterScript.dataPointList.Count, DataPlotterScript.dataPointList.Count);
        PointD[] ListPoint = new PointD[DataPlotterScript.dataPointList.Count];
        int p = 0;
        foreach (GameObject point in DataPlotterScript.dataPointList)
        {
            PointD point_ = new PointD((double)point.GetComponent<MusicObj>().ColumnX, (double)point.GetComponent<MusicObj>().ColumnY, (double)point.GetComponent<MusicObj>().ColumnZ, point.transform.name);
            ListPoint[p] = point_;
            p++;
        }
        MatrixDistance.InputMatrix(ListPoint, ListPoint);
    //    UnityEngine.Debug.Log("" + MatrixDistance.GetMinByIndex(139));

        //MatrixDistance = new Distance(5, 5);
        //PointD[] ListPoint = new PointD[5];
        //int p = 0;
        //foreach (GameObject point in DataPlotterScript.dataPointList)
        //{
        //    PointD point_ = new PointD((double)point.GetComponent<MusicObj>().ColumnX, (double)point.GetComponent<MusicObj>().ColumnY, (double)point.GetComponent<MusicObj>().ColumnZ, point.transform.name);
        //    ListPoint[p] = point_;
        //    p++;
        //    if (p == 5) break;
        //}
        //MatrixDistance.InputMatrix(ListPoint, ListPoint);
        //UnityEngine.Debug.Log("" + MatrixDistance.GetMinByIndex(3));



        timer.Start();
        switch (taskID)
        {
            case 1:
                foreach (int i in itemSelectedT1)
                {
                    //taskPoints.Add(DataPlotterScript.dataPointList[i]);
                    taskPoints[userID % 4] = DataPlotterScript.dataPointList[itemSelectedT1[i]];
                }
                StartTaskOne();
                break;
            case 2:
                foreach (int i in itemSelectedT2)
                {
                   // taskPoints.Add(DataPlotterScript.dataPointList[itemSelectedT1[i]]);
                    taskPoints[userID % 4] = DataPlotterScript.dataPointList[itemSelectedT2[i]];
                }
                StartTaskTwo();
                break;
            case 3:
                StartTaskThree();
                break;
            default:
                //Debug.Log("Defina uma tarefa");
                break;
                
        }


        
    }

    private void Update()
    {
        /*Collect data from the user input (mouse or controller)*/
        //time
        //if (VR)
        //{ }
        //else
        //pointer = new PointerEventData(EventSystem.current);
      //  OnPointerClick(pointer);
    }
/*    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            UnityEngine.Debug.Log("double click");
        }
    }
    */

    public void StartTaskOne()
    {

        //DataPlotterScript
        /*In this task a song A will be selected (colored) and the user has to find the nearest song to A of another artist */

        //Step 1: choose the song id according with the participant ID
        /*
         switch ()
        {
          case 0:
            //song 0
            //pintar DataPlotterScript.pointList(musica)
          case 1:
            //song 1
              break;
          case 2:
              //song2
              break;
          case 3:
              //song3
         }

         */
        //Step 2: color the song
    }

    public void EndTaskOne()
    {

        //Step 3.5: calculate distance between input and answer

        //comparar DataPlotterScript.dataPointList que tem a lista dos pontos com input do usuário

        //Step 4: record the answer 

        timer.Stop();
        //comparar as respostas
        //escrever csv
    }

    public void StartTaskTwo()
    {
        /*In this task a genre A will be selected (colored) and the user has to find the 3 most similar songs of this genre */
        //Step 1: set the task ID

        //Step 2: color (and lock the color of the) the genre
        //Step 3: wait for the input from the participant
        //Step 4: record the answer 

    }

    public void EndTaskTwo()
    {
        timer.Stop();
    }

    public void StartTaskThree()
    {
        /*In this task a genre A and a song will be selected (colored) and the user has to find the furthest song of the same genre to the song A */
        //Step 1: set the task ID
        
        //Step 2: color (and lock the color of the) the genre and the song

        //Step 3: wait for the input from the participant
        //Step 4: record the answer 

    }

    public void EndTaskThree()
    {
        timer.Stop();
    }

    public void CountSingleSelection()
    {
        singleSelectionCounter++;
    }

    public void CountMultipleSelection()
    {
        multipleSelectionCounter++;
    }




}
