using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private FixedJoystick joystick;

    private void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;

            player.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90));
        }
    }
}