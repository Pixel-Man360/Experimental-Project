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
        player.onDead += () => { _isOver = true; } ;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        DestroyObject();
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

   
}