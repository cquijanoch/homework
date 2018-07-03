using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterHideShow : MonoBehaviour {
    public bool isLockedFilter;
    public bool isLockedSelected;
    CanvasGroup filterCanvas;
    public GameObject filterObj;
    public GameObject selectedObj;
    void Start ()
    {
        filterCanvas = filterObj.GetComponent<CanvasGroup>();
        
        if (isLockedFilter)
            Hide(filterCanvas);
        if (isLockedSelected)
            Shutdown(selectedObj);

    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.F) || (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Menu)))
        {
            if (isLockedFilter) Show(filterCanvas); else Hide(filterCanvas);
            isLockedFilter = !isLockedFilter;
        }
        else if (Input.GetKeyUp(KeyCode.E) || (ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Menu)))
        {
            if (isLockedSelected) PowerUp(selectedObj); else Shutdown(selectedObj);
            isLockedSelected = !isLockedSelected;
        }
    }

    void Hide(CanvasGroup canvas)
    {
        canvas.alpha = 0f;
        canvas.blocksRaycasts = false;
    }

    void PowerUp(GameObject canvas)
    {
        canvas.SetActive(true);
    }


    void Shutdown(GameObject canvas)
    {
        canvas.SetActive(false);
    }

    void Show(CanvasGroup canvas)
    {
        canvas.alpha = 1f;
        canvas.blocksRaycasts = true;
    }
}
