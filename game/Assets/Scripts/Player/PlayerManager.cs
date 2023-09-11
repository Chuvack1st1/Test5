
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    private PlayerController playerController;

    private PlayerStats playerStats;

    [SerializeField] private ParticleSystem deathParticle;

    public static UnityAction PlayerDieAction;

    private void OnEnable()
    {
        FlyUI.StartFlyProcessEvent += LetPlayerMove;

        FlyUI.EndFlyProcessEvent += ProhibitPlayerMove;

        PlayerDieAction += OnPlayerDeath;
    }
    private void OnPlayerDeath()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        
        deathParticle.Play();
        playerController.IsAlive = false;
        IsGameStoped.IsGameCountined = false;

    }
    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        playerStats = GetComponent<PlayerStats>();
    }
    private void LetPlayerMove()
    {
        
        if(playerController == null)
            playerController = GetComponent<PlayerController>();
        IsGameStoped.IsGameCountined = true;

    }
    private void ProhibitPlayerMove()
    {
        IsGameStoped.IsGameCountined = false;

    }
    private void OnDisable()
    {
        FlyUI.StartFlyProcessEvent -= LetPlayerMove;

        FlyUI.EndFlyProcessEvent -= ProhibitPlayerMove;

        PlayerDieAction -= OnPlayerDeath;
    }
}
