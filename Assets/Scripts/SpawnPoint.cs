using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Helicopter _target;
    [SerializeField] private EnemyBehaviour _enemyType;

    public Vector3 GetTargetPosition() => _target.transform.position;

    public EnemyBehaviour GetEnemyType() => _enemyType;
}
