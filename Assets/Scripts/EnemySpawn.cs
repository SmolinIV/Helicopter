using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _mine;

    public void CreateNewEnemy()
    {
        Vector2 direction = Random.insideUnitCircle.normalized;

        Debug.Log("направление - " + direction);

        GameObject createdMine = Instantiate(_mine, transform);
        createdMine.GetComponent<MineBehaviour>().SetDirection(direction);
    }
}
