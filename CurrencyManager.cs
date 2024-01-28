using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public TMP_Text laughsText;
    public int laughsCurrency;
    public GameObject upgradePanel;
    public TMP_Text micUpgradeText;
    public TMP_Text chairUpgradeText;
    public TMP_Text shoesUpgradeText;
    private int micUpgradeCost;
    private int chairUpgradeCost;
    private int shoesUpgradeCost;
    private Vector3[] chairGrid = new Vector3[6];
    public GameObject chair;
    public bool isUpgradePhase;
    private int micUpgraded;
    private int chairUpgraded;
    private int shoesUpgraded;
    DayManager dayScript;
    Player playerScript;
    MicrophoneMinigame microphoneScript;


    void Start() {
        laughsCurrency = 0;
        micUpgradeCost = 3;
        chairUpgradeCost = 4;
        shoesUpgradeCost = 7;
        isUpgradePhase = false;

        micUpgraded = 0;
        chairUpgraded = 0;
        shoesUpgraded = 0;

        dayScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DayManager>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        microphoneScript = GameObject.FindGameObjectWithTag("Microphone").GetComponent<MicrophoneMinigame>();
        createChairArray();
    }

    private void Update() {
        laughsText.text = "Laughs: " + laughsCurrency;

        if (Input.GetKeyUp("z") && laughsCurrency >= micUpgradeCost && isUpgradePhase && micUpgraded < 3) { // upgrade mic
            micUpgraded++;
            laughsCurrency = laughsCurrency - micUpgradeCost;
            micUpgradeCost = micUpgradeCost + 3;

            if (micUpgraded < 3) {
                micUpgradeText.text = "press 'Z' to upgrade laughs per joke | " + micUpgradeCost + " Laughs";
            } else {
                micUpgradeText.text = "MAX UPGRADE";
            }
            
            microphoneScript.happinessIncreaser++;

        } else if (Input.GetKeyUp("c") && laughsCurrency >= chairUpgradeCost && isUpgradePhase && chairUpgraded < 5) { // upgrade chairs
            chairUpgraded++;
            laughsCurrency = laughsCurrency - chairUpgradeCost;
            chairUpgradeCost = chairUpgradeCost + 2;

            if (chairUpgraded < 5) {
                chairUpgradeText.text = "press 'C' to add another chair | "+chairUpgradeCost+" Laughs";
            } else {
                chairUpgradeText.text = "MAX UPGRADE";
            }
            
            Instantiate(chair, chairGrid[chairUpgraded], Quaternion.identity);

        } else if (Input.GetKeyUp("v") && laughsCurrency >= shoesUpgradeCost && isUpgradePhase && shoesUpgraded < 5) { // upgrade shoes
            shoesUpgraded++;
            laughsCurrency = laughsCurrency - shoesUpgradeCost;
            shoesUpgradeCost = shoesUpgradeCost + 4;
            
            if (shoesUpgraded < 5) {
                shoesUpgradeText.text = "press 'V' to increase player movement speed | "+shoesUpgradeCost+" Laughs";
            } else {
                shoesUpgradeText.text = "MAX UPGRADE";
            }
            
            playerScript.speed = playerScript.speed + 0.15f;
            
        } else if (Input.GetKeyUp("q") && isUpgradePhase) { // next day
            upgradePanel.SetActive(false);
            isUpgradePhase = false;
            dayScript.startNewDay();
        }

    }

    public void startUpgradePhase() {
        if (dayScript.dayNumber == 5) {
            dayScript.gameWin();
        } else {
            dayScript.isDay = false;
            upgradePanel.SetActive(true);
            isUpgradePhase = true;
        }
    }

    private void createChairArray(){
        chairGrid[0] = new Vector3(-0.514f, -0.504f, 0.14f);
        chairGrid[1] = new Vector3(-0.514f, -0.504f, 0.14f);
        chairGrid[2] = new Vector3(-0.514f, 0.387f, 0.14f);
        chairGrid[3] = new Vector3(-0.189f, -0.504f, 0.14f);
        chairGrid[4] = new Vector3(-0.189f, -0.064f, 0.14f);
        chairGrid[5] = new Vector3(-0.189f, 0.387f, 0.14f);
    }

}
