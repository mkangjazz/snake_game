using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWalls : MonoBehaviour
{
    public GameObject wall;

    private Dictionary<string, Vector3> positions = new Dictionary<string, Vector3>();
    private enum Direction
    {
        Top,
        Down,
        Right,
        Left
    }

    void Start()
    {
        this.setUpWalls();
    }

    void setUpWalls()
    {

        Vector3 groundPosition = gameObject.GetComponent<MeshCollider>().transform.localPosition;
        float groundWidth = gameObject.GetComponent<MeshCollider>().bounds.size.x;
        float groundHeight = gameObject.GetComponent<MeshCollider>().bounds.size.z;

        GameObject topWall = Instantiate(
            wall,
            new Vector3(groundPosition.x, groundPosition.y, groundHeight / 2),
            Quaternion.Euler(new Vector3(0, 90, 90))
        );

        GameObject bottomWall = Instantiate(
            wall,
            new Vector3(groundPosition.x, groundPosition.y, -groundHeight / 2),
            Quaternion.Euler(new Vector3(0, 90, 90))
        );

        GameObject rightWall = Instantiate(
            wall,
            new Vector3(groundWidth / 2, groundPosition.y, groundPosition.z),
            Quaternion.Euler(new Vector3(0, 0, 90))
        );

        GameObject leftWall = Instantiate(
            wall,
            new Vector3(-groundWidth / 2, groundPosition.y, groundPosition.z),
            Quaternion.Euler(new Vector3(0, 0, 90))
        );

        topWall.transform.localScale = new Vector3(
            wall.GetComponent<BoxCollider>().size.x,
            wall.GetComponent<BoxCollider>().size.y,
            groundWidth * 2
        );

        bottomWall.transform.localScale = new Vector3(
            wall.GetComponent<BoxCollider>().size.x,
            wall.GetComponent<BoxCollider>().size.y,
            groundWidth * 2
        );

        rightWall.transform.localScale = new Vector3(
            wall.GetComponent<BoxCollider>().size.x,
            wall.GetComponent<BoxCollider>().size.y,
            groundWidth * 2
        );

        leftWall.transform.localScale = new Vector3(
            wall.GetComponent<BoxCollider>().size.x,
            wall.GetComponent<BoxCollider>().size.y,
            groundWidth * 2
        );
    }
}

