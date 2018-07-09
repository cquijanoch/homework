using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.XR;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

using HTC.UnityPlugin.Pointer3D;
using HTC.UnityPlugin.Vive;

public class TaskGuide : MonoBehaviour {

    // Use this for initialization

    public GameObject myDataPlotter;
    public GameObject myMouseController;
    public GameObject myViveController;
    public GameObject answerPoint;
   // public GameObject taskPoint;
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
    [SerializeField] public Text taskText;
    [SerializeField] public Text task2Text;
    public float cronometro;
    public float cronometro2=0f;
    public int interactionCounter;

    private GameObject []taskPoints = new GameObject[4];
    //private int []myvector = new int[2];
    public int[] itemSelectedT1 = { 23, 17, 43, 47 };
    //public int[] itemSelectedT2 = { 36, 17, 43, 47 }; //Luis miguel y Culture

    //Tarefa 2 
    //msd-subdataset4
    //================
    // 36   LuisMiguel      412     Culture
    // 29    LuisMiguel      411    Culture
    // 86     Rocio Durcal     2776       Lee Greenwood
    //msd-subdataset1
    //================
    // 201   Close COmbat               251    Funkstoerung

    //msd-subdataset2
    //================
    // 211  Akil               782   Culture
    // 208   Culture            1194  Akil        
    // 51   ke$ha                    254     Donell Jones

    //Tarefa 3

    //msd-subdataset4
    //================
    //metal  3778           3752

    //msd-subdataset1
    //================
    //pop   38          32

    //msd-subdataset2
    //================
    //jazz  581             1570            


    //Tarefa 3

    //msd-subdataset4
    //================
    //metal  3778           3752

    //msd-subdataset1
    //================
    //pop   38          32

    //msd-subdataset2
    //================
    //jazz  581             1570          



    // public int[] itemSelectedT2 = { 101, 307, 443, 71 };


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
        CSVFilename = "User - "+userID + "-" + "Task - " + taskID + "-" + "Dataset - " + datasetID + "-" + "VR - "+boolToInt();
        //CSVFilename = userID + "-" + taskID + "-" + datasetID + "-" + boolToInt();

