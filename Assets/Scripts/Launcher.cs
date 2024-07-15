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
    public Transform LaunchOffset;

    Rigidbody2D rb;

    //bool fire;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.SetRotation(aimAngle);
        ChooseNextBall();
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
            Instantiate(BallPrefab, LaunchOffset.position, transform.rotation);
            BallPrefab.ballColour = ChooseNextBall();
        }

    }

    void FixedUpdate()
    {

    }

    //In case we want some more logic rather than randomness
    int ChooseNextBall()
    {
        nextBall = Random.Range(1, 3);

        return nextBall;
    }
}
