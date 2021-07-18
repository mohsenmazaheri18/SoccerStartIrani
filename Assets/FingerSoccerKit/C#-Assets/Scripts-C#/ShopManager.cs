using System;
using UnityEngine;
using System.Collections;
using FiroozehGameService.Core;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {
	

	public AudioClip tapSfx;				//buy sfx
	
	[Header("Text Canvas")]
	public Text playerMoney;			//Reference to 3d text
	private int availableMoney;
	public Text playerCoin;			//Reference to 3d text
	private int availableCoin;
	

	[Header("Button Canvas")]
	public Button Formation_Buy;
	public Button Team_Buy , Coin_Buy , Money_Buy ,Back_Button;
	public Button Money_Shop_Up, Coin_Shop_Up;
	


	//*****************************************************************************
	// Init. 
	//*****************************************************************************
	void Awake (){
		//Updates 3d text with saved values fetched from playerprefs
		availableMoney = PlayerPrefs.GetInt("PlayerMoney");
		playerMoney.GetComponent<Text>().text = "" + availableMoney;
		availableCoin = PlayerPrefs.GetInt("PlayerCoin");
		playerCoin.GetComponent<Text>().text = "" + availableCoin;
	}

	private void Start()
	{
		Formation_Buy.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			SceneManager.LoadScene("FormShop");
		});
		Team_Buy.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			SceneManager.LoadScene("TeamShop");
		});
		Coin_Buy.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			SceneManager.LoadScene("CoinShop");
		});
		Money_Buy.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			SceneManager.LoadScene("MoneyShop");
		});
		
		Money_Shop_Up.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			SceneManager.LoadScene("MoneyShop");
		});
		
		Coin_Shop_Up.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			SceneManager.LoadScene("CoinShop");
		});
		Back_Button.onClick.AddListener(() =>
		{
			playSfx(tapSfx);
			SceneManager.LoadScene("Home");
		});
	}

	//*****************************************************************************
	// FSM 
	//*****************************************************************************
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("Home");
		}
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