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
    private Direction dir = Direction.RIGHT;
    private bool isKeyDown = false;
    private float keyDelay = 0.0f;
    private float keyTimer = 0.0f;
    private float moveTimer = 0.0f;

    private GameObject gameManager;

    private void Update()
    {
        this.keyTimer += Time.deltaTime;
        this.moveTimer += Time.deltaTime;

        if (moveTimer > gameManager.GetComponent<GameManagerScript>().GetCurrentLevelInfo().growWaitTime)
        {
            this.Move();
        }

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

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    private void Move()
    {
        var distance = gameObject.GetComponent<Rigidbody>().transform.localScale.x;
        var currPosition = transform.localPosition;

        if (this.dir == Direction.RIGHT)
        {
            transform.position = transform.position + new Vector3(distance, 0, 0);
        }
        else if (this.dir == Direction.UP)
        {
            transform.position = transform.position + new Vector3(0, 0, distance);
        }
        else if (this.dir == Direction.LEFT)
        {
            transform.position = transform.position + new Vector3(-distance, 0, 0);
        }
        else if (this.dir == Direction.DOWN)
        {
            transform.position = transform.position + new Vector3(0, 0, -distance);
        }

        GetComponent<Length>().CreateBodyAtPosition(
            currPosition
        );

        this.ResetMoveTimer();
    }

    private void ResetMoveTimer()
    {
        this.moveTimer = 0;
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
    }
}
