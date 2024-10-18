using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class TouchInputs : MonoBehaviour
{
    public _ArrowDirection _swipeDirections = _ArrowDirection.Empty;

    private float _deadZone = 1;

    private Vector2 _initialTouchPosition;
    private Vector2 _endTouchPosition;

    private void Start()
    {
        GameManager.instance.SetupSwiping(this.gameObject);
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _initialTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _endTouchPosition = Input.GetTouch(0).position;

            //calculate x and y axis distances
            float swipeDistance = Vector3.Distance(_initialTouchPosition, _endTouchPosition);
            Vector2 distance = _endTouchPosition - _initialTouchPosition;
            float distanceX = Mathf.Abs(distance.x);
            float distanceY = Mathf.Abs(distance.y);

            if (swipeDistance > _deadZone)
            {
                //Down
                if (_initialTouchPosition.y > _endTouchPosition.y && distanceY > distanceX)
                {
                    SetDirection(_ArrowDirection.Down);
                    Debug.Log("SwipeDown");
                }

                // Left
                if (_initialTouchPosition.x > _endTouchPosition.x && distanceX > distanceY)
                {
                    SetDirection(_ArrowDirection.Left);
                    Debug.Log("SwipeLeft");
                }
                // Up
                if (_initialTouchPosition.y < _endTouchPosition.y && distanceY > distanceX)
                {
                    SetDirection(_ArrowDirection.Up);
                    Debug.Log("SwipeUp");
                }
                // Right
                if (_initialTouchPosition.x < _endTouchPosition.x && distanceX > distanceY)
                {
                    SetDirection(_ArrowDirection.Right);
                    Debug.Log("SwipeRight");
                }
            }
            else
            {
                Debug.Log("Tap");
                GameManager.instance.SetBoolDashTap(true);
                GameManager.instance.DashTap();
                SetDirection(_ArrowDirection.Tap);
            }
        }

    }
    public void SetDirection(_ArrowDirection thisItemDirection)
    {
        _swipeDirections = thisItemDirection;
        Invoke(nameof(ResetSwipe), 1.0f);
    }
    public void ResetSwipe()
    {
        _swipeDirections = _ArrowDirection.Empty;
        GameManager.instance.ReturnSpeed();
        if (GameManager.instance.GetBoolDashTap() == true)
        {
            
        }
        GameManager.instance.SetBoolDashTap(false);

    }
}
