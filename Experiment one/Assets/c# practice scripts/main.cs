using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public delegate void OnSpacePressed();
    public static event OnSpacePressed spacePressed;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            spacePressed(); 
        }

    }
}
