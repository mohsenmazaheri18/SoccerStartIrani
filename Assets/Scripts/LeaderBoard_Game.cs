using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FiroozehGameService.Core;
using FiroozehGameService.Models.BasicApi;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using Utils;

public class LeaderBoard_Game : MonoBehaviour
{
    
    public GameObject SampleRowObject;
    
    private List<LeaderBoard> _leaderBoards;

    // Start is called before the first frame update
    async void Start()
    {
        _leaderBoards = new List<LeaderBoard>();
        SetTable();
        var Get_Leader = await GameService.Leaderboard.GetLeaderBoards();
        Get_Leader.Clear();
        Get_Leader.AddRange(_leaderBoards);

    }

    async void SetTable()
    {

        var leaderBoardDetails = await GameService.Leaderboard.GetLeaderBoardDetails(_leaderBoards[0].Key);

        for (int i = 0; i < _leaderBoards.Count; i++)
        {
            GameObject ObjTemp;
            ObjTemp = Instantiate(SampleRowObject, SampleRowObject.transform.parent);
            ObjTemp.transform.GetChild(0).GetComponent<Text>().text = "#" + (i + 1);
            ObjTemp.transform.GetChild(1).GetComponent<Text>().text = leaderBoardDetails.Scores[i].Submitter.Name;
            ObjTemp.transform.GetChild(2).GetComponent<Text>().text = leaderBoardDetails.Scores[i].Rank.ToString();
            StartCoroutine(RawImage_Utils.DownloadImage(leaderBoardDetails.Scores[i].Submitter.Logo,ObjTemp.transform.GetChild(3).GetComponent<RawImage>()));
            ObjTemp.transform.GetChild(5).GetComponent<Text>().text = leaderBoardDetails.Scores[i].Tries.ToString();
            ObjTemp.SetActive(true);
        }
        
    }
}
