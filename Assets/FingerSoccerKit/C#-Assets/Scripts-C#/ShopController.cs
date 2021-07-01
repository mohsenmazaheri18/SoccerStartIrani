using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {

	///*************************************************************************///
	/// Main Shop Controller class.
	/// This class handles all touch events on buttons.
	/// It also checks if user has enough money to buy items, it items are already purchased,
	/// and saves the purchased items into playerprefs for further usage.
	///*************************************************************************///

	private float buttonAnimationSpeed = 9;	//speed on animation effect when tapped on button
	private bool  canTap = true;			//flag to prevent double tap

	public AudioClip coinsCheckout;			//buy sfx
	
	[Header("Text Canvas")]
	public Text playerMoney;			//Reference to 3d text
	private int availableMoney;
	public Text playerCoin;			//Reference to 3d text
	private int availableCoin;

	public GameObject[] totalItemsForSale;	//Purchase status


	private String saveName = "";

	[Header("Button Canvas")] 
	public Button Form1;
	public Button Form2 , Form3 , Back_Button;
	public Button Money, Coin;
	
	//*****************************************************************************
	// Init. 
	//*****************************************************************************
	void Awake ()
	{
		
		
		//Updates 3d text with saved values fetched from playerprefs
		availableMoney = PlayerPrefs.GetInt("PlayerMoney");
		playerMoney.GetComponent<Text>().text = "" + availableMoney;
		availableCoin = PlayerPrefs.GetInt("PlayerCoin");
		playerCoin.GetComponent<Text>().text = "" + availableCoin;
		
		//check if we previously purchased these items.
		/*for(int i = 0; i < totalItemsForSale.Length; i++) {
			//format the correct string we use to store purchased items into playerprefs
			string shopItemName = "shopItem-" + totalItemsForSale[i].GetComponent<ShopItemProperties>().itemIndex.ToString();
			if(PlayerPrefs.GetInt(shopItemName) == 1) {
				//we already purchased this item
				totalItemsForSale[i].GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1); 	//Make it green
				totalItemsForSale[i].GetComponent<BoxCollider>().enabled = false;			//Not clickable anymore
			}
		}*/
	}

	private void Start()
	{
		Form1.onClick.AddListener(() =>
		{
			//if we have enough money, purchase this item and save the event
			if (availableMoney >= GetComponent<ShopItemProperties>().itemPrice)
			{

				//deduct the price from user money
				availableMoney -= GetComponent<ShopItemProperties>().itemPrice;

				//save new amount of money
				PlayerPrefs.SetInt("PlayerMoney", availableMoney);

				//save the event of purchase
				saveName = "shopItem-" + GetComponent<ShopItemProperties>().itemIndex.ToString();
				PlayerPrefs.SetInt(saveName, 1);

				//play sfx
				playSfx(coinsCheckout);

				//Reload the level
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		});

		Form2.onClick.AddListener(() =>
		{
			if (availableMoney >= GetComponent<ShopItemProperties>().itemPrice)
			{
				availableMoney -= GetComponent<ShopItemProperties>().itemPrice;
				PlayerPrefs.SetInt("PlayerMoney", availableMoney);
				saveName = "shopItem-" + GetComponent<ShopItemProperties>().itemIndex.ToString();
				PlayerPrefs.SetInt(saveName, 1);
				playSfx(coinsCheckout);
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}

		});

		Form3.onClick.AddListener(() =>
		{

			if (availableMoney >= GetComponent<ShopItemProperties>().itemPrice)
			{
				availableMoney -= GetComponent<ShopItemProperties>().itemPrice;
				PlayerPrefs.SetInt("PlayerMoney", availableMoney);
				saveName = "shopItem-" + GetComponent<ShopItemProperties>().itemIndex.ToString();
				PlayerPrefs.SetInt(saveName, 1);
				playSfx(coinsCheckout);
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		});

		Back_Button.onClick.AddListener(() =>
		{
			SceneManager.LoadScene("Shop");
		});
		
		Money.onClick.AddListener(() =>
		{
			SceneManager.LoadScene("MoneyShop");
		});
		Coin.onClick.AddListener(() =>
		{
			SceneManager.LoadScene("CoinShop");
		});
	}

	//*****************************************************************************
	// FSM 
	//*****************************************************************************
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("Shop");
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