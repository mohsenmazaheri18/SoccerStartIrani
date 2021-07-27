using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mohreh_UI : MonoBehaviour
{
    [Header("Button To Event")] public Button Country;
    public Button lig_bartar, lig_dasteh1, Mystery, Offical;

    [Header("Button To Event")] public GameObject Country_Mohreh;
    public GameObject lig_bartar_Mohreh, lig_dasteh1_Mohreh, Mystery_Mohreh, Offical_Mohreh;

    // Start is called before the first frame update
    void Start()
    {
        Country.onClick.AddListener(() =>
        {
            Country.image.color = new Color(0f, 0.55f, 0f, 1f);
            lig_bartar.image.color = Color.grey;
            lig_dasteh1.image.color = Color.grey;
            Mystery.image.color = Color.grey;
            Offical.image.color = Color.grey;
            Country_Mohreh.SetActive(true);
            lig_bartar_Mohreh.SetActive(false);
            lig_dasteh1_Mohreh.SetActive(false);
            Mystery_Mohreh.SetActive(false);
            Offical_Mohreh.SetActive(false);
        });

        lig_bartar.onClick.AddListener(() =>
        {
            lig_bartar.image.color = new Color(0f, 0.55f, 0f, 1f);
            Country.image.color = Color.grey;
            Mystery.image.color = Color.grey;
            lig_dasteh1.image.color = Color.grey;
            Offical.image.color = Color.grey;
            lig_bartar_Mohreh.SetActive(true);
            Country_Mohreh.SetActive(false);
            lig_dasteh1_Mohreh.SetActive(false);
            Mystery_Mohreh.SetActive(false);
            Offical_Mohreh.SetActive(false);
        });

        lig_dasteh1.onClick.AddListener(() =>
        {
            lig_dasteh1.image.color = new Color(0f, 0.55f, 0f, 1f);
            Mystery.image.color = Color.grey;
            Country.image.color = Color.grey;
            lig_bartar.image.color = Color.grey;
            Offical.image.color = Color.grey;
            lig_dasteh1_Mohreh.SetActive(true);
            Country_Mohreh.SetActive(false);
            lig_bartar_Mohreh.SetActive(false);
            Mystery_Mohreh.SetActive(false);
            Offical_Mohreh.SetActive(false);
        });

        Mystery.onClick.AddListener(() =>
        {
            Mystery.image.color = new Color(0f, 0.55f, 0f, 1f);
            lig_dasteh1.image.color = Color.grey;
            Country.image.color = Color.grey;
            lig_bartar.image.color = Color.grey;
            Offical.image.color = Color.grey;
            Mystery_Mohreh.SetActive(true);
            Country_Mohreh.SetActive(false);
            lig_bartar_Mohreh.SetActive(false);
            lig_dasteh1_Mohreh.SetActive(false);
            Offical_Mohreh.SetActive(false);
        });
        
        Offical.onClick.AddListener(() =>
        {
            Offical.image.color = new Color(0f, 0.55f, 0f, 1f);
            lig_dasteh1.image.color = Color.grey;
            Country.image.color = Color.grey;
            lig_bartar.image.color = Color.grey;
            Mystery.image.color = Color.grey;
            Offical_Mohreh.SetActive(true);
            Country_Mohreh.SetActive(false);
            lig_bartar_Mohreh.SetActive(false);
            lig_dasteh1_Mohreh.SetActive(false);
            Mystery_Mohreh.SetActive(false);
        });
    }
}
