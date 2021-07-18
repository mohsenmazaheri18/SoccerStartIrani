using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mohreh_UI : MonoBehaviour
{
    [Header("Button To Event")] public Button Country;
    public Button lig_bartar, lig_dasteh1, Mystery;

    [Header("Button To Event")] public GameObject Country_Mohreh;
    public GameObject lig_bartar_Mohreh, lig_dasteh1_Mohreh, Mystery_Mohreh;

    // Start is called before the first frame update
    void Start()
    {
        Country.onClick.AddListener(() =>
        {
            Country.image.color = Color.green;
            lig_bartar.image.color = Color.grey;
            lig_dasteh1.image.color = Color.grey;
            Mystery.image.color = Color.grey;
            Country_Mohreh.SetActive(true);
            lig_bartar_Mohreh.SetActive(false);
            lig_dasteh1_Mohreh.SetActive(false);
            Mystery_Mohreh.SetActive(false);
        });

        lig_bartar.onClick.AddListener(() =>
        {
            lig_bartar.image.color = Color.green;
            Country.image.color = Color.grey;
            Mystery.image.color = Color.grey;
            lig_dasteh1.image.color = Color.grey;
            lig_bartar_Mohreh.SetActive(true);
            Country_Mohreh.SetActive(false);
            lig_dasteh1_Mohreh.SetActive(false);
            Mystery_Mohreh.SetActive(false);
        });

        lig_dasteh1.onClick.AddListener(() =>
        {
            lig_dasteh1.image.color = Color.green;
            Mystery.image.color = Color.grey;
            Country.image.color = Color.grey;
            lig_bartar.image.color = Color.grey;
            lig_dasteh1_Mohreh.SetActive(true);
            Country_Mohreh.SetActive(false);
            lig_bartar_Mohreh.SetActive(false);
            Mystery_Mohreh.SetActive(false);
        });

        Mystery.onClick.AddListener(() =>
        {
            Mystery.image.color = Color.green;
            lig_dasteh1.image.color = Color.grey;
            Country.image.color = Color.grey;
            lig_bartar.image.color = Color.grey;
            Mystery_Mohreh.SetActive(true);
            Country_Mohreh.SetActive(false);
            lig_bartar_Mohreh.SetActive(false);
            lig_dasteh1_Mohreh.SetActive(false);
        });
    }
}
