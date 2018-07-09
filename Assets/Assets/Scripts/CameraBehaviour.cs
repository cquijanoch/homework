using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    //private int zoom = 20;
    //private int normal = 60;
    //   private float smooth = 5;
    // Use this for initialization
    public GameObject filterDialog;
    FilterHideShow scFilterDialog_;
    
	void Start () {

        scFilterDialog_ = filterDialog.GetComponent<FilterHideShow>();
    }

    // Update is called once per frame
    void Update() {
        
        if (scFilterDialog_.isLockedFilter)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && GetComponent<Camera>().fieldOfView > 30)
            {
                // GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
                GetComponent<Camera>().fieldOfView--;
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0 && GetComponent<Camera>().fieldOfView < 90)
            {
                // GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
                GetComponent<Camera>().fieldOfView++;

            }
        }

        


    }
}
