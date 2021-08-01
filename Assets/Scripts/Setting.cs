using FiroozehGameService.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [Header("Music")]
    public Button Music_On;
    public Button Music_Off;

    [Header("Exit Account")]
    public Button Exit_Acc;
    
    [Header("Text ID User")]
    public Text UserID;
    // Start is called before the first frame update
    async void Start()
    {
        Music_On.onClick.AddListener(() =>
        {
            GameObject.Find("Music").GetComponent<AudioSource>().enabled = true;
        });
        Music_Off.onClick.AddListener(() =>
        {
            GameObject.Find("Music").GetComponent<AudioSource>().enabled = false;
        });
        Exit_Acc.onClick.AddListener( () =>
        {
             GameService.Logout();
             SceneManager.LoadScene("Login");
        });
        var employer = await GameService.Player.GetCurrentPlayer();
        UserID.text = employer.Id;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
