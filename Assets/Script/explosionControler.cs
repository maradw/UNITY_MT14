using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionControler : MonoBehaviour
{
    public float currentTime;
    float timeLimit = 0.7f;

    private Animator _compAnimator;
    // Start is called before the first frame update
    void Awake()
    {
        _compAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        if (currentTime >= timeLimit)
        {
            Destroy(this.gameObject);
        }
    }
    void DestroidObject()
    {
        Destroy(this.gameObject);
    }
}
