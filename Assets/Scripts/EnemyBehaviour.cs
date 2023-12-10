using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private int _movingSpeed;

    private Coroutine _growingCoroutine;

    private Helicopter _target;
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
        if (_movingSpeed <= 0)
            _movingSpeed = 1;
    }

    public void SetTarget(Helicopter target) => _target = target;

    private IEnumerator Grow()
    {
        while (transform.localScale.x <= _normalScale)
        {
            transform.localScale = new Vector2(transform.localScale.x + Time.deltaTime, transform.localScale.y + Time.deltaTime);

            yield return null;
        }
    }
}
