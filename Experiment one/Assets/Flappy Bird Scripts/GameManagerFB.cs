using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerFB : MonoBehaviour
{

    public static event Action StopSpawn;
    public static event Action StartSpawn;
    public static event Action PlayerOnStart;
    public static event Action PlayerOnPlaying;
    public static event Action OnEasy;
    public static event Action OnMedium;
    public static event Action OnHard;

    private bool _gameStart = false;

    [SerializeField] private GameObject _ui;

    public enum GameState
    {
        Start,
        Playing,
        End

    }
    
    public enum Difficulties
    {
        Easy,
        Medium,
        Hard

    }

    GameState currentState;
    Difficulties currentDifficulty;


    void OnEnable()
    {
      currentState = GameState.Start;

      currentDifficulty = Difficulties.Easy;

      player.onDead += ChangeToEnd;

      UIManagerFB.ChangeToMedium += ChangeTomedium;

      UIManagerFB.ChangeToHard += ChangeTohard;

      _ui.SetActive(true);
    }
    
    void OnDisable()
    {
     player.onDead -= ChangeToEnd;
     UIManagerFB.ChangeToMedium -= ChangeTomedium;
     UIManagerFB.ChangeToHard -= ChangeTohard; 
    }
   
    void Update()
    {
        
        CurrentGameState();
        CheckIfStarted();
        Difficulty();

       
    } 

    void CheckIfStarted()
    {
       if((Input.GetKeyDown(KeyCode.Space) && _gameStart == false) || (Input.GetMouseButtonDown(0) && _gameStart == false))
         {
           ChangeToPlay();
           _gameStart = true;
           _ui.SetActive(false);
         }
    }

    void CurrentGameState()
     {
      switch(currentState)
        {
            case GameState.Start: 

                if(PlayerOnStart != null)
                 PlayerOnStart();

                break;


            case GameState.Playing:
                
                
                if(StartSpawn != null)
                  StartSpawn();

                if(PlayerOnPlaying != null)
                  PlayerOnPlaying();

                break;


            case GameState.End:

                
                if(StopSpawn != null)
                  StopSpawn();

                break;

        }
     }
     
    void Difficulty()
    {
       switch(currentDifficulty)
       {
        case Difficulties.Easy:
         break;
     
        case Difficulties.Medium:

         if(OnMedium != null)
          OnMedium();

         break;

        case Difficulties.Hard:
          
          if(OnHard != null)
            OnHard();

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
  
    void ChangeTomedium()
    {
      currentDifficulty = Difficulties.Medium;
    }

    void ChangeTohard()
    {
      currentDifficulty = Difficulties.Hard;
    }
    
}
