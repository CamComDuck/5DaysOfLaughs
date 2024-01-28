using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public List<GameObject> availableChairs = new List<GameObject>();
    public GameObject customer;
    public int customersSpawned;
    public int customersExited;
    DayManager dayScript;
    CurrencyManager currencyScript;

    void Start() {
        customersSpawned = 0;
        customersExited = 0;
        dayScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DayManager>();
        currencyScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CurrencyManager>();
    }

    void Update()
    {
        int spawnRate = Random.Range(0, 1000);
        if (spawnRate <= 3) spawnCustomer();
        if (customersExited == dayScript.customersThisDay) {
            if (dayScript.dayNumber == 5) {
                dayScript.gameWin();
            } else {
                currencyScript.startUpgradePhase();
                customersSpawned = 0;
                customersExited = 0;
            }
        }
        
    }

    void spawnCustomer() {
        if (availableChairs.Count > 0 && customersSpawned < dayScript.customersThisDay && dayScript.isDay) {
            GameObject usingChair = availableChairs[Random.Range(0, availableChairs.Count)];
            Vector3 customerPos = new Vector3(usingChair.transform.position.x-0.037f,usingChair.transform.position.y+0.2038293f,usingChair.transform.position.z);
            Instantiate(customer, customerPos, Quaternion.identity);
            availableChairs.Remove(usingChair);
            customersSpawned++;
        }
    } 
}
