using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerControl : MonoBehaviour
{
    public GameObject enemyPrefab;
    float time;
    void Start()
    {
        time = Random.Range(0.5f, 2f);
        Invoke("CreateEnemy", time);
    }
    void CreateEnemy()
    {
        float x = Random.Range(-8f, 8f);
        Vector2 position = new Vector2(x, 4.7f);
        Instantiate(enemyPrefab, position, transform.rotation);
        Invoke("CreateEnemy", time);

    }
}
