using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private float speed = 5.0f;

     void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
