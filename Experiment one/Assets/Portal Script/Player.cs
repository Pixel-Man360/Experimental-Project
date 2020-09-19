using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _horizontal;
    private float _vertical;
    [SerializeField] private float _speed;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        Movement(_horizontal, _vertical);
    }

    void Movement(float horizontal , float vertical)
    {
        _rb.velocity = new Vector2(horizontal * _speed, vertical * _speed);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, _rb.velocity.x * -1f));
    }
}
