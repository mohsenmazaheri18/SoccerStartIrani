using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FiroozehGameService.Core;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    
    // Start is called before the first frame update
    async void Start()
    {
         var Achievemented = await GameService.Achievement.GetAchievements();
         var achievment = await GameService.Achievement.UnlockAchievement(Achievemented[0].Key);
         Debug.Log(achievment.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
