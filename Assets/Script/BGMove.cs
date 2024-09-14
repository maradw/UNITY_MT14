using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public float speed = 4.3f;
    private Vector2 initialPos;

    void Start()
    {
        initialPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -11.24)
        {
            transform.position = initialPos;
        }
    }
}
