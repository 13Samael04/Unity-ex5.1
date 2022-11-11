using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Moving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float translationHorizontal = Input.GetAxis("Horizontal") * _speed;
        float translationVertical = Input.GetAxis("Vertical") * _speed;
        transform.Translate(translationHorizontal * Time.deltaTime, translationVertical * Time.deltaTime, 0);
    }
}
