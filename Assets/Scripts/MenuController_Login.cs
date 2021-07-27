using System;
using FiroozehGameService.Core;
using FiroozehGameService.Models;
using FiroozehGameService.Models.Consts;
using Google;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    public Canvas Question_Canvas;

    
    private async void Start()
    {
        //load email player prefs
        string SaveEmail = PlayerPrefs.GetString("SaveEmail");
        Email.text = SaveEmail;
        
        //load password player prefs
        string SavePass = PlayerPrefs.GetString("SavePass");
        Password.text = SavePass;
        
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
                            
                            //save email
                            PlayerPrefs.SetString("SaveEmail",Email.text);
                            PlayerPrefs.Save();
                            
                            //save pass
                            PlayerPrefs.SetString("SavePass",Password.text);
                            PlayerPrefs.Save();

                            // Disable LoginUI
                            Question_Canvas.enabled = true;
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
                            
                            //save email
                            PlayerPrefs.SetString("SaveEmail",Email.text);
                            PlayerPrefs.Save();
                            
                            //save pass
                            PlayerPrefs.SetString("SavePass",Password.text);
                            PlayerPrefs.Save();

                            if (email == "Daryoushfaeghi@gmail.com"&&pass=="Daryoush235@")
                            {
                                SceneManager.LoadScene("Admin_Home");
                            }

                            // Disable LoginUI
                            //Question_Canvas.enabled = true;
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
