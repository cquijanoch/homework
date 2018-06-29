using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGuide : MonoBehaviour {

    // Use this for initialization
    public int taskID;
    public int userID;

	void Start () {
        //StartExperiment()
    }

    private void Update()
    {
        /*Collect data from the user input (mouse or controller)*/
    }

    public void StartExperiment()
    {
        //Set experiment variables
        //TaskOne()
        //TaskTwo()
        //TaskThree()
        //FinishExperiment

    }

    public void TaskOne ()
    {
        /*In this task a song A will be selected (colored) and the user has to find the nearest song to A of another artist */
        //Step 1: set the task ID
        taskID = 1;
        //Step 1.5: Maybe it would be good to provide the task instructions with some text?
        //Step 2: color (and lock the color of) the song
        //Step 3: wait for the input from the participant
        //Step 4: record the answer 

    }

    public void TaskTwo()
    {
        /*In this task a genre A will be selected (colored) and the user has to find the 3 most similar songs of this genre */
        //Step 1: set the task ID
        taskID = 2;
        //Step 2: color (and lock the color of the) the genre
        //Step 3: wait for the input from the participant
        //Step 4: record the answer 

    }

    public void TaskThree()
    {
        /*In this task a genre A and a song will be selected (colored) and the user has to find the furthest song of the same genre to the song A */
        //Step 1: set the task ID
        taskID = 3;
        //Step 2: color (and lock the color of the) the genre and the song

        //Step 3: wait for the input from the participant
        //Step 4: record the answer 

    }


}
