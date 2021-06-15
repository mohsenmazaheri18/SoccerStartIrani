using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiroozehGameService.Core;
using FiroozehGameService.Core.GSLive;
using FiroozehGameService.Handlers;
using FiroozehGameService.Models;
using FiroozehGameService.Models.Enums.GSLive;
using FiroozehGameService.Models.GSLive;
using FiroozehGameService.Models.GSLive.Command;
using FiroozehGameService.Models.GSLive.TB;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Debug = UnityEngine.Debug;

public class MenuController_Login : MonoBehaviour
{

    [Header("InputField")]
    public InputField NickName;
    public InputField  Email, Password;

    [Header("Button")]
    public Button startGameBtn;
    public Button Submit;
    
    [Header("GameObject")]
    public GameObject SwitchToRegisterOrLogin;

    [Header("Text")]
    public Text  startMenuText;
    public Text Status, LoginErr, Turn; 

    [Header("Canvas")]
    public Canvas startMenu;
    public Canvas LoginCanvas, GamePlay;
    
    //boolian in work
    private bool _isSuccessfullyLogin , isMatchmaking;
    
    //member in work to turn based choose next
    private Member _me, _opponent, _currentTurnMember, _whoIsX;
    
    
    private async void Start ()
    {
        try
        {
            //GameInit ();    this is a meckanic game
            
           // SetEventListeners();
            await ConnectToGamesService();
        }
        catch (Exception e)
        {
            Status.text = "Start Err : " + e.Message;
            Debug.LogError("Start Err : " + e.Message);
        }
      
    }
    void Update ()
    {
        if (_isSuccessfullyLogin && !GameService.GSLive.IsCommandAvailable())
        {
            startGameBtn.interactable = false;
            Status.color = Color.red;
            Status.text = "GameService Not Connected";
        }
        else if (_isSuccessfullyLogin && GameService.GSLive.IsCommandAvailable())
        {
            if(!isMatchmaking) startGameBtn.interactable = true;
            Status.color = Color.black;
            Status.text = "Status : Connected!";
        }
        
        
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        Application.Quit();
    }

