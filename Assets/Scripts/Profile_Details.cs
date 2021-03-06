using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FiroozehGameService.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;
using FiroozehGameService.Utils;

public class Profile_Details : MonoBehaviour
{
    [Header("Text In Profile")]
    public Text nickname;
    public Text id_name;

    [Header("button In Profile")]
    public Button back;
    public Button buy_form, buy_Mohre;
    
    [Header("Canvas Manage")]
    public Canvas profile;
    public Canvas form, mohre, MenuAsli;
    
    // Start is called before the first frame update
    async void Start()
    {
        var getData = await GameService.Player.GetCurrentPlayer();
        nickname.text = getData.Name;
        id_name.text = "(UserId: "+getData.Name+" )";

        back.onClick.AddListener(()=>
        {
            profile.enabled = false;
            MenuAsli.enabled = true;
        });
        buy_form.onClick.AddListener(()=>
        {
            profile.enabled = false;
            form.enabled = true;
        });
        buy_Mohre.onClick.AddListener(() =>
        {
            profile.enabled = false;
            mohre.enabled = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
