using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    public Rigidbody rigidBody;
    private bool isKeyPressed = false;
    public float speed = 2f;
    private Direction dir = Direction.RIGHT;

    private void Update()
    {
        this.Move();

        if (Input.GetKeyUp("left"))
        {
            this.TurnLeft();
        }
        else if (Input.GetKeyUp("right"))
        {
            this.TurnRight();
        }
    }

    private void Move()
    {
        if (this.dir == Direction.RIGHT)
        {
            this.rigidBody.velocity = new Vector3(this.speed, 0, 0);
        }
        else if (this.dir == Direction.UP)
        {
            this.rigidBody.velocity = new Vector3(0, 0, this.speed);
        }
        else if (this.dir == Direction.LEFT)
        {
            this.rigidBody.velocity = new Vector3(-this.speed, 0, 0);
        }
        else if (this.dir == Direction.DOWN)
        {
            this.rigidBody.velocity = new Vector3(0, 0, -this.speed);
        }
    }
    private void TurnLeft()
    {
        if (this.dir == Direction.RIGHT)
        {
            this.dir = Direction.UP;
        }
        else if (this.dir == Direction.UP)
        {
            this.dir = Direction.LEFT;
        }
        else if (this.dir == Direction.LEFT)
        {
            this.dir = Direction.DOWN;
        }
        else if (this.dir == Direction.DOWN)
        {
            this.dir = Direction.RIGHT;
        }

        Debug.Log("turn left: " + this.dir);
    }

    private void TurnRight()
    {
        if (this.dir == Direction.RIGHT)
        {
            this.dir = Direction.DOWN;
        }
        else if (this.dir == Direction.DOWN)
        {
            this.dir = Direction.LEFT;
        }
        else if (this.dir == Direction.LEFT)
        {
            this.dir = Direction.UP;
        }
        else if (this.dir == Direction.UP)
        {
            this.dir = Direction.RIGHT;
        }

        Debug.Log("turn right:" + this.dir);
    }
}
