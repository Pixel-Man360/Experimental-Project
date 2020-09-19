using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerFB : MonoBehaviour
{

    public static event Action StopSpawn;
    public static event Action StartSpawn;

    public enum GameState
    {
        Start,
        Playing,
        End

    }

    GameState currentState;

    void Start()
    {
        currentState = GameState.Start;

        player.onDead += ChangeToEnd;
        player.onPlaying += ChangeToPlay;


    }

   
    void Update()
    {
        switch(currentState)
        {
            case GameState.Start:

                if (StopSpawn != null)
                    StopSpawn();

                break;


            case GameState.Playing:

                if (StartSpawn != null)
                    StartSpawn();

                break;


            case GameState.End:

                if (StopSpawn != null)
                    StopSpawn();

                break;

        }
    }

    void ChangeToStart()
    {
        currentState = GameState.Start;
    }

    void ChangeToPlay()
    {
        currentState = GameState.Playing;
    }

    void ChangeToEnd()
    {
        currentState = GameState.End;
    }

    
}
