using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FiroozehGameService.Core;
using FiroozehGameService.Core.GSLive;
using FiroozehGameService.Handlers;
using FiroozehGameService.Models.Consts;
using FiroozehGameService.Models.Enums.GSLive.Command;
using FiroozehGameService.Models.GSLive.Command;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MatchMaking : MonoBehaviour
{
    public Text NickName_Player1;
    public Text NickName_Player2;
    public GameObject player_role;
    public Image player1_avatar;
    public Image player2_avatar;
    public Text playerMoney;
    public Text playerCoin;
    
    public Text Player1Coin_Set;
    public Text Player2Coin_Set;

    public async void Cansel_AutoMatch()
    {
        await GameService.GSLive.TurnBased().CancelAutoMatch();
        SceneManager.LoadScene("Home");
    }

    // Start is called before the first frame update
    async void Start()
    {
        playerMoney.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("PlayerMoney");
        playerCoin.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("PlayerCoin");
        
        
        SetEventHandelers();
        await GameService.GSLive.TurnBased().AutoMatch(new GSLiveOption.AutoMatchOption("Test", 2, 2, false));
    }
    
    private void SetEventHandelers()
    {
        TurnBasedEventHandlers.AutoMatchUpdated += AutoMatchUpdated;
        TurnBasedEventHandlers.JoinedRoom += JoinedRoom;
    }
    private void JoinedRoom(object sender, JoinEvent joinEvent)
    {
        Debug.Log("JoinedRoom : " + joinEvent.JoinData.RoomData.Name);
        
        if (joinEvent.JoinData.RoomData.Max==2)
        {
            player_role.SetActive(false);
        }
    }

    private void AutoMatchUpdated(object sender, AutoMatchEvent matchEvent)
    {
        Debug.Log("AutoMatchUpdated : " + matchEvent.Status);
        if (matchEvent.Players[0].User.IsMe)
        {
            player2_avatar.gameObject.SetActive(true);
            NickName_Player1.text = matchEvent.Players[0].Name;
            NickName_Player2.text = matchEvent.Players[1].Name;
            player1_avatar.sprite = player1_avatar.sprite;
            player2_avatar.sprite = player2_avatar.sprite;
        }
        if (matchEvent.Players[1].User.IsMe)
        {
            player2_avatar.gameObject.SetActive(true);
            NickName_Player1.text = matchEvent.Players[1].Name;
            NickName_Player2.text = matchEvent.Players[0].Name;
            player2_avatar.sprite = player2_avatar.sprite;
            player1_avatar.sprite = player1_avatar.sprite;
        }
    }

    private void Update()
    {
    }
}
