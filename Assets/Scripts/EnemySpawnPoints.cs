using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoints : MonoBehaviour
{
    [SerializeField] private int _spawnFrequency;

    private GameObject[] _spawnPoints;
    private float _timeLeft;

    private void Start()
    {
        _spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
    }

    private void Update()
    {
        _timeLeft += Time.deltaTime;

        if (_timeLeft >= _spawnFrequency)
        {
            _spawnPoints[Random.Range(0, _spawnPoints.Length)].GetComponent<EnemySpawn>().CreateNewEnemy();
            _timeLeft = 0;
        }
    }


}
