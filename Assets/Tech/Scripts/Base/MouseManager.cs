using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {

    [SerializeField]
    GameObject cubeBuild;

    Ray ray;
    RaycastHit hit;
	// Use this for initialization
	void Start ()
    {
		
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
            Debug.Log("RB Down");
        }
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
}
