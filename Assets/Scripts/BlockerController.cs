using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class BlockerController : MonoBehaviour
{

    public GameObject Player;
    public GameObject Blocker;
    public string passingText;
    Vector3 BlockerPos;
    float distanceFromBlocker;
    public static bool interactBegin;
    public TextMeshProUGUI canvasText;
    public Image textBackgroundImage;
    private string remainingPassingText = string.Empty;
    private PlayerInput pi;

    void Start() {
        BlockerPos = Blocker.transform.position;
        interactBegin = false;
        SetCurrentWord();
        pi = GameObject.Find("PlayerArmature").GetComponent<PlayerInput>();
    }

    void Update() {
        distanceFromBlocker = Vector3.Distance(Player.transform.position, BlockerPos);
        if (distanceFromBlocker < 2.5f) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                canvasText.text = passingText;
                canvasText.enabled = true;
                textBackgroundImage.enabled = true;
                interactBegin = true;
                MorePlayerFunc.wallCounter = MorePlayerFunc.wallCounter + 1;
                if (MorePlayerFunc.wallCounter >= 14) {
                    pi.actions.FindAction("Jump").Disable();
                }
                if (MorePlayerFunc.wallCounter >= 30) {
                    pi.actions.FindAction("Move").Disable();
                }
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
                interactBegin = false;
                pi.actions.FindAction("Jump").Enable();
                pi.actions.FindAction("Move").Enable();
                canvasText.text = "";
                textBackgroundImage.enabled = false;
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
