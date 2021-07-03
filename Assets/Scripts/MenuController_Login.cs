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
using Google;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;
using Debug = UnityEngine.Debug;
using FileUtil = Utils.FileUtil;

public class MenuController_Login : MonoBehaviour
{
    [Header("Button To Login")]
    public Button Google;
    public Button ID_Login, Guest;
    

    [Header("Login Mode ID Text")]
    public Text Status;
    public Text LoginErr;
    public Text Submit_Text;


    [Header("Login Mode ID Button")]
    public Button Submit;
    public GameObject SwitchToRegisterOrLogin;

    [Header("Login Mode ID Input Field")] 
    public InputField NickName;
    public InputField Email;
    public InputField Password;

    [Header("Canvas And Object To Start Game")]
    public Canvas Mode_Canvas;
    public Canvas Id_Login_Canvas;

    private async void Start()
    {
        //var user = await GameService.Player.GetCurrentPlayer();
        //Debug.Log(user.Name);
       /* Google.onClick.AddListener(() =>
        {
            GoogleSignIn.Configuration = new GoogleSignInConfiguration();
            GoogleSignIn.Configuration.UseGameSignIn = true;
            GoogleSignIn.Configuration.RequestEmail = true;
            GoogleSignIn.Configuration.RequestIdToken = true;
            GameService.LoginOrSignUp.LoginOrSignUpWithGoogle(GoogleSignIn.DefaultInstance.SignIn().ToString());
            // Menu.SetActive(true);
            //Mode_Canvas.enabled = false;
        });*/

        ID_Login.onClick.AddListener(() =>
        {
            Id_Login_Canvas.enabled = true;
            Mode_Canvas.enabled = false;
        });

        Guest.onClick.AddListener(async () =>
        {
            
            await GameService.LoginOrSignUp.LoginAsGuest();
            SceneManager.LoadScene("Home");
        });
        
        SwitchToRegisterOrLogin.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (NickName.IsActive())
            {
                NickName.gameObject.SetActive(false);
                SwitchToRegisterOrLogin.GetComponent<Text>().text = "!ﺯﺎﺴﺑ ﯽﮑﯾ ﯼﺭﺍﺪﻧ ﺖﻧﺎﮐﺍ";
                Submit_Text.text = "دورو";
            }
            else
            {
                NickName.gameObject.SetActive(true);
                SwitchToRegisterOrLogin.GetComponent<Text>().text = "!ﻮﺷ ﺩﺭﺍﻭ ﯼﺭﺍﺩ ﺖﻧﺎﮐﺍ";
                Submit_Text.text = "ﺖﻧﺎﮐﺍ ﺖﺧﺎﺳ";
            }
        });

      /*  if (FileUtil.IsLoginBefore())
        {
            Debug.Log("Click");
            try
            {
                await GameService.LoginOrSignUp.LoginWithToken(FileUtil.GetUserToken());

                // Disable LoginUI
                Menu.SetActive(true);
                Mode_Canvas.enabled = false;
            }
            catch (Exception e)
            {
                Status.color = Color.red;
                if (e is GameServiceException) Status.text = "GameServiceException : " + e.Message;
                else Status.text = "InternalException : " + e.Message;
            }

        }
        else
        {*/

            // Enable LoginUI
          // Menu.SetActive(false);
          //  Mode_Canvas.enabled = true;

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
                            SceneManager.LoadScene("Home");
                        }

                        GameService.IsAuthenticated();
                    }
                }
                catch (Exception e)
                {
                    if (e is GameServiceException) LoginErr.text = "GameServiceException : " + e.Message;
                    else LoginErr.text = "InternalException : " + e.Message;
                }

            });
       // }
    }
}
