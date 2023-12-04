using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserControl : MonoBehaviour
{
    public float speed;
    //public GameObject enemy;
    private Rigidbody2D _compRigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
            
        
    }
    void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector2(0,speed*1);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }

}
