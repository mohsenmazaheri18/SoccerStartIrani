using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using FiroozehGameService.Core;
using FiroozehGameService.Models.BasicApi;
using UnityEngine;
using UnityEngine.UI;
using FiroozehGameService.Utils;
using FiroozehGameService.Utils.Serializer;
using GProtocol.Utils.IO;
using UnityEngine.Networking;
using Utils;


public class Manage_Avatar : MonoBehaviour
{
    public RawImage[] avatar;
    public GameObject mENU;



    // Start is called before the first frame update
    async void Start()
    {
        mENU.SetActive(true);
        var playerAvatar = await GameService.Player.GetCurrentPlayer();
        Debug.Log(playerAvatar.Logo);
        StartCoroutine(RawImage_Utils.DownloadImage(playerAvatar.Logo, avatar[0]));
        StartCoroutine(RawImage_Utils.DownloadImage(playerAvatar.Logo, avatar[1]));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
