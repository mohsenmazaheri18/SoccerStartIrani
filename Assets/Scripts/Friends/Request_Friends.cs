using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FiroozehGameService.Core;
using FiroozehGameService.Models.GSLive;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class Request_Friends : MonoBehaviour
{
    public Button accept;
    public Button decline;
    
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
        
        for (int i = 0; i < _members.Count; i++)
        {
            var friendRequests = await GameService.Social.Friends().GetFriendRequests();
            GameObject ObjTemp;
            ObjTemp = Instantiate(SampleRowObject, SampleRowObject.transform.parent);
            ObjTemp.transform.GetChild(0).GetComponent<Text>().text = "#" + (i + 1);
            ObjTemp.transform.GetChild(1).GetComponent<Text>().text = friendRequests.Values[i].Member.Name;
            ObjTemp.transform.GetChild(2).GetComponent<Text>().text = friendRequests.Values[i].Member.User.Point.ToString();
            StartCoroutine(RawImage_Utils.DownloadImage(friendRequests.Values[i].Member.Logo,ObjTemp.transform.GetChild(3).GetComponent<RawImage>()));
            ObjTemp.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(async () =>
            {
                for (int j = 0; j < _members.Count; j++)
                {
                    await GameService.Social.Friends().AcceptFriendRequest(_members[j].Name);
                }
            });
            ObjTemp.transform.GetChild(5).GetComponent<Button>().onClick.AddListener(async () =>
            {
                for (int j = 0; j < _members.Count; j++)
                {
                    Destroy(ObjTemp);
                }
            });
            ObjTemp.SetActive(true);
        }
        
    }
}
