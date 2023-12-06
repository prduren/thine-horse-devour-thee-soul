using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{

    public GameObject endPoint;
    public GameObject startPoint;
    public GameObject player;
    public float speed = 1f;
    private float startTime;
    private float journeyLength;

    void Start() {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPoint.transform.position, endPoint.transform.position);
    }

    void Update() {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, fractionOfJourney);
        // die if touch wall
        if ((transform.position.z - player.transform.position.z) > - 1) {
            Debug.Log("dead");
        }
    }
}
