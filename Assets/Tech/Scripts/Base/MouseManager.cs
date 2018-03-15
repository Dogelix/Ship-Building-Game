using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {

    [SerializeField]
    GameObject cubeBuild;

    CameraMovement camMov;
    Ray ray;
    RaycastHit hit;
	// Use this for initialization
	void Start ()
    {
        camMov = gameObject.GetComponent<CameraMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BuildBlock();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            DestroyBlock();
        }

        camMov.ZoomCamera(Input.GetAxis("Scroll"));
    }


    Collider GetHitCollider()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider;
        }
        else
        {
            return null;
        }
    }

    bool CheckForCube()
    {
        if(GetHitCollider().tag == "buildableCube")
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    void BuildBlock()
    {
        if (CheckForCube())
        {
            Collider _collider = GetHitCollider();
            CubeProperties _cubePropertiesScript = _collider.GetComponent<CubeProperties>();
            Vector3 locationToBuild = _cubePropertiesScript.GetLocationToBuildBlock(hit);
            Instantiate(cubeBuild, locationToBuild, new Quaternion(0, 0, 0, 0));
            Debug.Log("Check For Cube Done");   
        }
    }

    void DestroyBlock()
    {
        if (CheckForCube())
        {
            Collider _collider = GetHitCollider();
            CubeProperties _cubeProperties = _collider.GetComponent<CubeProperties>();
            _cubeProperties.DestroyBlock();
        }
    }
}
