using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Helicopter : MonoBehaviour 
{
    [SerializeField, Min(1)] private int _movingSpeed;
    [SerializeField, Min(1)] private float _movingDuration;

    [SerializeField] private Vector2 _movingDirection;

    private float _movingTime;

    private void Start()
    {
        _movingTime = 0f;
    }

    private void Update()
    {
        int directionSignChanger = -1;

       _movingTime += Time.deltaTime;

        if (_movingTime >= _movingDuration)
        {
            _movingDirection *= directionSignChanger;
            _movingTime = 0;
        }

        transform.Translate(_movingDirection.normalized * _movingSpeed * Time.deltaTime);
    }
}