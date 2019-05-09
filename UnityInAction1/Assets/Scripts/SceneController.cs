using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemy;

    private void Update()
    {
        if(enemy == null)
        {
            enemy = Instantiate(enemyPrefab) as GameObject;
            Vector3 spawnPosition = new Vector3(Random.Range(20, -20), 1.5f, Random.Range(20, -20));
            enemy.transform.position = spawnPosition;
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
    }
}
