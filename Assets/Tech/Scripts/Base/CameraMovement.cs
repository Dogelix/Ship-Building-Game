using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera camera;
    private float sensitivety = 10f;
    private float lowerLimit = 30f;
    private float upperLimit = 120f;
    private float fov;

    private void Start()
    {
        camera = gameObject.GetComponentInChildren<Camera>();
    }

    public void ZoomCamera(float change)
    {
        fov = camera.fieldOfView;
        fov += change * sensitivety;
        fov = Mathf.Clamp(fov, lowerLimit, upperLimit);
        camera.fieldOfView = fov;
    }
}
