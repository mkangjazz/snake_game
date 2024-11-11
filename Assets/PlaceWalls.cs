using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWalls : MonoBehaviour
{
    public GameObject ground;
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
        Vector3 groundPosition = this.ground.transform.localPosition;
        float halfOfGroundWidth = this.ground.GetComponent<MeshCollider>().bounds.size.x / 2;
        var directions = System.Enum.GetValues(typeof(Direction));

        Vector3 GetPositionBasedOnDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.Top:
                    return new Vector3(groundPosition.x, groundPosition.y, halfOfGroundWidth);
                case Direction.Down:
                    return new Vector3(groundPosition.x, groundPosition.y, -halfOfGroundWidth);
                case Direction.Right:
                    return new Vector3(halfOfGroundWidth, groundPosition.y, groundPosition.z);
                case Direction.Left:
                    return new Vector3(-halfOfGroundWidth, groundPosition.y, groundPosition.z);
                default:
                    return new Vector3();
            }
        }

        Vector3 GetRotationBasedOnDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.Top:
                    return new Vector3(0, 90, 90);
                case Direction.Down:
                    return new Vector3(0, 90, 90);
                case Direction.Right:
                    return new Vector3(0, 0, 90);
                case Direction.Left:
                    return new Vector3(0, 0, 90);
                default:
                    return new Vector3();
            }
        }

        foreach (int i in directions)
        {
            //Debug.Log($"foreach: {i}, {(Direction)i}");
            Direction dir = (Direction)i;

            var newWall = Instantiate(
                wall,
                GetPositionBasedOnDirection(dir),
                Quaternion.Euler(GetRotationBasedOnDirection(dir))
            );
        }
    }
}
