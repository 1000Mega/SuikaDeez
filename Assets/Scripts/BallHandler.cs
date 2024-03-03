using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public float ballSpeed = 2f;
    public float gameBounds = 10f;
    Vector3 ballDir = Vector3.zero;
    Vector3 lastPos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        ballDir = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        lastPos = transform.position;

        //Destroy on exiting boundary
        if(Mathf.Abs(transform.position.x) > gameBounds || Mathf.Abs(transform.position.y) > gameBounds) 
        {
            Destroy(gameObject);
        }
            
        transform.position += ballDir * Time.deltaTime * ballSpeed;
        //print(transform.up);
    }

    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //we should check for walls (bounces), merges, sticks?

        //Wall Layer Mask (6)
        if (collision.gameObject.layer == 6) 
        {
            print(transform.position.x);
            print(lastPos.x);
            transform.position = lastPos;
            ballDir = new Vector3(-ballDir.x, ballDir.y, ballDir.z);
        }       
    }    
}
