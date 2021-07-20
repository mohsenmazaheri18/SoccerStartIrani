using System.Collections;
using System.Collections.Generic;
using FiroozehGameService.Core;
using FiroozehGameService.Handlers;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class Go_Channel : MonoBehaviour
{
    public Button Esteghlal;
    public Button Perspolice;
    
    // Start is called before the first frame update
    async void Start()
    {
        ChatEventHandlers.OnSubscribeChannel +=OnSubscribeChannel;
        SubscribeChannel("Blue".Trim());
        Esteghlal.onClick.AddListener(async () =>
        {
            await GameService.GSLive.Chat().SubscribeChannel("Blue");
        });   
        
        Perspolice.onClick.AddListener(async () =>
        {
            await GameService.GSLive.Chat().SubscribeChannel("Red");
        });   
    }
    private void OnSubscribeChannel(object sender, string s)
    {
        Debug.Log("OnSubscribeChannel: " + name);
    }
    
    private async void SubscribeChannel(string channelName)
    {
        await GameService.GSLive.Chat().SubscribeChannel(channelName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
