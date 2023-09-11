using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveLoadDataService;

public class BestScore
{
    public const string nameJson = "Best score";
    public float Score;

    public void Load()
    {
        Score = PlayerPrefs.GetFloat("Score", 0);
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Score", Score);
    }
}
