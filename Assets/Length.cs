using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Length : MonoBehaviour
{
    public Rigidbody rigidBody;
    public GameObject snake_body;

    private int maxLength = 3;
    private float growTimer = 0.0f;
    private float growWait = 0.5f;
    private float destroyTimer = 0.0f;

    private List<GameObject> body = new List<GameObject>();

    void Update()
    {
        this.growTimer += Time.deltaTime;
        this.destroyTimer += Time.deltaTime;

        if (growTimer > growWait)
        {
            this.CreateBodyAtPosition();
        }

        if (
            destroyTimer > growWait &&
            this.body.Count > maxLength
        )
        {
            this.DestroyBodyAtPosition();
        }
    }

    private void CreateBodyAtPosition()
    {
        //Debug.Log("CreateBodyAtPosition " + rigidBody.position);
        var obj = Instantiate(snake_body, rigidBody.position, Quaternion.identity);

        this.body.Add(obj);
        this.ResetGrowTimer();
    }

    private void DestroyBodyAtPosition()
    {
        var obj = this.body[0];
        //Debug.Log("DestroyBodyAtPosition: " + obj);

        this.body.Remove(obj);
        Destroy(obj);

        this.ResetDestroyTimer();
    }

    private void ResetDestroyTimer()
    {
        this.destroyTimer = 0;
    }

    private void ResetGrowTimer()
    {
        this.growTimer = 0;
    }
}
