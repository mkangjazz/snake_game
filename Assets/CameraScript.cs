using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject ground;

    void Start()
    {
        SetOrthographicSizeBasedOnGround();
    }

    private void SetOrthographicSizeBasedOnGround()
    {
        var cam = gameObject.GetComponent<Camera>();
        //cam.orthographicSize = 10;
        //cam.rect = new Rect(
        //    0,
        //    0,
        //    100,
        //    100
        //);
        //    , m_ViewPositionY, m_ViewWidth, m_ViewHeight);
    }
}
