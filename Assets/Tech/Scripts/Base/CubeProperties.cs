using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Other;

public class CubeProperties : MonoBehaviour
{
    [SerializeField]
    EnumCubeType cubeType = EnumCubeType.NormalBlock;
    

    private void Start()
    {
    }
    
    public EnumCubeType GetBlockType()
    {
        return cubeType;
    }

    /// <summary>
    /// This takes in the ray cast to see where the click is coming from, then calculate on which face
    /// to add 1 unit to that direction to give a location to instantiate a new block.
    /// </summary>
    /// <param name="_rayHit">The raycast hit used to find the block to begin with</param>
    /// <returns>This returns a Vector3 of the location to instantiate a new ship block</returns>
    public Vector3 GetLocationToBuildBlock(RaycastHit _rayHit)
    {
        Vector3 _incomingVec = _rayHit.normal - Vector3.up;

        if (_incomingVec == new Vector3(0, -1, -1))
            return gameObject.transform.position + Vector3.back;
        if (_incomingVec == new Vector3(0, -1, 1))
            return gameObject.transform.position + Vector3.forward;
        if (_incomingVec == new Vector3(0, 0, 0))
            return gameObject.transform.position + Vector3.up;
        if (_incomingVec == new Vector3(1, 1, 1))
            return gameObject.transform.position + Vector3.down;
        if (_incomingVec == new Vector3(-1, -1, 0))
            return gameObject.transform.position + Vector3.left;
        if (_incomingVec == new Vector3(1, -1, 0))
            return gameObject.transform.position + Vector3.right;

        return new Vector3(0, 0, 0);
    }

    /// <summary>
    /// This takes in the ray cast to see where the click is coming from, then calculate on which face
    /// to add 1 unit to that direction to give a location to return a EnumDirection.
    /// </summary>
    /// <param name="_rayHit">The raycast hit used to find the block to begin with</param>
    /// <returns>This returns a EnumDirection in relation to the clicked block</returns>
    public virtual EnumDirection GetLocationOfHit(RaycastHit _rayHit)
    {
        Vector3 _incomingVec = _rayHit.normal - Vector3.up;

        if (_incomingVec == new Vector3(0, -1, -1))
            return EnumDirection.Back;
        if (_incomingVec == new Vector3(0, -1, 1))
            return EnumDirection.Front;
        if (_incomingVec == new Vector3(0, 0, 0))
            return EnumDirection.Top;
        if (_incomingVec == new Vector3(1, 1, 1))
            return EnumDirection.Bottom;
        if (_incomingVec == new Vector3(-1, -1, 0))
            return EnumDirection.Left;
        if (_incomingVec == new Vector3(1, -1, 0))
            return EnumDirection.Right;

        return EnumDirection.NULL;
    }


    /// <summary>
    /// To be called on right click to destroy a block if !invincible
    /// </summary>
    public void DestroyBlock()
    {
        if (cubeType != EnumCubeType.Invincible)
        {
            Destroy(gameObject);
        }
    }
}
