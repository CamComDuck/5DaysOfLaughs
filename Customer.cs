using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public int happiness;
    public Sprite[] happinessLevel;
    public float timeSinceSpawned;
    CurrencyManager currencyScript;
    DayManager dayScript;
    CustomerManager customerManagerScript;
    

    // Start is called before the first frame update
    void Start()
    {
        happiness = Random.Range(3, 4);
        timeSinceSpawned = 50000;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        currencyScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CurrencyManager>();
        dayScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DayManager>();
        customerManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CustomerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSinceSpawned > 0) timeSinceSpawned--;
        int sadify = Random.Range(0, dayScript.happinessDecreaseRate);
        if (sadify == 2) happiness--;
        if (happiness >= 9) finishedHappyCustomer();
        if (happiness <= 0) finishedSadCustomer();
        if (happiness >= 0 && happiness <= 9) spriteRenderer.sprite = happinessLevel[happiness];
    }

    void finishedHappyCustomer() {
        currencyScript.laughsCurrency = currencyScript.laughsCurrency + 1 + (int) Mathf.Floor(timeSinceSpawned/10000);
        customerManagerScript.customersExited++;
        Destroy(gameObject);
    }

    void finishedSadCustomer() {
        dayScript.gameLose();
        Destroy(gameObject);
    }

}
