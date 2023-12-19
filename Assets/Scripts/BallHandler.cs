using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public float ballSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * ballSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //we should check for walls (bounces), merges, sticks?
    }    
}
