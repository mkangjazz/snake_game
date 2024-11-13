using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Movement movement;
    
    private GameObject gameManager;

    public void Start()
    {
        this.gameManager = GameObject.Find("GameManager");
    }
    private void DestroySnake()
    {
        Destroy(gameObject);
        gameManager.GetComponent<GameManagerScript>().EndGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            other.GetComponent<GoalScript>().Collect();
            gameManager.GetComponent<GameManagerScript>().current_level += 1;
        }

        if (other.tag == "Wall")
        {
            this.DestroySnake();
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "SnakeBody")
        {
            this.DestroySnake();
        }

        if (collisionInfo.collider.tag == "Wall")
        {
            this.DestroySnake();
        }
    }
}
