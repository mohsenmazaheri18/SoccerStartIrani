using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FiroozehGameService.Core;
using FiroozehGameService.Models.GSLive;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class Add_Friends : MonoBehaviour
{
    public InputField Find;
    public Button Search;

    public GameObject SampleRowObject;
    
    private List<Member> _members;
    
     void Start()
     {
         _members = new List<Member>();

         Search.onClick.AddListener(async () =>
      {
          Destroy(GameObject.Find("Add_Friends"));
          await GameService.Social.Friends().FindMembers(Find.name);
          SetTable();
      });
    }

     void SetTable()
     {
         for (int i = 0; i < _members.Count; i++)
         {
             GameObject ObjTemp;
             ObjTemp = Instantiate(SampleRowObject, SampleRowObject.transform.parent);
             ObjTemp.transform.GetChild(0).GetComponent<Text>().text = "#" + (i + 1);
             ObjTemp.transform.GetChild(1).GetComponent<Text>().text = _members[i].Name;
             ObjTemp.transform.GetChild(2).GetComponent<Text>().text = _members[i].User.Point.ToString();
             StartCoroutine(RawImage_Utils.DownloadImage(_members[i].User.Logo,ObjTemp.transform.GetChild(3).GetComponent<RawImage>()));
             
             ObjTemp.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(async () =>
             {
                 for (int j = 0; j < _members.Count; j++)
                 {
                     await GameService.Social.Friends().SendFriendRequest(_members[j].Name);
                 }
             });
             ObjTemp.SetActive(true);
         }
         
        
    }
}
