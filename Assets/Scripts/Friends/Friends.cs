using System.Collections.Generic;
using FiroozehGameService.Core;
using UnityEngine;
using UnityEngine.UI;
using FiroozehGameService.Models.GSLive;
using UnityEngine.Serialization;
using Utils;

public class Friends : MonoBehaviour
{
    
    [FormerlySerializedAs("SampleRowObject")] public GameObject sampleRowObject;
    
    private List<Member> _members;

    // Start is called before the first frame update
     void Start()
    {
        _members = new List<Member>();
        SetTable();
    }

    async void SetTable()
    {

        var frend = await GameService.Social.Friends().GetMyFriends();
        for (int i = 0; i < _members.Count; i++)
        {
            GameObject ObjTemp;
            ObjTemp = Instantiate(sampleRowObject, sampleRowObject.transform.parent);
            ObjTemp.transform.GetChild(0).GetComponent<Text>().text = "#" + (i + 1);
            ObjTemp.transform.GetChild(1).GetComponent<Text>().text = frend.Values[i].Member.Name;
            ObjTemp.transform.GetChild(2).GetComponent<Text>().text = frend.Values[i].Member.User.Point.ToString();
            StartCoroutine(RawImage_Utils.DownloadImage(frend.Values[i].Member.Logo,ObjTemp.transform.GetChild(3).GetComponent<RawImage>()));
            ObjTemp.SetActive(true);
        }
        
    }

}
