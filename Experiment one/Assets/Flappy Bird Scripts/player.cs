using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _rotation;
    [SerializeField] private ParticleSystem _particle;
   
    private bool _hit = false;
    private bool _once = true;
    private Rigidbody2D _rb;
    
    public static event Action onDead;
    public static event Action onPlaying;

 
    void OnEnable()
    {
       GameManagerFB.PlayerOnStart += OnStart;
       GameManagerFB.PlayerOnPlaying += OnPlaying;
       _rb = GetComponent<Rigidbody2D>();
       _once = true;
    }
    void OnDisable()
    {
      GameManagerFB.PlayerOnStart -= OnStart;
      GameManagerFB.PlayerOnPlaying -= OnPlaying;
    }
 
    void Update()
    {

        if((Input.GetKey(KeyCode.Space) && _once) || (Input.GetMouseButton(0) && _once))
        {
            _once = false;
            if (onPlaying != null)
                onPlaying();
           OnPlaying();
        }

        if(!_hit)
        {
           Rotate();
        }

        Inputs();

        
    }

    void Inputs()
    {

        if( (Input.GetKey(KeyCode.Space) && !_hit) || ( Input.GetMouseButton(0) && !_hit))
        {
           
            Jump();
        }
       
    }
    void Jump()
    {
        _rb.velocity = Vector2.up * _force * Time.deltaTime;
    }


    void Rotate()
    {
         transform.rotation = Quaternion.Euler(new Vector3(0, 0, _rb.velocity.y + _rotation));
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _hit = true;
       if(onDead != null)
          onDead();
    }

    void OnStart()
    {
        
        _rb.bodyType = RigidbodyType2D.Static;
        _particle.Stop();

    }

    void OnPlaying()
    {
        _hit = false;
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _particle.Play();
    }
}
