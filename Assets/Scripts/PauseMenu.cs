using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour {

    private Transform pauseButtonTransform;
    private Transform backgroundTransform;
    private Transform mainMenuButtonTransform;
    private Transform continueButtonTransform;
    private Transform retryButtonTransform;

    private bool isPaused = false;

    private void Awake() {
        pauseButtonTransform = transform.Find("pauseButton");
        backgroundTransform = transform.Find("background");
        mainMenuButtonTransform = transform.Find("mainMenuButton");
        continueButtonTransform = transform.Find("continueButton");
        retryButtonTransform = transform.Find("retryButton");
    }


    private void Start() {
        backgroundTransform.gameObject.SetActive(false);
        pauseButtonTransform.GetComponent<Button>().onClick.AddListener(() => {
            isPaused = true;
        });
     
        mainMenuButtonTransform.GetComponent<Button>().onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            isPaused = true ;
            
        });

        continueButtonTransform.GetComponent<Button>().onClick.AddListener(() => {
            isPaused = false;
        });

        retryButtonTransform.GetComponent<Button>().onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            isPaused = false;
        });

    }

    private void Update() {
        if (isPaused) {
            pauseButtonTransform.gameObject.SetActive(false);
            backgroundTransform.gameObject.SetActive(true);
            mainMenuButtonTransform.gameObject.SetActive(true);
            continueButtonTransform.gameObject.SetActive(true);
            retryButtonTransform.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else {
            pauseButtonTransform.gameObject.SetActive(true);
            backgroundTransform.gameObject.SetActive(false);
            mainMenuButtonTransform.gameObject.SetActive(false);
            continueButtonTransform.gameObject.SetActive(false);
            retryButtonTransform.gameObject.SetActive(false);
            Time.timeScale = 1f;

        }
    }


}
