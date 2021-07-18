using UnityEngine;
using System.Collections;
using FiroozehGameService.Core;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
		
	///*************************************************************************///
	/// Main Menu Controller.
	/// This class handles all touch events on buttons, and also updates the 
	/// player status (wins and available-money) on screen.
	///*************************************************************************///

	private float buttonAnimationSpeed = 9;		//speed on animation effect when tapped on button
	public AudioClip tapSfx;					//tap sound for buttons click

	[Header("Canvas Text UI Gem Gold")]
	public Text playerWins;				//UI text object
	public Text playerMoney, playerCoin;			//UI text object

	public Canvas Profile;
	

	[Header("Button GameMode")]
	public Button GameMode_Single;
	public Button GameMode_one_one, GameMode_Tournomet, GameMode_Penalty;

	[Header("Button GameMode")]
	 public Button Shop_Button;
	 public Button Coin , Money , profile;

	//*****************************************************************************
	// Init. Updates the 3d texts with saved values fetched from playerprefs.
	//*****************************************************************************
	void Awake (){

		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = 0.02f;

		Application.targetFrameRate = 60;
		
		playerWins.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("PlayerWins");
		playerMoney.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("PlayerMoney");
		playerCoin.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("PlayerCoin");
	}


	void Start()
	{
		//player vs AI mode
		GameMode_Single.onClick.AddListener(() =>
		{
			Debug.Log("Single");
			playSfx(tapSfx); //play touch sound
			PlayerPrefs.SetInt("GameMode", 0); //set game mode to fetch later in "Game" scene
			PlayerPrefs.SetInt("IsTournament", 0); //are we playing in a tournament?
			PlayerPrefs.SetInt("IsPenalty", 0); //are we playing penalty kicks?
			SceneManager.LoadScene("MatchMaking"); //Load the next scene
		});
		
		//two player (human) mode
/*		GameMode_one_one.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			PlayerPrefs.SetInt("GameMode", 1);
			PlayerPrefs.SetInt("IsTournament", 0);
			PlayerPrefs.SetInt("IsPenalty", 0);
			SceneManager.LoadScene("Config");
		});*/
		
		//Tournomet Mode
		GameMode_Tournomet.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			PlayerPrefs.SetInt("GameMode", 0);
			PlayerPrefs.SetInt("IsTournament", 1);
			PlayerPrefs.SetInt("IsPenalty", 0);
			SceneManager.LoadScene("Config");
		});
		
		//Penalty Kicks
/*		GameMode_Penalty.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			PlayerPrefs.SetInt("GameMode", 0);
			PlayerPrefs.SetInt("IsTournament", 0);
			PlayerPrefs.SetInt("IsPenalty", 1);
			SceneManager.LoadScene("Penalty-c#");
		});
		*/
		//Button Option Shop
		Shop_Button.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			SceneManager.LoadScene("Shop");
		});
		
		//Button Option Coin
		Coin.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			SceneManager.LoadScene("CoinShop");
		});
		
		//Button Option Money
		Money.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			SceneManager.LoadScene("MoneyShop");
		});
		profile.onClick.AddListener(() =>
		{
			Debug.Log("yrs");
			playSfx(tapSfx);
			Profile.enabled = true;
		});

	}
	
	//*****************************************************************************
	// Play sound clips
	//*****************************************************************************
	void playSfx ( AudioClip _clip  ){
		GetComponent<AudioSource>().clip = _clip;
		if(!GetComponent<AudioSource>().isPlaying) {
			GetComponent<AudioSource>().Play();
		}
	}

}