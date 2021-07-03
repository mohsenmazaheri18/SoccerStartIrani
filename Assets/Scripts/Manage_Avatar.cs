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
using FileUtil = UnityEditor.FileUtil;
using UnityEditor.UI;
using UnityEngine.Experimental.Rendering;


public class Manage_Avatar : MonoBehaviour
{
    public RawImage[] avatar;



    // Start is called before the first frame update
    async void Start()
    {
        var player_avatar = await GameService.Player.GetCurrentPlayer();
        Debug.Log(player_avatar.Logo);
        StartCoroutine(RawImage_Utils.DownloadImage(player_avatar.Logo, avatar[0]));
        StartCoroutine(RawImage_Utils.DownloadImage(player_avatar.Logo, avatar[1]));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
