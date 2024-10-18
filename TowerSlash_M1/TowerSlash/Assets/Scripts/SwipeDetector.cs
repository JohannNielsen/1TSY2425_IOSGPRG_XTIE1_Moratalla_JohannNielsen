using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    public GameObject swipeDirection;
    private void Update()
    {
        _ArrowDirection _localSwipe = swipeDirection.gameObject.GetComponent<TouchInputs>()._swipeDirections;
        Debug.Log("Swipe: " + _localSwipe);
    }
}
