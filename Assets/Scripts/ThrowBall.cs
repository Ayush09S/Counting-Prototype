using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    private bool isHoldingball;
    private float startTime;
    [SerializeField] private float heldTime;
    [SerializeField] private float speed;
    private GameObject ball;
    private Rigidbody ballRb;
    private Vector3 ballForceDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isHoldingball = HoldBall.isHolding;
        ball = GameObject.FindWithTag("Ball");
        ballRb = ball.GetComponent<Rigidbody>();

        if (!Menus.isGameActive)
        {
            ballRb.useGravity = false;
        }
        else
        {
            ballRb.useGravity = true;
        }

        if (isHoldingball && Input.GetKeyDown(KeyCode.Space) && Menus.isGameActive)
        {
            startTime = Time.time;
        }
        if (isHoldingball && Input.GetKeyUp(KeyCode.Space) && Menus.isGameActive)
        {
            heldTime = Time.time - startTime;
            ballForceDirection = ball.transform.position - transform.position;
            HoldBall.isHolding = false;
            ballRb.AddForce(speed * heldTime * ballForceDirection, ForceMode.Impulse);
        }
    }
}
