using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField, Range(-90f, 90f)]
    float aimAngle = 0f;

    [SerializeField, Range(0f, 10f)]
    float aimSpeed = 1f;

    int nextBall = 0;

    public BallHandler BallPrefab;
    public BallHandler Next;
    public Transform LaunchOffset;

    Rigidbody2D rb;
    SpriteRenderer sprite;


    //bool fire;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.SetRotation(aimAngle);
        sprite = GetComponentInChildren<SpriteRenderer>();
        ChooseNextBall();

        //Next Ball Viewer
        Next.ballSpeed = 0f;

        //Instantiate(BallPrefab, NextViewer.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical"); //Unneeded? For aim anyway

        aimAngle += (-playerInput.x * aimSpeed); //Negative x input to rotate as expected.
        rb.SetRotation(aimAngle);

        if (Input.GetButtonDown("Jump")) {
            BallPrefab.ballSpeed = 10.0f;
            Instantiate(BallPrefab, LaunchOffset.position, transform.rotation);
            BallPrefab.ballColour = ChooseNextBall();
            //Next.ballColour = ChooseNextBall();
        }

    }

    void FixedUpdate()
    {

    }

    //In case we want some more logic later rather than randomness
    int ChooseNextBall()
    {
        nextBall = Random.Range(1, 4); //min inclusive, max exclusive
        Next.ballColour = nextBall; 
        return nextBall;
    }
}
