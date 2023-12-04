using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public GameObject laserPreFab;
    //public AudioSource _compAudioSourse;
    private Rigidbody2D _compRigidbody;
    private float horizontal;
    private float vertical;
    // Start is called before the first frame update

    private void Awake()
    {
        _compRigidbody= GetComponent<Rigidbody2D>();
       // _compAudioSourse = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            //_compAudioSourse.Play();
            Instantiate(laserPreFab, transform.position, transform.rotation);

        }
        
    }
    private void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector2(horizontal * speedX, vertical * speedY);
    }
}
