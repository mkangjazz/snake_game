using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Length : MonoBehaviour
{
    public Rigidbody snake_head;
    public GameObject snake_body;
    
    private GameObject gameManager;
    private float growTimer = 0.0f;
    private float growWait = 0.1f;
    private float destroyTimer = 0.0f;

    private List<GameObject> body = new List<GameObject>();

    void Update()
    {
        this.growTimer += Time.deltaTime;
        this.destroyTimer += Time.deltaTime;

        if (
            destroyTimer > growWait &&
            this.body.Count > gameManager.GetComponent<GameManagerScript>().GetCurrentLevelInfo().maxSnakeLength
        )
        {
            this.DestroyBodyAtPosition();
        }
    }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
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
