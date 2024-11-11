using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void EndGame()
    {
        var snake = GameObject.Find("Snake");

        Destroy(snake);
        Debug.Log("Game Over");

        // display message
    }
}
