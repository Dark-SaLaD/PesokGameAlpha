using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBallCaster : MonoBehaviour
{
    public SandBall sandballPrefab;

    public Transform targetPoint;
    public Camera cameraLink;
    private int targetInSkyDistance = 50;

    private void Update() {
        //sandball cast
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(sandballPrefab, transform.position, transform.rotation);
        }

        //raycast from camera
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        //move target point to aim
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            targetPoint.position = hit.point;
        }
        else {
            targetPoint.position = ray.GetPoint(targetInSkyDistance);
        }

        //rotate to target point
        transform.LookAt(targetPoint.position);
    }
}
