using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile_LevelUp : MonoBehaviour
{
    private int Count = 0;
    private int LevelUp_Count = 1;
    public Slider Count_Slider;
    public Text Count_Text;
    public Text Levelup;

    public Button Level_Xp;

    public Text rank;
    
    // Start is called before the first frame update
    void Start()
    {
        Level_Xp.onClick.AddListener(() =>
        {
            Count = Count + 10;
            Count_Slider.value = Count;
            Count_Text.text = Count.ToString();

            if (Count>=100)
            {
                Count = 0;
                LevelUp_Count++;
                Levelup.text = LevelUp_Count.ToString();
                Count_Slider.value = 0;
                
            }
        });
        if (LevelUp_Count==1)
        {
            rank.text = "Beginner";
        }
       else if (LevelUp_Count==3)
        {
            rank.text = "Trainee";
        }
        else if (LevelUp_Count==10)
        {
            rank.text = "Loan Star";
        }
        else if (LevelUp_Count==15)
        {
            rank.text = "Squad Player";
        }
        else if (LevelUp_Count==21)
        {
            rank.text = "SuperSub";
        }
        else if (LevelUp_Count==36)
        {
            rank.text = "Midfield Maestro";
        }
        else if (LevelUp_Count==45)
        {
            rank.text = "Skilled Striker";
        }
        else if (LevelUp_Count==55)
        {
            rank.text = "Lethal Finisher";
        }
        else if (LevelUp_Count==66)
        {
            rank.text = "Goal Machine";
        }
        else if (LevelUp_Count==76)
        {
            rank.text = "Club Captain";
        }
        else if (LevelUp_Count==105)
        {
            rank.text = "Rank???";
        }
        else if (LevelUp_Count==120)
        {
            rank.text = "National Legend";
        }
        else if (LevelUp_Count==137)
        {
            rank.text = "WORLD STAR";
        }
        else if (LevelUp_Count==150)
        {
            rank.text = "WORLD STAR";
        }
        
    }


}
