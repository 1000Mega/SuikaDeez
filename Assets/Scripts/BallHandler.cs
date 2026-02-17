using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public float ballSpeed = 0f;
    public float gameBounds = 10f;

    public int ballColour = 0;

    Vector3 ballDir = Vector3.zero;
    Vector3 lastPos = Vector3.zero;

    bool ballStuck = false;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        ballDir = transform.up;

        //Set ball colour. Maybe switch case?
        sprite = GetComponentInChildren<SpriteRenderer>();

        setColour();
    }

    // Update is called once per frame
    void Update()
    {
        
        //print(transform.up);
    }

    void FixedUpdate()
    {
        //Destroy on exiting boundary
        if (Mathf.Abs(transform.position.x) > gameBounds || Mathf.Abs(transform.position.y) > gameBounds) {
            Destroy(gameObject);
        }

        lastPos = transform.position;
        setColour();

        if (!ballStuck) {
            transform.position += ballDir * Time.fixedDeltaTime * ballSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //we should check for walls (bounces), merges, sticks?

        //Wall Layer Mask (6)
        if (collision.gameObject.layer == 6) 
        {
            print(transform.position.x);
            print(lastPos.x);
            //transform.position = lastPos;
            ballDir = new Vector3(-ballDir.x, ballDir.y, ballDir.z);
        }       
        //Ceiling collision
        if (collision.gameObject.layer == 7) 
        {
            //transform.position = lastPos;
            ballSpeed = 0;
            ballStuck = true;
        }
        //Ball collision 
        if (collision.gameObject.layer == 8) {
            int collideBall = collision.gameObject.GetComponent<BallHandler>().ballColour;
            //Colours do not match
            if (collideBall != ballColour) {
                ballSpeed = 0;
                ballStuck = true;
            }
            else {
                Destroy(collision.gameObject);
                ballColour++;
                setColour();
                
                //Debug.Log(ballColour);
            }
        }
    } 
    
    void setColour()
    {
        switch (ballColour) {
            case 1:
                sprite.color = Color.red;
                break;

            case 2:
                sprite.color = Color.green;
                break;

            default:
                sprite.color = Color.blue;
                break;
        }
    }
}
