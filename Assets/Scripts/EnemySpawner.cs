using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField, Min(1)] private int _spawnFrequency;

    private SpawnPoint[] _spawnPoints;

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
            CreateNewEnemy();
            _timeLeft = 0;
        }
    }

    private void CreateNewEnemy()
    {
        SpawnPoint _currentSpawn = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        Enemy createdEnemy = Instantiate(_currentSpawn.GetEnemyType(), _currentSpawn.transform);
        createdEnemy.SetTarget(_currentSpawn.GetTarget());
    }
}

