using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHideShow : MonoBehaviour {
    public bool isLocked;
    CursorLockMode wantedMode;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    // Use this for initialization
    void Start ()
    {

        //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        //setCursorLock(isLocked);
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

    }

    void setCursorLock(bool isLocked)
    {
        this.isLocked = isLocked;
        Cursor.visible = !isLocked;
        Cursor.lockState = wantedMode = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
       
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log("P");
            //setCursorLock(!isLocked);
        }	
	}
}
