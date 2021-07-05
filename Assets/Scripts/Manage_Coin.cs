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
    
    [Header("Text Coin Match")]
    public Text Player1Coin_Set;
    public Text Player2Coin_Set;
    public Text P1vP2_Coin_Set;

    [Header("Canvas Manage Go")]
    public Canvas coin_Choose;
    public Canvas matchmake;
    public GameObject MatchMaking_Sctipt;
    
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
            coin_Choose.enabled = false;
            matchmake.enabled = true;
            MatchMaking_Sctipt.SetActive(true);
            Player1Coin_Set.text = "25";
            Player2Coin_Set.text = "25";
            P1vP2_Coin_Set.text = "50";
        });
        Coin_100.onClick.AddListener(() =>
        {
            availableCoin -= 50;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            matchmake.enabled = true;
            MatchMaking_Sctipt.SetActive(true);
            Player1Coin_Set.text = "50";
            Player2Coin_Set.text = "50";
            P1vP2_Coin_Set.text = "100";
        });
        Coin_150.onClick.AddListener(() =>
        {
            availableCoin -= 75;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            matchmake.enabled = true;
            MatchMaking_Sctipt.SetActive(true);
            Player1Coin_Set.text = "75";
            Player2Coin_Set.text = "75";
            P1vP2_Coin_Set.text = "150";
        });
        Coin_300.onClick.AddListener(() =>
        {
            availableCoin -= 150;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            matchmake.enabled = true;
            MatchMaking_Sctipt.SetActive(true);
            Player1Coin_Set.text = "150";
            Player2Coin_Set.text = "150";
            P1vP2_Coin_Set.text = "300";
        });
        Coin_500.onClick.AddListener(() =>
        {
            availableCoin -= 250;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            matchmake.enabled = true;
            MatchMaking_Sctipt.SetActive(true);
            Player1Coin_Set.text = "250";
            Player2Coin_Set.text = "250";
            P1vP2_Coin_Set.text = "500";
        });
        Coin_1000.onClick.AddListener(() =>
        {
            availableCoin -= 500;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            matchmake.enabled = true;
            MatchMaking_Sctipt.SetActive(true);
            Player1Coin_Set.text = "500";
            Player2Coin_Set.text = "500";
            P1vP2_Coin_Set.text = "1000";
        });
        Coin_1500.onClick.AddListener(() =>
        {
            availableCoin -= 750;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            matchmake.enabled = true;
            MatchMaking_Sctipt.SetActive(true);
            Player1Coin_Set.text = "750";
            Player2Coin_Set.text = "750";
            P1vP2_Coin_Set.text = "1500";
        });
        
    }
}
