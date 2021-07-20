using System.Collections;
using FiroozehGameService.Core;
using FiroozehGameService.Core.GSLive;
using FiroozehGameService.Handlers;
using FiroozehGameService.Models.GSLive.Command;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

public class MatchMaking : MonoBehaviour
{
    
    
    //Match Making Game
    public Text NickName_Player1;
    public Text NickName_Player2;
    public GameObject player_role; 
    public RawImage player1_avatar;
    public RawImage player2_avatar;
    
    public Text playerMoney;
    public Text playerCoin;
    
    public async void Cansel_AutoMatch()
    {
        await GameService.GSLive.RealTime().CancelAutoMatch();
        StartCoroutine(Wait_To_Back_Home());
    }


    private void SetEventHandelers()
    {
	    RealTimeEventHandlers.AutoMatchUpdated += AutoMatchUpdated;
        RealTimeEventHandlers.JoinedRoom += JoinedRoom;
    }

    private void JoinedRoom(object sender, JoinEvent joinEvent)
    {
        Debug.Log("JoinedRoom : " + joinEvent.JoinData.RoomData.Name);

        if (joinEvent.JoinData.RoomData.Max==2)
        {
            player_role.SetActive(false);
            StartCoroutine(Wait_To_Sprite_Stay());
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
            StartCoroutine(RawImage_Utils.DownloadImage(matchEvent.Players[0].Logo, player1_avatar));
            StartCoroutine(RawImage_Utils.DownloadImage(matchEvent.Players[1].Logo, player2_avatar));
        }
        if (matchEvent.Players[1].User.IsMe)
        {
            player2_avatar.gameObject.SetActive(true);
            NickName_Player1.text = matchEvent.Players[1].Name;
            NickName_Player2.text = matchEvent.Players[0].Name;
            StartCoroutine(RawImage_Utils.DownloadImage(matchEvent.Players[1].Logo, player1_avatar));
            StartCoroutine(RawImage_Utils.DownloadImage(matchEvent.Players[0].Logo, player2_avatar));
            
        }
    }

    IEnumerator Wait_To_Sprite_Stay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game-c#2");
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
	    await GameService.GSLive.RealTime().AutoMatch(new GSLiveOption.AutoMatchOption("Test", 2, 2, false));
    }

}
