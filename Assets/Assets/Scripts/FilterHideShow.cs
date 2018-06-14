using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterHideShow : MonoBehaviour {
    public bool isLocked;
    CanvasGroup filterCanvas;
    void Start ()
    {
        GameObject filterObj = GameObject.FindGameObjectWithTag("FilterCanvas");
        filterCanvas = filterObj.GetComponent<CanvasGroup>();

    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.F))
        {
            if (isLocked) Show(); else Hide();
            isLocked = !isLocked;
        }
    }

    void Hide()
    {
        filterCanvas.alpha = 0f; //this makes everything transparent
        filterCanvas.blocksRaycasts = false; //this prevents the UI element to receive input events
    }

    void Show()
    {
        filterCanvas.alpha = 1f;
        filterCanvas.blocksRaycasts = true;
    }
}
