using System;
using UnityEngine;

public class ScoreFB : MonoBehaviour
{

    public static event EventHandler scoreVal;
    

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.name == "Player")
        {


            if (scoreVal != null)
                scoreVal?.Invoke(this, EventArgs.Empty);

           
        }
    }

    
}
