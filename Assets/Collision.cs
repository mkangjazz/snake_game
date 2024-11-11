using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Movement movement;

    private void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        Debug.Log("We hit: " + collisionInfo.collider.tag);

        GameObject gameManager = GameObject.Find("GameManager");

        if (collisionInfo.collider.tag == "SnakeBody")
        {
            gameManager.GetComponent<GameManager>().EndGame();
        }

        if (collisionInfo.collider.tag == "Wall")
        {
            gameManager.GetComponent<GameManager>().EndGame();
        }
    }
}
