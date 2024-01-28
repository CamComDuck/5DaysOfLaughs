using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DayManager : MonoBehaviour
{
    public int dayNumber;
    public TMP_Text dayText;
    public int customersThisDay;
    public int happinessDecreaseRate;
    public bool isDay;
    private GameObject player;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject laughsPanel;
    public GameObject dayPanel;
    private bool playerReading;

    void Start() {
        dayNumber = 0;
        isDay = false;
        playerReading = false;
        player = GameObject.FindGameObjectWithTag("Player");
        startNewDay();
    }

    void Update() {
        if (playerReading && Input.GetKeyUp("r")) {
            SceneManager.LoadScene("GameScreen");
        }
    }

    public void startNewDay() {
        player.transform.position = new Vector3(0.043f, 0, 0);
        dayNumber++;
        dayText.text = "Day " + dayNumber;
        isDay = true;

        if (dayNumber == 1) {
            customersThisDay = Random.Range(2, 3);
            happinessDecreaseRate = Random.Range(5000, 7000);
        } else if (dayNumber == 2) {
            customersThisDay = Random.Range(3, 4);
            happinessDecreaseRate = Random.Range(4000, 6000);
        } else if (dayNumber == 3) {
            customersThisDay = Random.Range(4, 5);
            happinessDecreaseRate = Random.Range(3500, 5500);
        } else if (dayNumber == 4) {
            customersThisDay = Random.Range(5, 6);
            happinessDecreaseRate = Random.Range(3000, 5000);
        } else if (dayNumber == 5) {
            customersThisDay = Random.Range(6, 7);
            happinessDecreaseRate = Random.Range(2750, 4750);
        }
    }

    public void gameLose() {
        dayPanel.SetActive(false);
        laughsPanel.SetActive(false);
        losePanel.SetActive(true);
        isDay = false;
        playerReading = true;
    }

    public void gameWin() {
        dayPanel.SetActive(false);
        laughsPanel.SetActive(false);
        winPanel.SetActive(true);
        isDay = false;
        playerReading = true;
    }
}
