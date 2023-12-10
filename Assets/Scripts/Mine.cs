using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _movingSpeed;

    private Rigidbody2D _rigidbody;
    private Coroutine _growingCoroutine;

    private Vector2 _direction;
    private float _creationScale;
    private float _normalScale;

    private void Start()
    {
        _creationScale = 0.5f;
        _normalScale = 2.0f;
        transform.localScale = new Vector2(_creationScale, _creationScale);

        _growingCoroutine = StartCoroutine(Grow());

        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(_direction * _movingSpeed * Time.deltaTime);
    }

    private void OnValidate()
    {
        int minSpeed = 1;

        if (_movingSpeed < minSpeed)
            _movingSpeed = minSpeed;
    }

    private void OnBecameInvisible()
    {
        StopCoroutine(_growingCoroutine);
        Destroy(gameObject);
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private IEnumerator Grow()
    {
        while (transform.localScale.x <= _normalScale)
        {
            transform.localScale = new Vector2(transform.localScale.x + Time.deltaTime, transform.localScale.y + Time.deltaTime);

            yield return null;
        }
    }

}
