using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _isOver;
    [SerializeField] private float _speed;

    
    void Start()
    {
        _isOver = false;
        _rb = GetComponent<Rigidbody2D>();
        
    }

    
    void OnEnable()
    {
      player.onDead += IsDead;

      GameManagerFB.OnMedium += Medium;
 
      GameManagerFB.OnHard += Hard;

      _speed = 8f;
    }
    
    void OnDisable()
    {
      GameManagerFB.OnMedium -= Medium;
 
      GameManagerFB.OnHard -= Hard;

      player.onDead -= IsDead;
    }
    
    void Update()
    {
        Movement();
        DestroyObject();

       Debug.Log("Speed: " +_speed);
    }

    void Movement()
    {
        if (_isOver == false)
            _rb.velocity = Vector2.left * _speed;

        else
            _rb.velocity = Vector2.zero;
    }
    
    void DestroyObject()
    {
        if (this.transform.position.x < -25f)
            Destroy(this.gameObject);
    }

    void IsDead()
    {
        _isOver = true;
    }
   
    void Medium()
    {
      _speed = 10f;
    }

    void Hard()
    {
       _speed = 12.5f;
    }
   
}