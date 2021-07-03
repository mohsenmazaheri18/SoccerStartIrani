using UnityEngine;
using FiroozehGameService.Core;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowNickName : MonoBehaviour
{
    public Text NickName_SHOW;
    public Button Logout;
    public GameObject Menu;
    
    // Start is called before the first frame update
    async void Start()
    {
       var member = await GameService.Player.GetCurrentPlayer();
       NickName_SHOW.text = member.Name;
       
       
       Logout.onClick.AddListener( () =>
       {
           FiroozehGameService.Core.GameService.Logout();
           Menu.SetActive(false);
           SceneManager.LoadScene("Login");
       });

    }
}
