using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public enum Direction
    {
        Left = -1,
        Right = 1
    }

    private float distance = 50f;
    public Rigidbody rb;

    public void Move(Direction direction)
    {
        if(direction == Direction.Left)
        {
            rb.MovePosition(Vector3.left * distance);

        }
        if (direction == Direction.Right)
        {

            rb.MovePosition(Vector3.right * distance);

        }
    }

    public void ResetPosition()
    {
        rb.MovePosition(new Vector3(0.0f, 1.0f, 0.0f));
    }
}
