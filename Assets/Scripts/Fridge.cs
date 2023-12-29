using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{

    public GameObject Player;
    public GameObject FridgeDoor;
    float distanceFromFridge;
    private Vector3 FridgePos;
    private bool fridgeOpen = false;

    void Start() {
        FridgePos = FridgeDoor.transform.position;
    }

    void Update() {
        distanceFromFridge = Vector3.Distance(Player.transform.position, FridgePos);
        if (distanceFromFridge < 10f) {
            if (Input.GetKeyDown(KeyCode.Return) && !fridgeOpen) {
                FridgeDoor.transform.Rotate(0, -90, 0 * Time.deltaTime);
                fridgeOpen = true;
            }
        }
    }
}
