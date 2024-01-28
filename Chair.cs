using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{

    private bool isClean;
    public bool hasCustomer;
    public SpriteRenderer spriteRenderer;
    public Sprite dirtySprite;
    public Sprite cleanSprite;
    CustomerManager customerManagerScript;
    DayManager dayScript;
    public AudioSource cleaning;

    // Start is called before the first frame update
    void Start()
    {
        isClean = true;
        hasCustomer = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        customerManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CustomerManager>();
        customerManagerScript.availableChairs.Add(gameObject);
        dayScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DayManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int dirtify = Random.Range(0, 17500);
        if (dirtify == 1 && !hasCustomer && dayScript.isDay) makeDirty();
    }

    private void makeDirty() {
        isClean = false;
        spriteRenderer.sprite = dirtySprite;
        customerManagerScript.availableChairs.Remove(gameObject);
    }

    private void makeClean() {
        cleaning.Play();
        isClean = true;
        spriteRenderer.sprite = cleanSprite;
        customerManagerScript.availableChairs.Add(gameObject);
    }


    public void playerClean() {
        if (!isClean) makeClean();
         
    }

    private void OnTriggerEnter2D(Collider2D hitObject) {
        if (hitObject.tag == "Player") {
            playerClean();
        } else if (hitObject.tag == "Customer") {
            hasCustomer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D hitObject) {
        if (hitObject.tag == "Customer") {
            hasCustomer = false;
            makeDirty();
        }
    }
}
