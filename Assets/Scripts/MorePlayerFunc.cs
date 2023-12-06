using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorePlayerFunc : MonoBehaviour
{
    public GameObject player;
    public GameObject endPoint;
    Vector3 endPointInitPos;
    float distanceFromEndPoint;

    void Start()
    {
        endPointInitPos = endPoint.transform.position;
    }

    void Update()
    {
        distanceFromEndPoint = Vector3.Distance(player.transform.position, endPointInitPos);
        if (distanceFromEndPoint < 3) {
            Debug.Log("end level");
        }
    }
}
