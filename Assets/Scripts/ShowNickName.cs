using UnityEngine;
using FiroozehGameService.Core;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShowNickName : MonoBehaviour
{
    [FormerlySerializedAs("NickName_SHOW")] public Text nickNameShow;
    [FormerlySerializedAs("Logout")] public Button logout;
    [FormerlySerializedAs("Menu")] public GameObject menu;
    
    // Start is called before the first frame update
    async void Start()
    {
       var member = await GameService.Player.GetCurrentPlayer();
       nickNameShow.text = member.Name;
       
       
       logout.onClick.AddListener( () =>
       {
           FiroozehGameService.Core.GameService.Logout();
           menu.SetActive(false);
           SceneManager.LoadScene("Login");
       });

    }
}
