using UnityEngine;

public class Collision : MonoBehaviour
{
    public Movement movement;
    private void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        Debug.Log("We hit: " + collisionInfo.collider.tag);

        //if (collisionInfo.collider.tag == "obstacle")
        //{
        //    Debug.Log("We hit an obstacle");
        //    movement.enabled = false;

        //    FindObjectOfType<GameManager>().endGame();
        //}
    }
}
