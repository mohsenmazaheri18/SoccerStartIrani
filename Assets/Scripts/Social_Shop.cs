using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Social_Shop : MonoBehaviour
{
    [Header("Button To Event")]
    public Button Chat;
    public Button Imoji, Avatar,back;
    
    [Header("Button To Event")]
    public GameObject chat_pack;
    public GameObject Imoji_Pack,Avatar_Pack;
    
    // Start is called before the first frame update
    void Start()
    {
        Chat.onClick.AddListener(() =>
        {
            Chat.image.color = Color.green;
            Imoji.image.color = Color.grey;
            Avatar.image.color = Color.grey;
            chat_pack.SetActive(true);
            Imoji_Pack.SetActive(false);
            Avatar_Pack.SetActive(false);
        });
        
        Imoji.onClick.AddListener(() =>
        {
            Imoji.image.color = Color.green;
            Chat.image.color = Color.grey;
            Avatar.image.color = Color.grey;
            chat_pack.SetActive(false);
            Imoji_Pack.SetActive(true);
            Avatar_Pack.SetActive(false);
        });
        
        Avatar.onClick.AddListener(() =>
        {
            Avatar.image.color = Color.green;
            Chat.image.color = Color.grey;
            Imoji.image.color = Color.grey;
            chat_pack.SetActive(false);
            Imoji_Pack.SetActive(false);
            Avatar_Pack.SetActive(true);
        });
        
        back.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Shop");
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
