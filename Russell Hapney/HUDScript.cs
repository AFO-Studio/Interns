using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using their UI system
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

    float playerScore = 0;
	//getting the UI text GameObject and setting it to a private
	[SerializedField] Text playerScoreText;

	// Update is called once per frame
	void Update ()
    	{
		
        	playerScore += Time.deltaTime;
		//setting the value of the text(string) to the value of the float
		//combined with whatever formatting you had
		playerScoreText.text = "" + playerScore * 100 + "";
	}

    public void IncreaseScore(int amount)
    {
        playerScore += amount;
    }
	//while this is how you directly draw text to the screen, it isn't often used in production titles
    /*void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Score: " + (int)(playerScore * 100));
    }
    */
}
