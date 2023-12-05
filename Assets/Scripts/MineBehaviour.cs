using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehaviour : MonoBehaviour
{
    [SerializeField] private int _movingSpeed;

    private Rigidbody2D _rigidbody;

    private float _creationScale;
    private float _normalScale;
    private Vector2 _direction;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _creationScale = 0.5f;
        _normalScale = 1.0f;
        transform.localScale = new Vector2(_creationScale, _creationScale);

        _rigidbody.AddForce(_direction * _movingSpeed * Time.deltaTime);
    }

    private void OnValidate()
    {
        if (_movingSpeed <= 0)
            _movingSpeed = 1;
    }

    private void Update()
    {
        if (transform.localScale.x <= _normalScale)
        {
            transform.localScale = new Vector2(transform.localScale.x + Time.deltaTime, transform.localScale.y + Time.deltaTime);

            if (transform.localScale.x > _normalScale)
                transform.localScale = Vector2.one;
        }
    }
}
