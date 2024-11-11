using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Length : MonoBehaviour
{
    public Rigidbody snake_head;
    public GameObject snake_body;

    private int maxLength = 12;
    private float growTimer = 0.0f;
    private float growWait = 0.1f;
    private float destroyTimer = 0.0f;

    private List<GameObject> body = new List<GameObject>();

    void Update()
    {
        this.growTimer += Time.deltaTime;
        this.destroyTimer += Time.deltaTime;

        // rather than keep growing based on time,
        // how about an event?
        // when the snake moves
        // call the create function

        //if (growTimer > growWait)
        //{
        //    this.CreateBodyAtPosition();
        //}

        if (
            destroyTimer > growWait &&
            this.body.Count > maxLength
        )
        {
            this.DestroyBodyAtPosition();
        }
    }

    public void CreateBodyAtPosition(Vector3 pos)
    {
        var obj = Instantiate(
            snake_body,
            pos,
            Quaternion.identity
        );
        this.body.Add(obj);

        obj.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void DestroyBodyAtPosition()
    {
        if (this.body.Count < 1)
        {
            return;
        }

        var obj = this.body[0];

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
