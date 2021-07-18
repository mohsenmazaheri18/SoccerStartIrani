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

    public Button Coin_100,
        Coin_200,
        Coin_500,
        Coin_1000,
        Coin_2000,
        Coin_4000,
        Coin_10k,
        Coin_16k,
        Coin_30k,
        Coin_50k,
        Coin_100k,
        Coin_200k,
        Coin_400k,
        Coin_800k,
        Coin_1M_500,
        Coin_3M,
        Coin_6M;
    
    [Header("Text Coin Match")]
    public Text Player1Coin_Set;
    public Text Player2Coin_Set;
    public Text P1vP2_Coin_Set;

    [Header("Canvas Manage Go")]
    public Canvas coin_Choose;

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
            Player1Coin_Set.text = "25";
            Player2Coin_Set.text = "25";
            P1vP2_Coin_Set.text = "50";
        });
        Coin_100.onClick.AddListener(() =>
        {
            availableCoin -= 50;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "50";
            Player2Coin_Set.text = "50";
            P1vP2_Coin_Set.text = "100";
        });
        Coin_200.onClick.AddListener(() =>
        {
            availableCoin -= 100;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "100";
            Player2Coin_Set.text = "100";
            P1vP2_Coin_Set.text = "200";
        });
        Coin_500.onClick.AddListener(() =>
        {
            availableCoin -= 250;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "250";
            Player2Coin_Set.text = "250";
            P1vP2_Coin_Set.text = "500";
        });
        Coin_1000.onClick.AddListener(() =>
        {
            availableCoin -= 500;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "500";
            Player2Coin_Set.text = "500";
            P1vP2_Coin_Set.text = "1000";
        });
        Coin_2000.onClick.AddListener(() =>
        {
            availableCoin -= 1000;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "1000";
            Player2Coin_Set.text = "1000";
            P1vP2_Coin_Set.text = "2000";
        });
        Coin_4000.onClick.AddListener(() =>
        {
            availableCoin -= 2000;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "2000";
            Player2Coin_Set.text = "2000";
            P1vP2_Coin_Set.text = "4000";
        });
        Coin_10k.onClick.AddListener(() =>
        {
            availableCoin -= 5000;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "5000";
            Player2Coin_Set.text = "5000";
            P1vP2_Coin_Set.text = "10000";
        });
        Coin_16k.onClick.AddListener(() =>
        {
            availableCoin -= 8000;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "8000";
            Player2Coin_Set.text = "8000";
            P1vP2_Coin_Set.text = "16000";
        });
        Coin_30k.onClick.AddListener(() =>
        {
            availableCoin -= 15000;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "15000";
            Player2Coin_Set.text = "15000";
            P1vP2_Coin_Set.text = "30000";
        });
        Coin_50k.onClick.AddListener(() =>
        {
            availableCoin -= 25000;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "25000";
            Player2Coin_Set.text = "25000";
            P1vP2_Coin_Set.text = "50000";
        });
        Coin_100k.onClick.AddListener(() =>
        {
            availableCoin -= 50000;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "50000";
            Player2Coin_Set.text = "50000";
            P1vP2_Coin_Set.text = "100000";
        });
        Coin_200k.onClick.AddListener(() =>
        {
            availableCoin -= 100000;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "100000";
            Player2Coin_Set.text = "100000";
            P1vP2_Coin_Set.text = "200000";
        });
        Coin_400k.onClick.AddListener(() =>
        {
            availableCoin -= 200000;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "200000";
            Player2Coin_Set.text = "200000";
            P1vP2_Coin_Set.text = "400000";
        });
        Coin_800k.onClick.AddListener(() =>
        {
            availableCoin -= 400000;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "400000";
            Player2Coin_Set.text = "400000";
            P1vP2_Coin_Set.text = "800000";
        });
        Coin_1M_500.onClick.AddListener(() =>
        {
            availableCoin -= 750000;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "750000";
            Player2Coin_Set.text = "750000";
            P1vP2_Coin_Set.text = "1500000";
        });
        Coin_3M.onClick.AddListener(() =>
        {
            availableCoin -= 1500000;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "1500000";
            Player2Coin_Set.text = "1500000";
            P1vP2_Coin_Set.text = "3000000";
        });
        Coin_6M.onClick.AddListener(() =>
        {
            availableCoin -= 3000000;
            PlayerPrefs.GetInt("PlayerCoin",availableCoin);
            coin_Choose.enabled = false;
            Player1Coin_Set.text = "3000000";
            Player2Coin_Set.text = "3000000";
            P1vP2_Coin_Set.text = "6000000";
        });
    }
}
