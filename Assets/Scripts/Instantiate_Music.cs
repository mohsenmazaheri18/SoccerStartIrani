using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_Music : MonoBehaviour
{
    public GameObject Musics;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Musics);
    }
}
