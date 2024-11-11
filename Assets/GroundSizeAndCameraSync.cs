using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSizeAndCameraSync : MonoBehaviour
{
    public Camera cam;
    public MeshCollider groundMesh;

    void Start()
    {
        //var groundDistance = this.distance;

        //Debug.Log($"ground?: { groundMesh }");

        if (cam)
        {
            // cam.orthographicSize = groundDistance / 2;

            //cam.rect = new Rect(
            //    0,
            //    0,
            //    100,
            //    100
            //);
            //    , m_ViewPositionY, m_ViewWidth, m_ViewHeight);
        }
    }
}
