using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerControl : MonoBehaviour
{
    public GameObject enemyPrefab;
    float time;
    void Start()
    {
        time = Random.Range(0.1f, 1.2f);
        Invoke("CreateEnemy", time);
    }
    void CreateEnemy()
    {
        float x = Random.Range(-7f, 7f);
        Vector2 position = new Vector2(x, 5.7f);
        Instantiate(enemyPrefab, position, transform.rotation);
        Invoke("CreateEnemy", time);

    }
}
