using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBall : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    public float distance = 2f; // Distance from the camera
    public float height = 1f; // Height above the camera

    private GameObject ball;
    private float ballDistance;
    private Vector3 ballPos;
    private Vector3 playerPos;

    public static bool isHolding = false;

    void FixedUpdate()
    {
        ball = GameObject.FindWithTag("Ball");
        playerPos = transform.position;
        ballPos = ball.transform.position;
        ballDistance = Vector3.Distance(playerPos, ballPos);

        // Check if the left mouse button is held down
        if (Input.GetMouseButtonDown(0) && ballDistance < 3.5)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the ball
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Ball"))
            {
                isHolding = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isHolding = false;
        }

        // Move the ball while holding the left mouse button
        if (isHolding)
        {
            // Calculate the desired position based on camera's forward direction
            Vector3 targetPosition = mainCamera.transform.position + mainCamera.transform.forward * distance;

            // Set the position of the object
            ball.transform.position = targetPosition;

            // Make the object look at the camera
            ball.transform.LookAt(mainCamera.transform);
        }
    }
}