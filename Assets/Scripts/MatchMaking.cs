using System.Collections;
using FiroozehGameService.Core;
using FiroozehGameService.Core.GSLive;
using FiroozehGameService.Handlers;
using FiroozehGameService.Models.GSLive.Command;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utils;

public class MatchMaking : MonoBehaviour
{
    
    
    //Match Making Game
    [FormerlySerializedAs("NickName_Player1")] public Text nickNamePlayer1;
    [FormerlySerializedAs("NickName_Player2")] public Text nickNamePlayer2;
    [FormerlySerializedAs("player_role")] public GameObject playerRole; 
    [FormerlySerializedAs("player1_avatar")] public RawImage player1Avatar;
    [FormerlySerializedAs("player2_avatar")] public RawImage player2Avatar;
    
    public Text playerMoney;
    public Text playerCoin;

    [FormerlySerializedAs("Game")] public GameObject game;
    public GameObject match;
    
    public async void Cansel_AutoMatch()
    {
        await GameService.GSLive.RealTime().CancelAutoMatch();
        StartCoroutine(Wait_To_Back_Home());
    }


    private void SetEventHandelers()
    {
	    CommandEventHandler.AutoMatchUpdated += AutoMatchUpdated;
        TurnBasedEventHandlers.JoinedRoom += JoinedRoom;
    }

    private void JoinedRoom(object sender, JoinEvent joinEvent)
    {
        Debug.Log("JoinedRoom : " + joinEvent.JoinData.RoomData.Name);

        if (joinEvent.JoinData.RoomData.Max==2)
        {
            playerRole.SetActive(false);
            StartCoroutine(Wait_To_Sprite_Stay());
        }
    }

    private void AutoMatchUpdated(object sender, AutoMatchEvent matchEvent)
    {
        Debug.Log("AutoMatchUpdated : " + matchEvent.Status);
        if (matchEvent.Players[0].User.IsMe)
        {
            player2Avatar.gameObject.SetActive(true);
            nickNamePlayer1.text = matchEvent.Players[0].Name;
            nickNamePlayer2.text = matchEvent.Players[1].Name;
            StartCoroutine(RawImage_Utils.DownloadImage(matchEvent.Players[0].Logo, player1Avatar));
            StartCoroutine(RawImage_Utils.DownloadImage(matchEvent.Players[1].Logo, player2Avatar));
        }
        if (matchEvent.Players[1].User.IsMe)
        {
            player2Avatar.gameObject.SetActive(true);
            nickNamePlayer1.text = matchEvent.Players[1].Name;
            nickNamePlayer2.text = matchEvent.Players[0].Name;
            StartCoroutine(RawImage_Utils.DownloadImage(matchEvent.Players[1].Logo, player1Avatar));
            StartCoroutine(RawImage_Utils.DownloadImage(matchEvent.Players[0].Logo, player2Avatar));
            
        }
    }

    IEnumerator Wait_To_Sprite_Stay()
    {
        yield return new WaitForSeconds(2f);
        //SceneManager.LoadScene("Game-c# 1");
        match.SetActive(false);
        game.SetActive(true);
    }
    
    IEnumerator Wait_To_Back_Home()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Home");
    }
    
    //Start When
    async void Start (){
	    playerMoney.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("PlayerMoney");
	    playerCoin.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("PlayerCoin");
	    SetEventHandelers();
        await GameService.GSLive.TurnBased().AutoMatch(new GSLiveOption.AutoMatchOption("Test", 2, 2));
    }

}
