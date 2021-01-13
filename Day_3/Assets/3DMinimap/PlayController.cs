using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5.0f;
    private CharacterController ch;

    const float gravity = 9.81f;

    [SerializeField]
    private float rotationRate = 2.0f;

    float angleX = 0.0f;
    float angleY = 0.0f;
    private void Awake()
    {
        ch = GetComponent<CharacterController>();
    }
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 movement = transform.forward * y * moveSpeed + transform.right * x * moveSpeed;

        if(ch.isGrounded == false)
        {
            movement.y -= gravity;
        }
        ch.Move(movement*Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
        rotateCam(mouseX, mouseY);
    }

    private void rotateCam(float x, float y)
    {
        angleY += x * rotationRate;
        angleX += y * rotationRate;

        transform.rotation = Quaternion.Euler(angleX, angleY, 0);
    }

}
