using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform _raycastOrigin;
    [SerializeField] private Transform _playerFeet;
    [SerializeField] private LayerMask _layerMask;

    private RaycastHit2D Hit2D;


    void Update()
    {
        GroundCheckMethod();
    }

    private void GroundCheckMethod()
    {
        Hit2D = Physics2D.Raycast(_raycastOrigin.position, -Vector2.up, 100f, _layerMask);
        if (Hit2D != false)
        {
            Vector2 temp = _playerFeet.position;
            temp.y = Hit2D.point.y;
            _playerFeet.position = temp;
        }
    }
}
