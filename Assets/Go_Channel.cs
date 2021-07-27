using System.Collections;
using System.Collections.Generic;
using FiroozehGameService.Core;
using FiroozehGameService.Handlers;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Go_Channel : MonoBehaviour
{
    public Button Esteghlal;
    public Button Perspolice;
    
    // Start is called before the first frame update
     void Start()
     {
         Esteghlal.onClick.AddListener(async () =>
         {
             await GameService.GSLive.Chat().SubscribeChannel("Blue");
             ChatEventHandlers.OnSubscribeChannel +=OnSubscribeChannel;
             SceneManager.LoadScene("Chat_Blue");
         });
        
         Perspolice.onClick.AddListener(async () =>
         {
             await GameService.GSLive.Chat().SubscribeChannel("Red");
             ChatEventHandlers.OnSubscribeChannel +=OnSubscribeChannel;
             SceneManager.LoadScene("Chat_Red");
         });   
         

    }
    private void OnSubscribeChannel(object sender, string s)
    {
        Debug.Log("OnSubscribeChannel: " + name);
        
    }
}
