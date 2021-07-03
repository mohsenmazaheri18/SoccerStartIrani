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
    public Canvas form, mohre;
    
    // Start is called before the first frame update
    async void Start()
    {
        var get_data = await GameService.Player.GetCurrentPlayer();
        nickname.text = get_data.Name;
        id_name.text = "(UserId: "+get_data.Name+" )";

        back.onClick.AddListener(()=>
       {
          this.gameObject.SetActive(false);
       });
        buy_form.onClick.AddListener(()=>
        {
            profile.enabled = false;
            form.enabled = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
