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
    public Text nickname;
    public Text id_name;

    public Button back;
    
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
