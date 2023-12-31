using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MorePlayerFunc : MonoBehaviour
{

    [SerializeField] private PixelStylizerCamera pixelStylizerCamera;

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
    public static float wallCounter;
    string currentSceneName;

    void Start()
    {
        endPointInitPos = endPoint.transform.position;
        rightShojiInitPos = rightShoji.transform.position;
        leftShojiInitPos = leftShoji.transform.position;
        wallCounter = 0;
        pixelStylizerCamera.SetPreset(ApplicationData.savedPresetColor);
        Scene currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
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

        if (currentSceneName != "Menu") {
            if (Input.GetKeyDown(KeyCode.Escape) && ApplicationData.gamePaused) {
                ApplicationData.gamePaused = false;
            } else if (Input.GetKeyDown(KeyCode.Escape) && !ApplicationData.gamePaused) {
                ApplicationData.gamePaused = true;
            }
        } 

    }
}
