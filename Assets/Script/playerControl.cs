using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerControl : MonoBehaviour
{
    [SerializeField] float speedX;
    public GameObject laserPreFab;
    public AudioSource _compAudioSourse;
    private Rigidbody2D _compRBD;
    private float _horizontal;

   

    private void Awake()
    {
        _compRBD= GetComponent<Rigidbody2D>();
    }
    public void OnMovement(InputAction.CallbackContext move)
    {
        _horizontal = move.ReadValue<float>();

    }
    public void OnShoot (InputAction.CallbackContext shoot)
    {
        if (shoot.performed)
        {
            _compAudioSourse.Play();
            Instantiate(laserPreFab, transform.position, transform.rotation);
        }
    }

    void Update()
    {        
    }
    public void FixedUpdate()
    {
        _compRBD.velocity = new Vector2(_horizontal * speedX, 0);
    }
}
