using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float forwardForce = 20f;

    // Update() called every frame
    // FixedUpdate() based on absolute time
    // Frame rates can vary, if need millisecond precision use FixedUpdate()

    private void FixedUpdate()
    {
        // forward always applied
        rigidBody.AddForce(0, 0, forwardForce);

        // "turn" only, relative to facing direction?
        // a/d left right

        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            Debug.Log("turn left");
        }

        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            Debug.Log("turn right");
        }

        //if (Input.GetKey("d"))
        //{
        //    rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //}
        //if (Input.GetKey("a"))
        //{
        //    rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //}
        //if (Input.GetKey("w"))
        //{
        //    rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        //}
        //if (Input.GetKey("s"))
        //{
        //    rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        //}
    }

    void Update()
    {
                
    }
}
