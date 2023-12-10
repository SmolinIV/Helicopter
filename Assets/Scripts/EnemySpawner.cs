using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyBehaviour _enemy;
    [SerializeField] private int _spawnFrequency;

    private SpawnPoint[] _spawnPoints;
    private SpawnPoint _currentSpawn;
    private float _timeLeft;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    private void Update()
    {
        _timeLeft += Time.deltaTime;

        if (_timeLeft >= _spawnFrequency)
        {
            _currentSpawn = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

            Instantiate(_enemy, _currentSpawn.transform).SetDirection(Random.insideUnitCircle.normalized);

            _timeLeft = 0;
        }
    }
}

