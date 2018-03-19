using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 cameraFocusPoint = new Vector3(0, 0, 0);
    private Camera camera;

    //Zoom Vars
    private float sensitivety = 10f;
    private float lowerLimit = 30f;
    private float upperLimit = 120f;
    private float fov;

    //Movement Vars
    private Vector3 speed = new Vector3();
    [SerializeField]
    private float speedMultiplier = 50;
    private float startTime;

    /// <summary>
    /// This is to set and get the location on which the camera will rotate around.
    /// </summary>
    public Vector3 CameraFocus
    {
        get
        {
            return cameraFocusPoint;
        }
        set
        {
            cameraFocusPoint = value;
        }
    }

    private void Start()
    {
        startTime = Time.time;       
        camera = gameObject.GetComponentInChildren<Camera>();
    }

    /// <summary>
    /// This function changes and clamps the FOV to zoom the camera in and out.
    /// </summary>
    /// <param name="change">The float genereated by the Input.GetAxsis("Scroll") function</param>
    public void ZoomCamera(float change)
    {
        fov = camera.fieldOfView;
        fov += change * sensitivety;
        fov = Mathf.Clamp(fov, lowerLimit, upperLimit);
        camera.fieldOfView = fov;
    }

    /// <summary>
    /// Rotates around the Focus Point of the camera
    /// </summary>
    /// <param name="ad">The Horizontal Input</param>
    /// <param name="ws">The Vertical Input</param>
    /// <param name="qe">The Diagonal Input</param>
    public void MoveCamera(float ad, float ws, float qe)
    {
        ad = ad * speedMultiplier * Time.deltaTime;
        ws = ws * speedMultiplier * Time.deltaTime;
        speed = new Vector3(ws, ad, qe);

        transform.RotateAround(CameraFocus, speed, 1);
        
    }

    /// <summary>
    /// Resets the camera to it's staring rotation and posistion
    /// </summary>
    public void ResetCamera()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        float distCovered = (Time.time - startTime) * speedMultiplier;
        float journeyLength = Vector3.Distance(camera.transform.position, new Vector3(0, 0, -20));
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(camera.transform.position, new Vector3(0, 0, -20), fracJourney);
        transform.LookAt(CameraFocus);
    }
}