        /*Decide here which song or genre will be assigned for the task*/
        switch (taskID)
        {
            case 1:
                /*SDada uma música, encontrar a música mais próxima a ela (sem nenhuma restrição de artista ou gênero)*/

                
                StartTaskOne(DataPlotterScript.dataPointList[itemSelectedT1[datasetID-1]]);
                break;

            case 2:
                /*Dada uma música de um artista, encontrar a música mais próxima a ela que seja de um outro artista especificado*/

                if (DataPlotterScript.inputfile.Equals("msd-subdataset1"))
                {
                    StartTaskTwo(DataPlotterScript.dataPointList[201], "Funkstoerung");
                }
                else if (DataPlotterScript.inputfile.Equals("msd-subdataset2"))
                {
                    StartTaskTwo(DataPlotterScript.dataPointList[208], "Akil");
                }
                else if (DataPlotterScript.inputfile.Equals("msd-subdataset4"))
                {
                    StartTaskTwo(DataPlotterScript.dataPointList[36], "Culture");
                }
                break;
            case 3:
                /*Dada uma música, encontrar a música mais distante a ela que pertença ao mesmo gênero*/
                if (DataPlotterScript.inputfile.Equals("msd-subdataset1"))
                {
                    StartTaskThree(DataPlotterScript.dataPointList[38]);
                }
                else if (DataPlotterScript.inputfile.Equals("msd-subdataset2"))
                {
                    StartTaskThree(DataPlotterScript.dataPointList[581]);
                }
                else if (DataPlotterScript.inputfile.Equals("msd-subdataset4"))
                {
                    StartTaskThree(DataPlotterScript.dataPointList[3778]);
                }
                break;

            case 4:
                /*Select the artist that has more songs*/
                StartTaskFour();
                break;
            default:
                UnityEngine.Debug.Log("Defina uma tarefa");
                
                //StartTaskOne();
                break;
        }
       
    }


    void Update()
    {
        cronometro += Time.deltaTime;
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


      /*if (cronometro > 30)
            EndTaskOne();
            */  
    }


    public void StartTaskOne(GameObject taskPoint)
    {
        /*ANIMATION PART*/
        startSphereAnimation(taskPoint);
        cronometro = 0;
    }

    public void EndTaskOne()
    {
        //Step 3.5: calculate distance between input and answer
        //comparar DataPlotterScript.dataPointList que tem a lista dos pontos com input do usuário
        GameObject pointSelected;
        if ( VR )
            pointSelected = myViveController.GetComponent<ViveEventsController>().selectedObject;
        else
            pointSelected = myMouseController.GetComponent<MouseController>().selectedObject;

        if (pointSelected)
        {
            MusicObj music_p = pointSelected.GetComponent<MusicObj>(); //selected
            MusicObj music_c = DataPlotterScript.dataPointList[MatrixDistance.GetMinByIndex(itemSelectedT1[datasetID-1])].GetComponent<MusicObj>(); //closest
            MusicObj music_r = DataPlotterScript.dataPointList[itemSelectedT1[datasetID-1]].GetComponent<MusicObj>(); // real
            double distCorrect = MatrixDistance.CalculateDistance((double)music_r.ColumnX, (double)music_r.ColumnY, (double)music_r.ColumnZ, (double)music_c.ColumnX, (double)music_c.ColumnY, (double)music_c.ColumnZ);
            double distAprox = MatrixDistance.CalculateDistance((double)music_p.ColumnX, (double)music_p.ColumnY, (double)music_p.ColumnZ, (double)music_c.ColumnX, (double)music_c.ColumnY, (double)music_c.ColumnZ);
            double error = (Math.Abs(distCorrect - distAprox) / distCorrect) * 100;
            UnityEngine.Debug.Log("point correct: " + MatrixDistance.GetMinByIndex(itemSelectedT1[datasetID-1]));
            UnityEngine.Debug.Log("Error: " + error);


            //Step 4: record the answer 
            UnityEditor.EditorApplication.isPlaying = false;
            string isCorrect_ = music_p.name == music_c.name ? "1" : "0";
            //Time(sec)         , Clicks                 , UserAnswerID             , CorrectAnswerID      , StartPoint         , Genre                         , CorrectArtist               , AswerArtist                            , isCorrect"
            CSVResults += "," + cronometro + "," + interactionCounter + "," + music_p.name + "," + music_c.name + "," + music_r.name + "," + music_r.ColumnTerms + "," + music_c.ColumnArtistName + "," + music_p.ColumnArtistName   +   "," + isCorrect_;
            UnityEngine.Debug.Log(CSVResults);
            logHandler.Log(CSVResults, CSVFilename);
            UnityEditor.EditorApplication.isPlaying = false;
            //comparar as respostas
            //escrever csv
        }
    }

    public void StartTaskTwo(GameObject taskPoint, String artistSpecific)
    {
        taskText.text = artistSpecific;
        startSphereAnimation(taskPoint);
        cronometro = 0;
    }

    public void EndTaskTwo()
    {
        GameObject pointSelected;
        if (VR)
            pointSelected = myViveController.GetComponent<ViveEventsController>().selectedObject;
        else
            pointSelected = myMouseController.GetComponent<MouseController>().selectedObject;

        if (pointSelected)
        {
            MusicObj music_p = pointSelected.GetComponent<MusicObj>(); //selected
            MusicObj music_c = null;
            MusicObj music_r = null;
            if (DataPlotterScript.inputfile.Equals("msd-subdataset1"))
            {
                music_c = DataPlotterScript.dataPointList[251].GetComponent<MusicObj>(); //closest
                music_r = DataPlotterScript.dataPointList[201].GetComponent<MusicObj>(); //real
            }
            else if (DataPlotterScript.inputfile.Equals("msd-subdataset2"))
            {
                music_c = DataPlotterScript.dataPointList[1194].GetComponent<MusicObj>(); //closest
                music_r = DataPlotterScript.dataPointList[208].GetComponent<MusicObj>(); //real
            }
            else if (DataPlotterScript.inputfile.Equals("msd-subdataset4"))
            {
                music_c = DataPlotterScript.dataPointList[412].GetComponent<MusicObj>(); //closest
                music_r = DataPlotterScript.dataPointList[36].GetComponent<MusicObj>(); //real
            }
            //Time(sec)         , Clicks                 , UserAnswerID             , CorrectAnswerID      , StartPoint         , Genre                         , CorrectArtist               , AswerArtist                            , isCorrect"
            string isCorrect_ = music_p.name == music_c.name ? "1" : "0";
            CSVResults += "," + cronometro + "," + interactionCounter + "," + music_p.name + "," + music_c.name + "," + music_r.name + "," + music_r.ColumnTerms + "," + music_c.ColumnArtistName + "," + music_p.ColumnArtistName + "," + isCorrect_;
            logHandler.Log(CSVResults, CSVFilename);
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void StartTaskThree(GameObject taskPoint)
    {
        startSphereAnimation(taskPoint);
        cronometro = 0;
    }

    public void EndTaskThree()
    {
        GameObject pointSelected;
        if (VR)
            pointSelected = myViveController.GetComponent<ViveEventsController>().selectedObject;
        else
            pointSelected = myMouseController.GetComponent<MouseController>().selectedObject;


        if (pointSelected)
        {
            MusicObj music_p = pointSelected.GetComponent<MusicObj>(); //selected
            MusicObj music_c = null;
            MusicObj music_r = null;
            if (DataPlotterScript.inputfile.Equals("msd-subdataset1"))
            {
                music_c = DataPlotterScript.dataPointList[32].GetComponent<MusicObj>(); //closest
                music_r = DataPlotterScript.dataPointList[38].GetComponent<MusicObj>(); //real
            }
            else if (DataPlotterScript.inputfile.Equals("msd-subdataset2"))
            {
                music_c = DataPlotterScript.dataPointList[1570].GetComponent<MusicObj>(); //closest
                music_r = DataPlotterScript.dataPointList[581].GetComponent<MusicObj>(); //real
            }
            else if (DataPlotterScript.inputfile.Equals("msd-subdataset4"))
            {
                music_c = DataPlotterScript.dataPointList[3752].GetComponent<MusicObj>(); //closest
                music_r = DataPlotterScript.dataPointList[3778].GetComponent<MusicObj>(); //real
            }
            //Time(sec)         , Clicks                 , UserAnswerID             , CorrectAnswerID      , StartPoint         , Genre                         , CorrectArtist               , AswerArtist                            , isCorrect"
            string isCorrect_ = music_p.name == music_c.name ? "1" : "0";
            CSVResults += "," + cronometro + "," + interactionCounter + "," + music_p.name + "," + music_c.name + "," + music_r.name + "," + music_r.ColumnTerms + "," + music_c.ColumnArtistName + "," + music_p.ColumnArtistName + "," + isCorrect_;
            logHandler.Log(CSVResults, CSVFilename);
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void StartTaskFour()
    {
        cronometro = 0;
        if (datasetID == 1)
        {
            //Blue Oyster Cult  49
            //DJ Yoda       40
            //John Stevens  30
            //MNEMIC    50
            //Shawn Colvin  50
            taskText.text = "Blue Oyster Cult";
            task2Text.text = "DJ Yoda";
        }
        else if (datasetID == 2)
        {
            //Aborted       69
            //American Hi-Fi    47
            //Azymuth   49
            //Dub Pistols       57
            //Donell Jones          38
            //London Symphony Orchestra 70
            taskText.text = "American Hi-Fi";
            task2Text.text = "Dub Pistols";
           
        }
        else if (datasetID == 3)
        {
            //Emiliana Torrini   52
            //Chris Clark       72
            //Rocio Durcal      81
            taskText.text = "Chris Clark";
            task2Text.text = "Rocio Durcal";
        }
    }

    public void EndTaskFour()
    {
        GameObject pointSelected;
        if (VR)
            pointSelected = myViveController.GetComponent<ViveEventsController>().selectedObject;
        else
            pointSelected = myMouseController.GetComponent<MouseController>().selectedObject;
        if (pointSelected)
        {
            MusicObj music_p = pointSelected.GetComponent<MusicObj>(); //selected
            string isCorrect_ = "";
            string correctArtist = "";
            if (datasetID == 1)
            {
                //Blue Oyster Cult  49
                //DJ Yoda       40
                //John Stevens  30
                //MNEMIC    50
                //Shawn Colvin  50
                correctArtist = "Blue Oyster Cult";
                isCorrect_ = music_p.ColumnArtistName == "Blue Oyster Cult" ? "1" : "0";
            }
            else if (datasetID == 2)
            {
                //Aborted       69
                //American Hi-Fi    47
                //Azymuth   49
                //Dub Pistols       57
                //Donell Jones          38
                //London Symphony Orchestra 70
                correctArtist = "Dub Pistols";
                isCorrect_ = music_p.ColumnArtistName == "Dub Pistols" ? "1" : "0";
            }
            else if (datasetID == 3)
            {
                //Emiliana Torrini   52
                //Chris Clark       72
                //Rocio Durcal      81
                correctArtist = "Rocio Durcal";
                isCorrect_ = music_p.ColumnArtistName == "Rocio Durcal" ? "1" : "0";
            }
            //Time(sec)         , Clicks         , UserAnswerID             , CorrectAnswerID      , StartPoint         , Genre                         , CorrectArtist               , AswerArtist                            , isCorrect"
            CSVResults += "," + cronometro + "," + interactionCounter + "," + music_p.name + "," + " "           +       "," + " " +         ","         + "" + "," + correctArtist + "," + music_p.ColumnArtistName + "," + isCorrect_;
            logHandler.Log(CSVResults, CSVFilename);
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void startSphereAnimation(GameObject taskPoint)
    {
        taskPoint.AddComponent<Animator>();
        anim = taskPoint.GetComponent<Animator>();
        anim.runtimeAnimatorController = Resources.Load("sphereController") as RuntimeAnimatorController;
        taskPoint.GetComponent<Renderer>().material.color = taskPoint.GetComponent<MusicObj>().Color;
        taskPoint.GetComponent<MusicObj>().CurrentColor = taskPoint.GetComponent<MusicObj>().Color; 
        taskPoint.GetComponent<MusicObj>().TheOne = true;
        anim.Play("sphereAnimation");
    }
    
    public int boolToInt()
    {
        if (VR)
            return 1;
        return 0;
    }

    public void FinishTask()
    {
        switch (taskID)
        {
            case 1:
                EndTaskOne();
                break;
            case 2:
                EndTaskTwo();
                break;
            case 3:
                EndTaskThree();
                break;
            case 4:
                EndTaskFour();
                break;
            default:
                UnityEngine.Debug.Log("Defina uma tarefa");
                break;
        }
    }
}
