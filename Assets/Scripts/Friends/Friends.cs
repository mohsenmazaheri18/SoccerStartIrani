using System.Collections.Generic;
using FiroozehGameService.Core;
using UnityEngine;
using UnityEngine.UI;
using FiroozehGameService.Models.GSLive;
using Utils;

public class Friends : MonoBehaviour
{
    
    public GameObject SampleRowObject;
    
    private List<Member> _members;

    // Start is called before the first frame update
     void Start()
    {
        _members = new List<Member>();
        SetTable();
    }

    async void SetTable()
    {

        var Frend = await GameService.Social.Friends().GetMyFriends();
        for (int i = 0; i < _members.Count; i++)
        {
            GameObject ObjTemp;
            ObjTemp = Instantiate(SampleRowObject, SampleRowObject.transform.parent);
            ObjTemp.transform.GetChild(0).GetComponent<Text>().text = "#" + (i + 1);
            ObjTemp.transform.GetChild(1).GetComponent<Text>().text = Frend.Values[i].Member.Name;
            ObjTemp.transform.GetChild(2).GetComponent<Text>().text = Frend.Values[i].Member.User.Point.ToString();
            StartCoroutine(RawImage_Utils.DownloadImage(Frend.Values[i].Member.Logo,ObjTemp.transform.GetChild(3).GetComponent<RawImage>()));
            ObjTemp.SetActive(true);
        }
        
    }

}
