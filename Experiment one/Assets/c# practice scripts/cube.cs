using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        main.spacePressed += ChangePosition;
    }

    
    public void ChangePosition()
    {
        transform.position = new Vector3(5, 3, -10);
    }
}
