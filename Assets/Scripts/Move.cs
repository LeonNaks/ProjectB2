/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed;
    private bool isRight;
    private bool isLeft;

    void Start()
    {
        isRight = false;
        isLeft = false;
        Debug.Log("Move script initialized.");
    }

    void Update()
    {
        if (isRight)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else if (isLeft)
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
    }

    public void LeftButton()
    {
        isLeft = true;
        isRight = false;
    }

    public void RightButton()
    {
        isRight = true;
        isLeft = false;
    }

    public void StopMovement()
    {
        isRight = false;
        isLeft = false;
        Debug.Log("Movement stopped.");
    }

    public void ResetMovement()
    {
        StopMovement();
        Debug.Log("Movement reset.");
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed = 10.0f;

    void Update()
    {
        // Kiểm tra xem có chạm trên màn hình không
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));

            // Di chuyển giỏ theo vị trí chạm
            transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);

            // Giới hạn chuyển động để không ra khỏi màn hình
            float screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
            float minX = -screenHalfWidthInWorldUnits;
            float maxX = screenHalfWidthInWorldUnits;
            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }

    public void ResetMovement()
    {
        Debug.Log("Movement reset.");
    }
}



