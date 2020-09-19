using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;

public class Portal : MonoBehaviour
{
    private Transform _target;
    private SpriteRenderer _targetSprite;
    private SpriteRenderer _playerSprite;
    private Transform _player;
    private float _yDis;

    public AudioSource _audio;

    [SerializeField] private float _exitDistance = 1.2f;
    [SerializeField] private float _distance = 0.3f;
    [SerializeField] private bool _isBlue;

    private void Start()
    {
        GameManager.leftMousePressed += ChangePositionBlue;
        GameManager.rightMousePressed += ChangePositionPink;


        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();

        if (_isBlue)
        {
            _target = GameObject.FindGameObjectWithTag("Pink Portal").GetComponent<Transform>();
            _targetSprite = GameObject.FindGameObjectWithTag("Pink Portal").GetComponent<SpriteRenderer>();
        }

        else
        {
            _target = GameObject.FindGameObjectWithTag("Blue Portal").GetComponent<Transform>();
            _targetSprite = GameObject.FindGameObjectWithTag("Blue Portal").GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        _yDis = transform.position.y - _player.position.y;
        
        
    }

    public void ChangePositionBlue(Vector2 pos)
    {
        if (_isBlue)
            transform.position = pos;
        
    }

    public void ChangePositionPink(Vector2 pos)
    {
        if (!_isBlue)
             transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {    

        if (_yDis < -0.5f)
            other.transform.position = new Vector2(_target.position.x, _target.position.y - _exitDistance);
        else if (_yDis > 0.2f)
            other.transform.position = new Vector2(_target.position.x, _target.position.y + _exitDistance);

        _playerSprite.color = _targetSprite.color;
        _audio.Play();

    }
}
