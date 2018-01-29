using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seer : MonoBehaviour {

    private int min;
    private int max;
    private int guess;
    private LevelManager levelManager;

    public int attempts;
    public Text guessLabel;

	// Use this for initialization
	void Start () {
        startGame();
        showGuess();
        levelManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void startGame()
    {
        min = 1;
        max = 1001;
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(min, max);
        attempts--;
    }

    void showGuess()
    {
        if (attempts >= 0)
        {
            guessLabel.text = "Is your number " + guess + "?";
        }
        else
        {

            levelManager.LoadLevel("Win");
        }
        
    }

    void Higher()
    {
        min = guess+1;
        NextGuess();
        if (attempts >= 0)
        {
            showGuess();
        }
        else
        {
            
            levelManager.LoadLevel("lost");
        }
    }

    void Lower()
    {
        max = guess;
        NextGuess();
        if (attempts >= 0)
        {
            showGuess();
        }
        else
        {
            
            levelManager.LoadLevel("lost");
        }

    }

    void correctGuess()
    {

        if (attempts <= 0)
        {
            levelManager.LoadLevel("lost");
        }
    }
}
