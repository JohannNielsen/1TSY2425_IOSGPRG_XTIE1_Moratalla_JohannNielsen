using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        movement.Normalize();
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
}