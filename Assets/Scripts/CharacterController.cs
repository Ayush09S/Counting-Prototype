using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Camera playerCam;
    public Vector2 turn;

    public int speed = 2;
    [SerializeField] private float sensitivity = 1f;
    private Rigidbody rb;
    public static KeyCode sprintKey;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Menus.isGameActive)
        {
            Cursor.lockState = CursorLockMode.Locked;
            /*if (Input.GetKey(PlayerPrefs.GetString("Sprint Key")))
            {
                speed = 5;
            }
            else
            {
                speed = 2;
            }*/

            turn.x += Input.GetAxis("Mouse X") * sensitivity;
            turn.y = Mathf.Clamp(turn.y + Input.GetAxis("Mouse Y") * sensitivity, -90, 90);

            transform.localRotation = Quaternion.Euler(0, turn.x, 0);
            playerCam.transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            rb.velocity = transform.forward * verticalInput * speed + transform.right * horizontalInput * speed;

            playerCam.transform.position = transform.position;
        }
    }
}
