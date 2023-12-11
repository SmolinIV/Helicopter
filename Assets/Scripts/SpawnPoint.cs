using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Helicopter _target;
    [SerializeField] private Enemy _enemyType;

    public Enemy GetEnemyType() => _enemyType;

    public Helicopter GetTarget() => _target;
}
