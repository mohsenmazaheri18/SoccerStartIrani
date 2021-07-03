using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manage_Coin : MonoBehaviour
{
    [Header("Text Canvas")]
    public Text playerCoin;			//UI 3d text object
    private int availableCoin;				//UI 3d text object
    public Text playerMoney;			//UI 3d text object
    private int availableMoney;				//UI 3d text object

    [Header("Button To Set Coin")]
    public Button Coin_50;
    public Button Coin_100 , Coin_150,Coin_300,Coin_500,Coin_1000,Coin_1500;
    
    // Start is called before the first frame update
    void Awake()
    {
        availableCoin = PlayerPrefs.GetInt("PlayerCoin");
        playerCoin.GetComponent<Text>().text = "" + availableCoin;
        availableMoney = PlayerPrefs.GetInt("PlayerMoney");
        playerMoney.GetComponent<Text>().text = "" + availableMoney;
    }

    void Start()
    {
        Coin_50.onClick.AddListener(() =>
        {
            availableCoin -= 25;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            SceneManager.LoadScene("MatchMaking");
        });
        Coin_100.onClick.AddListener(() =>
        {
            availableCoin -= 50;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            SceneManager.LoadScene("MatchMaking");
        });
        Coin_150.onClick.AddListener(() =>
        {
            availableCoin -= 75;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            SceneManager.LoadScene("MatchMaking");
        });
        Coin_300.onClick.AddListener(() =>
        {
            availableCoin -= 150;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            SceneManager.LoadScene("MatchMaking");
        });
        Coin_500.onClick.AddListener(() =>
        {
            availableCoin -= 250;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            SceneManager.LoadScene("MatchMaking");
        });
        Coin_1000.onClick.AddListener(() =>
        {
            availableCoin -= 500;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            SceneManager.LoadScene("MatchMaking");
        });
        Coin_1500.onClick.AddListener(() =>
        {
            availableCoin -= 750;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            SceneManager.LoadScene("MatchMaking");
        });
        
    }
}
