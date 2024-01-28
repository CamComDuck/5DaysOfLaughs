using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed; 
    public bool movementAllowed;
    public SpriteRenderer spriteRenderer;
    MicrophoneMinigame microphoneScript;
    Chair chairScript;
    public Rigidbody2D rb;
    private float input;
    private float input2;
    DayManager dayScript;
    public Sprite[] direction;
    public Animation[] directionRun;

    void Start() {
        movementAllowed = true;
        microphoneScript = GameObject.FindGameObjectWithTag("Microphone").GetComponent<MicrophoneMinigame>();
        chairScript = GameObject.FindGameObjectWithTag("Chair").GetComponent<Chair>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        dayScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DayManager>();
    }

    private void Update()
    {
        if (movementAllowed && dayScript.isDay) playerMovement();
    }

    private void playerMovement() {
        input = Input.GetAxisRaw("Horizontal");
        input2 = Input.GetAxisRaw("Vertical");

        if (input2 > 0) spriteRenderer.sprite = direction[1]; //back
        if (input2 < 0) spriteRenderer.sprite = direction[0]; //front
        if (input > 0) spriteRenderer.sprite = direction[3]; //right
        if (input < 0) spriteRenderer.sprite = direction[2]; //left

        rb.velocity = new Vector2(input * speed, input2*speed);
    }

}

