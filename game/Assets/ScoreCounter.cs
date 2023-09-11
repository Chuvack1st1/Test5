using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private TextMeshProUGUI scoreMassege;
    [SerializeField] private TextMeshProUGUI bestScoreMassege;

    private float startPosition;

    private float currentPosition;

    private float currentScore;

    private BestScore bestScore = new();

    private void OnEnable()
    {
        SaveLoadDataService.SaveDataEvent += bestScore.Save;
        SaveLoadDataService.LoadDataEvent += bestScore.Load;
        PlayerManager.PlayerDieAction += OnPlayerDie;
    }

    private void Start()
    {
        startPosition = player.transform.position.z;
        currentScore = 0;

        currentPosition = startPosition;
    }

    private void Update()
    {
        currentPosition = player.transform.position.z;

        currentScore = currentPosition;
    }

    private void OnPlayerDie()
    {
        bestScore.Load();
        if (currentScore > bestScore.Score)
            bestScore.Score = currentScore;

        scoreMassege.text = "Your Score: " + currentScore.ToString();

        bestScoreMassege.text = "Best Score: " + bestScore.Score.ToString();
        bestScore.Save();   
    }
    private void OnDisable()
    {
        SaveLoadDataService.SaveDataEvent -= bestScore.Save;
        SaveLoadDataService.LoadDataEvent -= bestScore.Load;
        PlayerManager.PlayerDieAction -= OnPlayerDie;
    }
}
