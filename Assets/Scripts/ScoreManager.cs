using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // Public static variables
    // Can be accessed from any script but cannot be seen in the inspector
    public static bool gameOver;
    public static bool won;
    public static int score;

    // Reference to our textbox
    // Must be set in the inspector
    public TMP_Text textbox;
    public int scoreToWin;

    // Start is called before the first frame update
    void Start()
    {
        // init values
        gameOver = false;
	    won = false;
	    score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) {
	    textbox.text = "Score: " + score;
	}

        if (score >= scoreToWin) {
	    won = true;
	    gameOver = true;
	}

        if (gameOver) {
	    if (won)
		textbox.text = "You win!\nPress R to Try Again.";
	    else
		textbox.text = "You lose!\nPress R to Try Again.";

	    if (Input.GetKeyDown(KeyCode.R))
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
    }
}
