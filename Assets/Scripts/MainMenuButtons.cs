using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

    private Transform playButtonTransform;
    private Transform settingsButtonTransform;
    private Transform quitButtonTransform;

    private void Awake() {
        playButtonTransform = transform.Find("playButton");
        settingsButtonTransform = transform.Find("settingsButton");
        quitButtonTransform = transform.Find("QuitButton");
    }

    private void Start() {
        playButtonTransform.GetComponent<Button>().onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1f;
        });

        quitButtonTransform.GetComponent<Button>().onClick.AddListener(() => {
            Application.Quit();
        });
    }


}
