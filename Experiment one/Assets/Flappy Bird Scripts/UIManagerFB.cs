using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerFB : MonoBehaviour
{
    private Text _scoreText;

    private int _score = 0;
    private bool _isPlayerDead = false;
    private bool _isEasy = true;
    private bool _isMedium = false;
    private bool _isHard = false;

    [SerializeField] private Text _finalScoreText;
    [SerializeField] private Text _highScoreText;

    public static event Action ChangeToMedium;
    public static event Action ChangeToHard;
    void Start()
    {
        _scoreText = GameObject.Find("Canvas").GetComponentInChildren<Text>();
   
        _highScoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score:", 0).ToString();
        

        
    }

    void OnEnable()
    {
       ScoreFB.scoreVal += UpdateScore;

       player.onDead += IsPlayerDead;
    }

    void OnDisable()
    {
      ScoreFB.scoreVal -= UpdateScore;

      player.onDead -= IsPlayerDead;
    }

     void Update()
     {
         if(_score > 50 && _isEasy == true && ChangeToMedium != null )
         {
            _isEasy = false;
            _isMedium = true;
            ChangeToMedium();
            
         }

        else if(_score > 100 && _isEasy == false && _isMedium == true && _isHard == false && ChangeToHard != null)
        {
           _isMedium = false;
           _isHard = true;
           ChangeToHard();
        }
     }

    void UpdateScore(object sender, EventArgs e)
    {
         if(!_isPlayerDead)
           _score++;

        _scoreText.text = "Score: " + _score.ToString();
        _finalScoreText.text = "Score: " + _score.ToString();
    }

    void IsPlayerDead()
    {
        _isPlayerDead = true;
        
        if(_score > PlayerPrefs.GetInt("High Score:", 0))
          {
            PlayerPrefs.SetInt("High Score:" , _score);
            _highScoreText.text = "High Score: " + _score.ToString();
          }
    }
}
