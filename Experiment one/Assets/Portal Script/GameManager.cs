using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void OnLeftMouseButtonPressed(Vector2 pos);
    public static event OnLeftMouseButtonPressed leftMousePressed;
    public delegate void OnRightMouseButtonPressed(Vector2 pos);
    public static event OnRightMouseButtonPressed rightMousePressed;
    private Vector2 _mousePos;


    private void Update()
    {

        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            if(leftMousePressed != null)
            {
                leftMousePressed(_mousePos);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if(rightMousePressed != null)
            {
                rightMousePressed(_mousePos);
            }
        }
    }
}

