using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPassword : MonoBehaviour
{

    public InputField Password;

    public Button ShowPass;
    public Button HidePass;
    // Start is called before the first frame update
    void Start()
    {
        ShowPass.onClick.AddListener(() =>
        {
            Password.contentType = InputField.ContentType.Standard;
            Password.Select();
            ShowPass.gameObject.SetActive(false);
            HidePass.gameObject.SetActive(true);
        });
        HidePass.onClick.AddListener(() =>
        {
            Password.contentType = InputField.ContentType.Password;
            Password.Select();
            ShowPass.gameObject.SetActive(true);
            HidePass.gameObject.SetActive(false);
        });
    }
    
}
