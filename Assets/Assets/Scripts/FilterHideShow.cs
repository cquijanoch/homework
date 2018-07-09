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
    public GameObject rightCollider;
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
            if (isLockedFilter)
            {
                if (!isLockedSelected)
                {
                    Shutdown(selectedObj);
                    isLockedSelected = !isLockedSelected;
                }
                Show(filterCanvas);
            }
            else {
                Hide(filterCanvas);
            }
            
            isLockedFilter = !isLockedFilter;
        }
        else if (Input.GetKeyUp(KeyCode.E) || (ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Menu)))
        {
            if (isLockedSelected)
            {
                if (!isLockedFilter)
                {
                    Hide(filterCanvas);
                    isLockedFilter = !isLockedFilter;
                }
                PowerUp(selectedObj);
            }
            else
            {
                //Show(filterCanvas);
                Shutdown(selectedObj);
            }
            
            isLockedSelected = !isLockedSelected;
        }
    }

    void Hide(CanvasGroup canvas)
    {
        //isLockedFilter = false;
        canvas.alpha = 0f;
        canvas.blocksRaycasts = false;
        if (rightCollider)
            rightCollider.SetActive(true);
    }

    void PowerUp(GameObject canvas)
    {
        //isLockedSelected = true;
        canvas.SetActive(true);
        canvas.GetComponent<CanvasGroup>().alpha = 1f;
        canvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }


    void Shutdown(GameObject canvas)
    {
        //isLockedSelected = false;
        canvas.SetActive(false);
        canvas.GetComponent<CanvasGroup>().alpha = 0f;
        canvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    void Show(CanvasGroup canvas)
    {
        //isLockedFilter = true;
        if (rightCollider)
            rightCollider.SetActive(false);
        canvas.alpha = 1f;
        canvas.blocksRaycasts = true;
    }
}
