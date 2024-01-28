using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TitleStart : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp("r")) {
            SceneManager.LoadScene("GameScreen");
        }
    }
}
