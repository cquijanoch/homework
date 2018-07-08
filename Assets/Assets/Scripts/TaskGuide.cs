using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.XR;
using UnityEngine.EventSystems;

using HTC.UnityPlugin.Pointer3D;
using HTC.UnityPlugin.Vive;

public class TaskGuide : MonoBehaviour {

    // Use this for initialization

    public GameObject myDataPlotter;
    public GameObject myMouseController;
    public GameObject myViveController;
    public GameObject answerPoint;
    public GameObject taskPoint;
    public Record logHandler;
    public string CSVResults;
    public string CSVFilename;
    public static Animator anim;
    DataPlotter DataPlotterScript;
    public int taskID;
    public int userID;
    public int datasetID;
    public int singleSelectionCounter;
    public int multipleSelectionCounter;
    Distance MatrixDistance;
    public float cronometro;
    public float cronometro2=0f;
    public int interactionCounter;


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
        logHandler = new Record();
        interactionCounter = 0;
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

        //write the CSV entry
        CSVResults = userID + "," + taskID + "," + datasetID + "," + boolToInt();
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

        CSVFilename = userID + "-" + taskID + "-" + datasetID + "-" + boolToInt();

        /*Decide here which song or genre will be assigned for the task*/
        switch (taskID)
        {
            case 1:
                /*Select the nearest song to the selected song*/
                foreach (int i in itemSelectedT1)
                {
                    //taskPoints.Add(DataPlotterScript.dataPointList[i]);
                    taskPoints[userID % 4] = DataPlotterScript.dataPointList[itemSelectedT1[i]];
                }
                StartTaskOne();
                break;

            case 2:
                /*Select the nearest song to the selected song from a given artist*/

                foreach (int i in itemSelectedT2)
                {
                    // taskPoints.Add(DataPlotterScript.dataPointList[itemSelectedT1[i]]);
                    taskPoints[userID % 4] = DataPlotterScript.dataPointList[itemSelectedT2[i]];
                }
                StartTaskTwo();
                break;
            case 3:
                /*Select the furthest song within the same genre*/
                StartTaskThree();
                break;

            case 4:
                /*Select the artist that has more songs*/
                StartTaskFour();
                break;
            default:
                UnityEngine.Debug.Log("Defina uma tarefa");
                taskPoint = DataPlotterScript.dataPointList[0];
                answerPoint = DataPlotterScript.dataPointList[1];
               // StartTaskOne();
               // EndTaskOne();


                break;
        }

    }


    void Update()
    {
        cronometro += Time.deltaTime;
        //fazer a contagem dos clicks/trigger
        if (VR)
        {
            if ((ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.Trigger)))
                interactionCounter++;
            if ((ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Trigger)))
                interactionCounter++;
        }
        else
        {
            if(Input.GetMouseButtonUp(0))
            {
                interactionCounter++;
            }
        }

        
        

    }
    public void StartTaskOne()
    {
        cronometro = 0;


        /*In this task a song A will be selected (colored) and the user has to find the nearest song to it */

        /*Step 1: animate the sphere*/
        startSphereAnimation();
        /*Step 2: color the sphere*/
        

    }

    public void EndTaskOne()
    {

        //Step 3.5: calculate distance between input and answer
        
        //comparar DataPlotterScript.dataPointList que tem a lista dos pontos com input do usuário

        //Step 4: record the answer 
            
        CSVResults += "," + cronometro + "," + interactionCounter + "," +answerPoint.name + "," ; //falta armazenar qual seria a resposta correta e fazer o cálculo da distância
        logHandler.Log(CSVResults, CSVFilename);

        //comparar as respostas
        //escrever csv
    }

    public void StartTaskTwo()
    {
        cronometro = 0;

        /*In this task a genre A will be selected (colored) and the user has to find the nearest song to it that is from a given artist*/

        startSphereAnimation();

        /*Step 2: color the sphere*/
    }

    public void EndTaskTwo()
    {

        //record the answer
    }

    public void StartTaskThree()
    {
        /*In this task a genre A and a song will be selected (colored) and the user has to find the furthest song of the same genre to the song A */

        //Step 2: color (and lock the color of the) the genre and the song
        cronometro = 0;

        startSphereAnimation();

    }

    public void EndTaskThree()
    {
        
        
    }

    public void StartTaskFour()
    {
        /*In this task, given two artists from different genres, the participant has to select which artist has more songs*/
        cronometro = 0;

    }


    public void startSphereAnimation()
    {
        taskPoint.AddComponent<Animator>();
        anim = taskPoint.GetComponent<Animator>();
        anim.runtimeAnimatorController = Resources.Load("sphereController") as RuntimeAnimatorController;
        anim.Play("sphereAnimation");
    }
    
    public int boolToInt()
    {
        if (VR)
            return 1;
        return 0;
    }

}
