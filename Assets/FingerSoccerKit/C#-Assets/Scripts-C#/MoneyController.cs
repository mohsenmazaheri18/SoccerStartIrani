using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour {

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
	public Text playerMoney;			//UI 3d text object
	private int availableMoney;				//UI 3d text object
	public Text playerCoin;			//UI 3d text object
	private int availableCoin;				//UI 3d text object

	[Header("Manage Canvas")]
	public GameObject Menu;
	public GameObject Money;
	public GameObject Coin;

	[Header("Manage Canvas")]
	public Button MoneyPack1;
	public Button MoneyPack2 , MoneyPack3 , MoneyPack4, MoneyPack5, Back_Button , Coin_Shop;

	//*****************************************************************************
	// Init. Updates the 3d texts with saved values fetched from playerprefs.
	//*****************************************************************************
	void Awake (){
		availableMoney = PlayerPrefs.GetInt("PlayerMoney");
		playerMoney.GetComponent<Text>().text = "" + availableMoney;
		availableCoin = PlayerPrefs.GetInt("PlayerCoin");
		playerCoin.GetComponent<Text>().text = "" + availableCoin;
	}

	private void Start()
	{
		//Coin Pack 1 Button When Click
		MoneyPack1.onClick.AddListener(() =>
		{
			availableMoney += 300;
					
			//save new amount of money
			PlayerPrefs.SetInt("PlayerMoney", availableMoney);
					
			//play sfx
			playSfx(coinsCheckout);
			
			//Reload the level
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		});
		
		//Coin Pack 2 Button When Clicked
		MoneyPack2.onClick.AddListener(() =>
		{
			availableMoney += 700;
					
			//save new amount of money
			PlayerPrefs.SetInt("PlayerMoney", availableMoney);
					
			//play sfx
			playSfx(coinsCheckout);
			
			//Reload the level
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		});
		
		//Coin Pack 3 Button When Clicked
		MoneyPack3.onClick.AddListener(() =>
		{
			availableMoney += 1400;
					
			//save new amount of money
			PlayerPrefs.SetInt("PlayerMoney", availableMoney);
					
			//play sfx
			playSfx(coinsCheckout);
			
			//Reload the level
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		});
		
		//Coin Pack 4 Button When Clicked
		MoneyPack4.onClick.AddListener(() =>
		{
			availableMoney += 2000;
					
			//save new amount of money
			PlayerPrefs.SetInt("PlayerMoney", availableMoney);
					
			//play sfx
			playSfx(coinsCheckout);
			
			//Reload the level
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		});
		
		//Coin Pack 5 Button When Clicked
		MoneyPack5.onClick.AddListener(() =>
		{
			availableMoney += 5000;
					
			//save new amount of money
			PlayerPrefs.SetInt("PlayerMoney", availableMoney);
					
			//play sfx
			playSfx(coinsCheckout);
			
			//Reload the level
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		});
		
		//Back to Menu When Clicked
		Back_Button.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			Menu.SetActive(true);
			Money.SetActive(false);
		});
		
		//Go to Money Shop When Clicked
		Coin_Shop.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			Coin.SetActive(true);
			Money.SetActive(false);
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