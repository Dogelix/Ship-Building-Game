using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    CameraMovement camMov;
    // Use this for initialization
    void Start ()
    {
        camMov = gameObject.GetComponent<CameraMovement>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetButton("UnlockCameraRot"))
            camMov.MoveCamera(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Diagonal"));
        if (Input.GetButton("ResetCamera"))
            camMov.ResetCamera();
	}
}