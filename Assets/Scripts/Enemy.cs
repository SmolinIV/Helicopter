using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Min(1)] private int _movingSpeed;

    private Coroutine _growingCoroutine;

    private Helicopter _target;
    private Vector3 _directionToTarget;

    private float _creationScale;
    private float _normalScale;

    private void Start()
    {
        _creationScale = 0.5f;
        _normalScale = 2.0f;
        transform.localScale = new Vector2(_creationScale, _creationScale);

        _growingCoroutine = StartCoroutine(Grow());
    }

    private void OnValidate()
    {
        int minSpeed = 1;
        
        if (_movingSpeed < minSpeed)
            _movingSpeed = minSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Helicopter>(out Helicopter target) == true)
        {
            StopCoroutine(_growingCoroutine);
            Destroy(gameObject);
        }
    }

    public void SetTarget(Helicopter target)
    {
        _target = target;
        _directionToTarget = (_target.transform.position - transform.position).normalized;

        Rigidbody2D rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.AddForce(_directionToTarget * Time.deltaTime * _movingSpeed);
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
