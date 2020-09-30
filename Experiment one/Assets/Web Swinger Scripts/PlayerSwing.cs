using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
   [SerializeField] private Camera _mainCamera;
   [SerializeField] private LineRenderer _lineRenderer;
   [SerializeField] private DistanceJoint2D _distanceJoint;
   [SerializeField] private Rigidbody2D _rb;
    
    void Start()
    {
        _distanceJoint.enabled = false;
        _lineRenderer.startColor = Color.white;
        _lineRenderer.endColor = Color.white;     
        _lineRenderer.material.color = Color.white;
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
         {
           Vector2 mousePos = (Vector2) _mainCamera.ScreenToWorldPoint(Input.mousePosition);
           _lineRenderer.SetPosition(0, mousePos);
           _lineRenderer.SetPosition(1, transform.position);
           _distanceJoint.connectedAnchor = mousePos;
           _distanceJoint.enabled = true;
           _lineRenderer.enabled = true;
         }

        else if(Input.GetMouseButtonUp(0))
         {
           _distanceJoint.enabled = false;
           _lineRenderer.enabled = false;
         }
  
         if(_distanceJoint.enabled)
          {
              _lineRenderer.SetPosition(1,transform.position);
          }
    }
}
