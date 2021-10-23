using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private bool _isLaunched = false;
    private Rigidbody _rigidbody;
    private Transform _engine;
    private ParticleSystem _particleSystem;

    [SerializeField]
    private float _fuel = 100f;
    private float _power = 35f;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _engine = gameObject.transform.Find("Engine");
        _particleSystem = gameObject.transform.Find("Engine/Particle System").GetComponent<ParticleSystem>();
    }

    private void OnMouseDown()
    {
        _isLaunched = true;
        _particleSystem.Play();
    }

    private void FixedUpdate()
    {
        if (_isLaunched && _fuel > 0)
        {            
            Vector3 force = gameObject.transform.forward * _power;
            _rigidbody.AddForceAtPosition(force, _engine.position);
            _fuel -= 1;
        }
    }

    private void Update()
    {
        if (_isLaunched && _fuel == 0)
        {
            _particleSystem.Stop();
        }
    }

}
