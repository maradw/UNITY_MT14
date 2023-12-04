using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControler : MonoBehaviour
{
    public float speed;
    //public GameObject enemyPrefab;
    private Rigidbody2D _compRigidbody;
    public GameObject explosionPrefab;
    void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateEnemy", 2);
    }
    void CreateEnemy()
    {
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(1f, 4f);
        transform.position = new Vector2(x, y);
        Instantiate(this.gameObject, transform.position, transform.rotation);
        Invoke("CreateEnemy", 2);

    }

    // Update is called once per frame

    void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector2(0, speed * -1);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "laser")
        {
            Destroy(this.gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
  
    }

}
