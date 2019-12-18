using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance; 
	
	public int score;
	public static int highscore;
	public Text text;
	public GameStatus gamestatus;

    public Text scoreText;
    public Text scoreTextGameOver;

    public GameObject gameOverPanel;
    public GameObject startPanel;
    public GameObject splashPanel;

	public bool isFreze,flash, isSplash;
	public float frezeTime, flashTime, splashTime;

	public bool pusing;

    // Use this for initialization
    void Start ()
    {
	    instance = this;
        // gamestatus = GameStatus.Splash;
        score = 0;
		highscore = PlayerPrefs.GetInt ("highscore", highscore);
		isFreze = false;
		flash = false;
		isSplash = true;
		frezeTime = 3;
		flashTime = 5;
		splashTime = 1;
	}

	public void NambahScore(){
        score +=10;
    }
	
	// Update is called once per frame
	void Update ()
	{	
		text.text = highscore + " Coin";
		if(isFreze){
			frezeTime -= Time.deltaTime;
			if(frezeTime  <= 0){
				isFreze = false;
				frezeTime = 3;
			}
		}

		if(gamestatus == GameStatus.Splash){
			splashTime -= Time.deltaTime;
			if(splashTime  <= 0){
				splashPanel.SetActive(false);
				gamestatus = GameStatus.Wait;
			}
		}

		if(flash){
			flashTime -= Time.deltaTime;
			if(flashTime  <= 0){
				flash = false;
				flashTime = 5;
			}
		}

		if (score > highscore){
			highscore = score;
			text.text = score + " Coin";
			PlayerPrefs.SetInt ("highscore", highscore);
		}

		switch (gamestatus) {
		case GameStatus.Splash:
				splashPanel.SetActive(true);
				break;
		case GameStatus.Play:
				startPanel.SetActive(false);
        		scoreText.text = score + " Coin";
			    break;
		case GameStatus.GameOver:
                gameOverPanel.SetActive(true);
                scoreTextGameOver.text = "Your Score : " + score + " Coin";
			    break;
		case GameStatus.Wait:
				gameOverPanel.SetActive(false);
                startPanel.SetActive(true);
			    break;
		}
				
	}		
		
	public enum GameStatus
	{
		Splash,
		Wait,
		Play,
		GameOver		
	}
}
