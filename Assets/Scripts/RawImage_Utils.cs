using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Utils
{
    public class RawImage_Utils 
    {
        public static IEnumerator DownloadImage(string mediaURL, RawImage image)
        {
            var request = UnityWebRequestTexture.GetTexture(mediaURL);
            yield return request.SendWebRequest();
            image.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
        }
    }
}

