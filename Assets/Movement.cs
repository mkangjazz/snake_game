using UnityEngine;

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
    public GameObject snake_body;

    private float speed = 2f;
    private float bodyTimer= 0.0f;
    private float bodyWait = 0.5f;

    private Direction dir = Direction.RIGHT;

    private bool isKeyDown = false;
    private float keyDelay = 1.0f;
    private float keyTimer = 0.0f;

    private void Update()
    {
        this.keyTimer += Time.deltaTime;
        this.bodyTimer += Time.deltaTime;

        this.Move();

        if (true)
        {
            this.CreateBodyAtPosition();
            //this.bodyTimer = bodyTimer - this.waitTime;
        }

        Debug.Log("isKeyDown: " + isKeyDown);

        if (
            Input.GetKeyDown("left") ||
            Input.GetKeyDown("a") ||
            Input.GetKeyDown("right") ||
            Input.GetKeyDown("d")
        )
        {
            isKeyDown = true;
        }

        if (
            Input.GetKeyUp("left") ||
            Input.GetKeyUp("a") ||
            Input.GetKeyUp("right") ||
            Input.GetKeyUp("d")
        )
        {
            isKeyDown = false;
        }

        if (
            Input.GetKeyDown("left") ||
            Input.GetKeyDown("a")
        )
        {
            if (
                this.keyTimer > this.keyDelay
            )
            {
                this.TurnLeft();
            }
        }
        
        if (
            Input.GetKeyDown("right") ||
            Input.GetKeyDown("d")
        )
        {
            if (
                this.keyTimer > this.keyDelay
            )
            {
                this.TurnRight();
            }
        }
    }
    private void CreateBodyAtPosition()
    {
        Debug.Log("CreateBodyAtPosition " + rigidBody.position);
        Instantiate(snake_body, rigidBody.position, Quaternion.identity);
    }

    private void Move()
    {
        if (this.dir == Direction.RIGHT)
        {
            transform.position = transform.position + new Vector3(this.speed, 0, 0) * Time.deltaTime;
        }
        else if (this.dir == Direction.UP)
        {
            transform.position = transform.position + new Vector3(0, 0, this.speed) * Time.deltaTime;
        }
        else if (this.dir == Direction.LEFT)
        {
            transform.position = transform.position + new Vector3(-this.speed, 0, 0) * Time.deltaTime;
        }
        else if (this.dir == Direction.DOWN)
        {
            transform.position = transform.position + new Vector3(0, 0, -this.speed) * Time.deltaTime;
        }
    }

    private void ResetKeyTimer()
    {
        // Unity says subtracting time elapsed is more accurate over time than resetting to zero...
        this.keyTimer = 0;
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

        this.ResetKeyTimer();
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

        this.ResetKeyTimer();
        Debug.Log("turn right:" + this.dir);
    }
}
