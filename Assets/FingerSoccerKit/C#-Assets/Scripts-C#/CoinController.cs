using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinController : MonoBehaviour {

	///*************************************************************************///
	/// Main CoinPack purchase Controller.
	/// This class handles all touch events on coin packs.
	/// You can easily integrate your own (custom) IAB system to deliver a nice 
	/// IAP options to the player.
	///*************************************************************************///
	
	public AudioClip coinsCheckout;				//purchase sound
	public AudioClip tapSfx;					//purchase sound

	
	//Reference to GameObjects
	[Header("Text Canvas")]
	public Text playerCoin;			//UI 3d text object
	private int availableCoin;				//UI 3d text object
	public Text playerMoney;			//UI 3d text object
	private int availableMoney;				//UI 3d text object
	

	[Header("Manage Canvas")]
	public Button CoinPack1;
	public Button CoinPack2, CoinPack3, CoinPack4 , CoinPack5 , Back_Button, Money_Button;
	
	

	//*****************************************************************************
	// Init. Updates the 3d texts with saved values fetched from playerprefs.
	//*****************************************************************************
	void Awake (){
		availableCoin = PlayerPrefs.GetInt("PlayerCoin");
		playerCoin.GetComponent<Text>().text = "" + availableCoin;
		availableMoney = PlayerPrefs.GetInt("PlayerMoney");
		playerMoney.GetComponent<Text>().text = "" + availableMoney;
	}

	private void Start()
	{
		//Coin Pack 1 Button When Click
		CoinPack1.onClick.AddListener(() =>
		{
			availableCoin += 300;
					
			//save new amount of money
			PlayerPrefs.SetInt("PlayerCoin", availableCoin);
					
			//play sfx
			playSfx(coinsCheckout);
			
			//Reload the level
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		});
		
		//Coin Pack 2 Button When Clicked
		CoinPack2.onClick.AddListener(() =>
		{
			availableCoin += 700;
					
			//save new amount of money
			PlayerPrefs.SetInt("PlayerCoin", availableCoin);
					
			//play sfx
			playSfx(coinsCheckout);
			
			//Reload the level
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		});
		
		//Coin Pack 3 Button When Clicked
		CoinPack3.onClick.AddListener(() =>
		{
			availableCoin += 1400;
					
			//save new amount of money
			PlayerPrefs.SetInt("PlayerCoin", availableCoin);
					
			//play sfx
			playSfx(coinsCheckout);
			
			//Reload the level
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		});
		
		//Coin Pack 4 Button When Clicked
		CoinPack4.onClick.AddListener(() =>
		{
			availableCoin += 2000;
					
			//save new amount of money
			PlayerPrefs.SetInt("PlayerCoin", availableCoin);
			
			//play sfx
			playSfx(coinsCheckout);
			
			//Reload the level
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		});
		
		//Coin Pack 5 Button When Clicked
		CoinPack5.onClick.AddListener(() =>
		{
			availableCoin += 5000;
					
			//save new amount of money
			PlayerPrefs.SetInt("PlayerCoin", availableCoin);
					
			//play sfx
			playSfx(coinsCheckout);
			
			//Reload the level
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			
		});
		//Back to Menu When Clicked
		Back_Button.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			SceneManager.LoadScene("Home");
		});
		
		//Go to Money Shop When Clicked
		Money_Button.onClick.AddListener(() =>
		{
			PlayerPrefs.SetInt("SceneManage", 1);
			PlayerPrefs.GetInt("SceneManage", 1);	
			playSfx(tapSfx);
			SceneManager.LoadScene("MoneyShop");
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