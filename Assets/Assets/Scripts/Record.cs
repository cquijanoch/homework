using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Record : MonoBehaviour {
    StreamWriter fUsersActions;
    StreamWriter fPiecesState;
    StreamWriter fResumed;
    StreamWriter fTaskResults;
    string header;

    public void Log(string result, string filename)
    {
        //fTaskResults = File.CreateText(Application.persistentDataPath+"/Experiments/UserIDTaskIDDataSetIDVR.csv");
        fTaskResults = File.CreateText(Application.persistentDataPath + "/Experiments/"+filename+".csv");
        header = "UserID, TaskID, DatasetID, VR, Time(sec), Clicks, UserAnswerID, CorrectAnswerID, AnswerAccuracy";
        Debug.Log(header);
        Debug.Log(result);

        fTaskResults.WriteLine(header);
        fTaskResults.WriteLine(result);
        flush();
        close();

    }

    public void close()
    {
        /*fUsersActions.Close();
        fPiecesState.Close();
        fResumed.Close();*/
        fTaskResults.Close();
    }

    public void flush()
    {
        fTaskResults.Flush();/*
        fUsersActions.Flush();
        fPiecesState.Flush();
        fResumed.Flush();*/
    }
}