    /// <summary>
    /// Connect To GameService -> Login Or SignUp
    /// It May Throw Exception
    /// </summary>
    private async Task ConnectToGamesService ()
    {
        //connecting to GamesService
        Status.text = "Status : Connecting...";
        startGameBtn.interactable = false;
        SwitchToRegisterOrLogin.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (NickName.IsActive())
            {
                NickName.gameObject.SetActive(false);
                SwitchToRegisterOrLogin.GetComponent<Text>().text = "Dont have an account? Register!";
            }
            else
            {
                NickName.gameObject.SetActive(true);
                SwitchToRegisterOrLogin.GetComponent<Text>().text = "Have an Account? Login!";
            }
        });

        if (FileUtil.IsLoginBefore())
        {
            try
            {
                await GameService.LoginOrSignUp.LoginWithToken(FileUtil.GetUserToken());
                
                // Disable LoginUI
                startMenu.enabled = true;
                LoginCanvas.enabled = false;
            }
            catch (Exception e)
            {
                Status.color = Color.red;
                if (e is GameServiceException) Status.text = "GameServiceException : " + e.Message;
                else Status.text = "InternalException : " + e.Message;
            }
           
        }
        else
        {
            // Enable LoginUI
            startMenu.enabled = false;
            LoginCanvas.enabled = true;
            
            Submit.onClick.AddListener(async () =>
            {
                try
                {
                    if (NickName.IsActive()) // is SignUp
                    {
                        var nickName = NickName.text.Trim();
                        var email = Email.text.Trim();
                        var pass = Password.text.Trim();

                        if (string.IsNullOrEmpty(nickName)
                            && string.IsNullOrEmpty(email)
                            && string.IsNullOrEmpty(pass))
                            LoginErr.text = "Invalid Input!";
                        else
                        {
                            var userToken = await GameService.LoginOrSignUp.SignUp(nickName, email, pass);
                            FileUtil.SaveUserToken(userToken);
                        }

                    }
                    else
                    {
                        var email = Email.text.Trim();
                        var pass = Password.text.Trim();

                        if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(pass))
                            LoginErr.text = "Invalid Input!";
                        else
                        {
                            var userToken = await GameService.LoginOrSignUp.Login(email, pass);
                            FileUtil.SaveUserToken(userToken);
                            
                            // Disable LoginUI
                            startMenu.enabled = true;
                            LoginCanvas.enabled = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    if (e is GameServiceException) LoginErr.text = "GameServiceException : " + e.Message;
                    else LoginErr.text = "InternalException : " + e.Message;
                }
               
            });
        }        
    }
    /// <summary>
    /// Set Event Listeners
    /// </summary>
    private void SetEventListeners()
    {
        TurnBasedEventHandlers.SuccessfullyLogined += OnSuccessfullyLogined;
        TurnBasedEventHandlers.Error += OnError;
        TurnBasedEventHandlers.Reconnected += Reconnected;
        TurnBasedEventHandlers.JoinedRoom += OnJoinRoom;
        TurnBasedEventHandlers.Completed += OnCompleted;
        TurnBasedEventHandlers.AutoMatchUpdated += AutoMatchUpdated;
        TurnBasedEventHandlers.VoteReceived += VoteReceived;
        TurnBasedEventHandlers.ChoosedNext += OnChooseNext;
        TurnBasedEventHandlers.TakeTurn += OnTakeTurn;
        TurnBasedEventHandlers.LeftRoom += OnLeaveRoom;
        TurnBasedEventHandlers.RoomMembersDetailReceived += OnRoomMembersDetailReceived;
        TurnBasedEventHandlers.CurrentTurnMemberReceived += OnCurrentTurnMember;
    }
    
    
    
    // tabe haye no ok should i learn it
    private void OnLeaveRoom(object sender, Member member)
    {
        
    }//in dota kar beshe rosh
    private void OnChooseNext(object sender, Member whoIsNext)
    {
        Debug.Log("OnChooseNext : " + whoIsNext.Name);
        try
        {
            _currentTurnMember = whoIsNext.User.IsMe ? _me : _opponent;
            if (_currentTurnMember != null)
                Turn.text = _currentTurnMember.User.IsMe ? "You Turn" : "Opponent Turn";
            else Turn.text = null;
          
        }
        catch (Exception e)
        {
            Turn.text = "OnChooseNext Err : " + e.Message;
            Debug.LogError("OnChooseNext Err : " + e.Message);
        }
    }//in dota kar beshe rosh
    private void OnTakeTurn(object sender, Turn turn)
    {
        
    } //in dota kar beshe rosh
    private void VoteReceived(object sender, Vote vote)
    {
        
    } //in dota kar beshe rosh
    private void OnCompleted(object sender, Complete complete)
    {

    }//in dota kar beshe rosh
    

    
    // tabe haye ok!
    private void OnCurrentTurnMember(object sender, Member currentMember)
    {
        try
        {
            _currentTurnMember = currentMember;
             
            // Only Set In First
            if(_whoIsX == null)
                _whoIsX = currentMember;
        
            if (_currentTurnMember != null)
                Turn.text = _currentTurnMember.User.IsMe ? "You Turn" : "Opponent Turn";
            else Turn.text = null;

        }
        catch (Exception e)
        {
            Turn.text = "OnCurrentTurnMember Err : " + e.Message;
            Debug.LogError("OnCurrentTurnMember Err : " + e.Message);
        }
    }
    private void OnRoomMembersDetailReceived(object sender, List<Member> members)
    {
        // Set Players Info 
        foreach (var member in members)
        {
            if (member.User.IsMe) _me = member;
            else _opponent = member;
        }
    }
    private void AutoMatchUpdated(object sender, AutoMatchEvent autoMatch)
    {
        Debug.Log("AutoMatchUpdated :" + autoMatch.Status);
        foreach (var member in autoMatch.Players)
        {
            Debug.Log(member.User.Name);
        }
    }
    private async void OnJoinRoom(object sender, JoinEvent joinEvent)
    {
        Debug.Log("OnJoinRoom");
        Debug.Log("JoinedPlayers : " + joinEvent.JoinData.RoomData.JoinedPlayers);

        isMatchmaking = false;
        
        
        try
        {
            startMenu.enabled = false;
            GamePlay.enabled = true;

            if (joinEvent.JoinData.JoinedMember.User.IsMe)
                _me = joinEvent.JoinData.JoinedMember;
            else _opponent = joinEvent.JoinData.JoinedMember;
                    
            // Get Players Info
            if(_me == null || _opponent == null)
                await GameService.GSLive.TurnBased().GetRoomMembersDetail();

            // Get CurrentTurn Info
            if (_currentTurnMember == null)
                await GameService.GSLive.TurnBased().GetCurrentTurnMember();
        }
        catch (Exception exception)
        {
            Turn.text = "OnJoinRoom Err : " + exception.Message;
            Debug.LogError("OnJoinRoom Err : " + exception.Message);
        }
    }
    private void Reconnected(object sender, ReconnectStatus reconnectStatus)
    {
        Debug.Log("Reconnected : " + reconnectStatus);
    }
    private void OnError(object sender, ErrorEvent errorEvent)
    {
        Status.color = Color.red;
        Status.text = "Error : " + errorEvent.Error + " , From : " + errorEvent.Type;
        Debug.LogError("GameService Err : " + errorEvent.Error + " , From : " + errorEvent.Type);
    }
    private void OnSuccessfullyLogined(object sender, EventArgs eventArgs)
    {
        try
        {
            _isSuccessfullyLogin = true;
            Status.text = "Status : Connected!";
            startGameBtn.interactable = true;
        
            // Start Game
            startGameBtn.onClick.AddListener(async () =>
            {
                if (GameService.GSLive.IsCommandAvailable())
                {
                    isMatchmaking = true;
                    await GameService.GSLive.TurnBased().AutoMatch(
                        new GSLiveOption.AutoMatchOption("partner", 2, 2, false));

                    // go to waiting ui
                    startGameBtn.interactable = false;
                    startMenuText.text = "MatchMaking...";
                }
                else
                {
                    startGameBtn.interactable = false;
                    Status.color = Color.red;
                    Status.text = "GameService Not Connected";
                }

            });
        }
        catch (Exception exception)
        {
            Debug.LogError("OnSuccessfullyLogined Err : " + exception.Message);
            Status.text = "OnSuccessfullyLogined Err : " + exception.Message;
        }
    }
    
}
