using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MicrophoneMinigame : MonoBehaviour
{

    Player playerScript;
    Customer customerScript;
    private GameObject player;
    private bool minigamePlaying = false;

    private string[] jokeQuestions = new string[16];
    private string[] jokeAnswers = new string[16];
    public GameObject jokesPanel;
    public TMP_Text jokeQuestion;
    public TMP_Text jokeAnswerA;
    public TMP_Text jokeAnswerS;
    public TMP_Text jokeAnswerD;
    public TMP_Text jokeAnswerF;
    private int wrongJokeNumber;
    int correctAnswer;
    public SpriteRenderer spriteRenderer;
    public Sprite[] microphones;
    public int happinessIncreaser;
    public AudioSource clapping;
    public AudioSource booing;

    void Start() {
        happinessIncreaser = 2;
        addJokes();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetKeyUp("z") && correctAnswer == 0 && minigamePlaying) {
            correctAnswerPicked();
        } else if (Input.GetKeyUp("x") && correctAnswer == 1 && minigamePlaying) {
            correctAnswerPicked();
        } else if (Input.GetKeyUp("c") && correctAnswer == 2 && minigamePlaying) {
            correctAnswerPicked();
        } else if (Input.GetKeyUp("v") && correctAnswer == 3 && minigamePlaying) {
            correctAnswerPicked(); 
        } else if ((Input.GetKeyUp("z") || Input.GetKeyUp("x") || Input.GetKeyUp("c") || Input.GetKeyUp("v")) && minigamePlaying) {
            wrongAnswerPicked();
        }
    }

    public void startMinigame() {
        spriteRenderer.sprite = microphones[2]; 
        jokesPanel.SetActive(true);
        minigamePlaying = true;

        int pickedJokeNum = Random.Range(0, jokeQuestions.Length);
        jokeQuestion.text = jokeQuestions[pickedJokeNum];
        correctAnswer = Random.Range(0, 4);

        int answer1 = RandomRangeExcept(jokeAnswers.Length+1,jokeAnswers.Length+1,pickedJokeNum);
        int answer2 = RandomRangeExcept(answer1,jokeAnswers.Length+1,pickedJokeNum);
        int answer3 = RandomRangeExcept(answer1,answer2,pickedJokeNum);

        if (correctAnswer == 0) {
            jokeAnswerA.text = jokeAnswers[pickedJokeNum];
            jokeAnswerS.text = jokeAnswers[answer1];
            jokeAnswerD.text = jokeAnswers[answer2];
            jokeAnswerF.text = jokeAnswers[answer3];
        } else if (correctAnswer == 1) {
            jokeAnswerA.text = jokeAnswers[answer1];
            jokeAnswerS.text = jokeAnswers[pickedJokeNum];
            jokeAnswerD.text = jokeAnswers[answer2];
            jokeAnswerF.text = jokeAnswers[answer3];
        } else if (correctAnswer == 2) {
            jokeAnswerA.text = jokeAnswers[answer1];
            jokeAnswerS.text = jokeAnswers[answer2];
            jokeAnswerD.text = jokeAnswers[pickedJokeNum];
            jokeAnswerF.text = jokeAnswers[answer3];
        } else if (correctAnswer == 3) {
            jokeAnswerA.text = jokeAnswers[answer1];
            jokeAnswerS.text = jokeAnswers[answer2];
            jokeAnswerD.text = jokeAnswers[answer3];
            jokeAnswerF.text = jokeAnswers[pickedJokeNum];
        }

    }

    public void endMinigame() {
        playerScript.movementAllowed = true;
        jokesPanel.SetActive(false);
        minigamePlaying = false;
        player.transform.position = new Vector3(-0.735f, 0.042f, 0);
    }

    private void correctAnswerPicked() {
        clapping.Play();
        spriteRenderer.sprite = microphones[0];
        GameObject[] allCustomers = GameObject.FindGameObjectsWithTag("Customer");

        for (int i = 0; i < allCustomers.Length; i++) {
            customerScript = allCustomers[i].GetComponent<Customer>();
            customerScript.happiness = customerScript.happiness + happinessIncreaser;
        }
        endMinigame();
    }

    private void wrongAnswerPicked() {
        booing.Play();
        spriteRenderer.sprite = microphones[1];
        GameObject[] allCustomers = GameObject.FindGameObjectsWithTag("Customer");

        for (int i = 0; i < allCustomers.Length; i++) {
            customerScript = allCustomers[i].GetComponent<Customer>();
            customerScript.happiness--;
        }
        endMinigame();
    }

    private void OnTriggerEnter2D(Collider2D hitObject) {
        if (hitObject.tag == "Player") {
            playerScript.movementAllowed = false;
            playerScript.rb.velocity = new Vector2(0,0);
            player.transform.position = new Vector3(-1.037f, 0.042f, 0);
            playerScript.spriteRenderer.sprite = playerScript.direction[3]; //right
            startMinigame();
        }
    }

    private void addJokes(){
        jokeQuestions[0] = "Why did the puppy become a computer programmer?";
        jokeAnswers[0] = "It had a knack for fetching bytes!";
        jokeQuestions[1] = "How does a penguin build its house?";
        jokeAnswers[1] = "Igloos it together!";
        jokeQuestions[2] = "Why did the chicken join a popular video game?";
        jokeAnswers[2] = "It wanted to be a free-range character!";
        jokeQuestions[3] = "Why does a cat make a terrible game developer?";
        jokeAnswers[3] = "It can't resist adding too many mouse clicks!";
        jokeQuestions[4] = "Why did the scarecrow become a successful game designer?";
        jokeAnswers[4] = "It was outstanding in his field!";
        jokeQuestions[5] = "What's a cat's favorite programming language?";
        jokeAnswers[5] = "Scratch!";
        jokeQuestions[6] = "How do you catch a squirrel?";
        jokeAnswers[6] = "Climb a tree and act like a nut!";
        jokeQuestions[7] = "What's a skeleton's least favorite room in the house?";
        jokeAnswers[7] = "Living Room!";
        jokeQuestions[8] = "Why did the puppy fail computer class?";
        jokeAnswers[8] = "It couldn't 'paws' the teacher!";
        jokeQuestions[9] = "Why did the cat sit on the computer?";
        jokeAnswers[9] = "To keep an eye on the mouse!";
        jokeQuestions[10] = "What kind of job does a spider want?";
        jokeAnswers[10] = "Web designer!";
        jokeQuestions[11] = "How does an octopus go into battle?";
        jokeAnswers[11] = "Well-armed!";
        jokeQuestions[12] = "What did one beach say to the other beach?";
        jokeAnswers[12] = "It waved!";
        jokeQuestions[13] = "How do you measure a fish?";
        jokeAnswers[13] = "Inches, they don't have feet!";
        jokeQuestions[14] = "Why were they called the 'dark ages'?";
        jokeAnswers[14] = "There were a lot of knights!";
        jokeQuestions[15] = "Why did the duck eat the dog?";
        jokeAnswers[15] = "It was pure bread!";
    }

    private int RandomRangeExcept(int except1, int except2, int except3) {
        do {
            wrongJokeNumber = Random.Range(0,jokeAnswers.Length);
        } while (wrongJokeNumber == except1 || wrongJokeNumber == except2 || wrongJokeNumber == except3);
        return wrongJokeNumber;
    }

    IEnumerator waitSeconds() {
        // StartCoroutine(waitSeconds());
        yield return new WaitForSecondsRealtime(20);
    }

}
