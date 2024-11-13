using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject goal;
    
    private GameObject ground;
    private Bounds ground_bounds;

    private void Start()
    {
        ground = GameObject.Find("Ground");

        if (ground)
        {
            ground_bounds = this.ground.GetComponent<MeshCollider>().bounds;
        }

        MoveObject();
    }
    public void createNewGoal()
    {
        Debug.Log("createNewGoal", goal);

        var newGoal = Instantiate(
            goal,
            GetRandomVector3(),
            Quaternion.identity
        );
    }

    public void MoveObject()
    {
        Vector3 newPosition = GetRandomVector3();
        gameObject.transform.position = newPosition;
    }

    public void Collect()
    {
        MoveObject();
    }

    private Vector3 GetRandomVector3()
    {
        float half_length = ground_bounds.size.x / 2 - 1;
        float half_height = ground_bounds.size.z / 2 - 1;

        Vector3 retVal = new Vector3(
            GetRandomNumInRange(-half_length, half_length),
            gameObject.transform.localPosition.y,
            GetRandomNumInRange(-half_height, half_height)
        );

        return retVal;
    }

    private float GetRandomNumInRange(float a, float b)
    {
        float retVal = Mathf.Round(UnityEngine.Random.Range(a, b));

        return retVal;
    }
}
