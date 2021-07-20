using FiroozehGameService.Core;
using Plugins.GameService.Utils.RealTimeUtil;
using Plugins.GameService.Utils.RealTimeUtil.Models.CallbackModels;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Game_Manager_Instatiate : MonoBehaviour
{
    public GameObject opponent;
    public GameObject ball;
    public GameObject player1;
    public GameObject player2;
    public GameObject aim;
    public GameObject helper;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GsLiveRealtime.Instantiate(ball.name, new Vector3(0, 0, 0), Quaternion.identity);
        GsLiveRealtime.Instantiate(player1.name, new Vector3(0, 0, 0), Quaternion.identity);
        GsLiveRealtime.Instantiate(player2.name, new Vector3(0, 0, 0), Quaternion.identity);
        GsLiveRealtime.Instantiate(opponent.name, new Vector3(0, 0, 0), Quaternion.identity);
        GsLiveRealtime.Instantiate(aim.name, new Vector3(0, 0, 0), Quaternion.identity);
        GsLiveRealtime.Instantiate(helper.name, new Vector3(0, 0, 0), Quaternion.identity);

        GsLiveRealtime.Callbacks.OnBeforeInstantiateHandler += OnBeforeInstantiateHandler;
        GsLiveRealtime.Callbacks.OnAfterInstantiateHandler +=OnAfterInstantiateHandler;
    }

    private void OnAfterInstantiateHandler(object sender, OnAfterInstantiate afterInstantiate)
    {
        ball = afterInstantiate.gameObject;
        player1 = afterInstantiate.gameObject;
        player2 = afterInstantiate.gameObject;
        opponent = afterInstantiate.gameObject;
        aim = afterInstantiate.gameObject;
        helper = afterInstantiate.gameObject;

        ball.SetActive(true);
        player1.SetActive(true);
        player2.SetActive(true);
        opponent.SetActive(true);
        aim.SetActive(true);
        helper.SetActive(true);
    }

    private void OnBeforeInstantiateHandler(object sender, OnBeforeInstantiate beforeInstantiate)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
