using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlockerController : MonoBehaviour
{

    public GameObject Player;
    public GameObject Blocker;
    public string passingText;
    Vector3 BlockerPos;
    float distanceFromBlocker;
    public static bool interactBegin;
    public TextMeshProUGUI canvasText;
    private string remainingPassingText = string.Empty;

    void Start() {
        BlockerPos = Blocker.transform.position;
        interactBegin = false;
        SetCurrentWord();
    }

    void Update() {
        distanceFromBlocker = Vector3.Distance(Player.transform.position, BlockerPos);
        if (distanceFromBlocker < 2.2f) {
            if (Input.GetKey(KeyCode.Return)) {
                canvasText.text = passingText;
                canvasText.enabled = true;
                interactBegin = true;
            }
            if (interactBegin) { // we are now in typing mode
                CheckInput();
            }
        }
    }

    private void SetCurrentWord() {
        SetRemainingWord(passingText);
    }

    private void SetRemainingWord(string newString) {
        remainingPassingText = newString;
        canvasText.text = remainingPassingText;
    }

    private void CheckInput() {
        if (Input.anyKeyDown) {
            string keysPressed = Input.inputString;
            if (keysPressed.Length == 1) {
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter) {
        if (IsCorrectLetter(typedLetter)) {
            RemoveLetter();
            if (IsWordComplete()) {
                canvasText.text = "";
                Blocker.GetComponent<MeshRenderer>().enabled = false;
                Blocker.GetComponent<BoxCollider>().enabled = false;
                Blocker.transform.Translate(new Vector3(1000, 1000, 1000));
                BlockerPos = Blocker.transform.position;
            }
        }
    }

    private bool IsCorrectLetter(string letter) {
        return remainingPassingText.IndexOf(letter) == 0;
    }

    private void RemoveLetter() {
        string newString = remainingPassingText.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete() {
        return remainingPassingText.Length == 0;
    }

}
