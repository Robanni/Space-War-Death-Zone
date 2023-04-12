using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 currentPosition;

    private Camera cam;

    private float width;
    private float height;

    void Awake()
    {
        width = (float)Screen.width;
        height = (float)Screen.height;

    }
    void Start()
    {
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        currentPosition = transform.position;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                currentPosition = cam.ScreenToWorldPoint(touch.position);
            }
        }

        if (Input.mousePosition != null)
        {

            currentPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            
        }
        transform.position = currentPosition;
    }
}
