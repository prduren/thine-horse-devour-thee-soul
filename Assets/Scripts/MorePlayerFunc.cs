using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorePlayerFunc : MonoBehaviour
{
    public GameObject player;
    public GameObject endPoint;
    Vector3 endPointInitPos;
    float distanceFromEndPoint;
    private bool isLevelComplete = false;
    public GameObject rightShoji;
    public GameObject rightShojiEndPoint;
    public GameObject leftShoji;
    public GameObject leftShojiEndPoint;
    Vector3 rightShojiInitPos;
    Vector3 leftShojiInitPos;
    public static float wallCounter = 0;

    void Start()
    {
        endPointInitPos = endPoint.transform.position;
        rightShojiInitPos = rightShoji.transform.position;
        leftShojiInitPos = leftShoji.transform.position;
    }

    void Update()
    {
        distanceFromEndPoint = Vector3.Distance(player.transform.position, endPointInitPos);
        if (distanceFromEndPoint < 3) {
            isLevelComplete = true;
        }

        if (isLevelComplete) {
            rightShoji.transform.position = Vector3.MoveTowards(rightShojiInitPos, rightShojiEndPoint.transform.position, 1f);
            leftShoji.transform.position = Vector3.MoveTowards(leftShojiInitPos, leftShojiEndPoint.transform.position, 1f);
        }
    }
}
