
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    public  int MAXBOSSHP = 10;

    public int Price = 100;

    public List<ParticleSystem> deathParticals = new();

    private int bossHealth;

    private PlayerController player;

    private CharacterController characterController;

    public static UnityAction<Boss> OnBossDeath;

    public static UnityAction<Boss> OnBossHealthChanged;

    public int BossHealth { get => bossHealth;
        set 
        { 
            if(value <= 0)
            {
                bossHealth = 0;
                OnBossHealthChanged.Invoke(this);
                OnBossDeath?.Invoke(this);
                Destroy(gameObject, deathParticals[0].main.duration);
            }
            else
            {
                if(value != MAXBOSSHP)
                    deathParticals[Random.Range(0, deathParticals.Count - 1)].Play();
                bossHealth = value;
                OnBossHealthChanged.Invoke(this);
            }
        } 
    }

    private void OnEnable()
    {
        OnBossDeath += PlayDeathParticels;
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        characterController = GetComponent<CharacterController>();

        BossHealth = MAXBOSSHP;
    }

    private void Update()
    {
        if(player!=null)
            if(transform.position.z - player.transform.position.z < 20)
            {
                characterController.Move(Vector3.forward * player.forwardSpeed * player.movementSpeed * Time.deltaTime);
            }
        //characterController.Move(Vector3.forward * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();
        if(bullet != null)
        {
            BossHealth--;

            Destroy(bullet.gameObject);
        }
    }

    
    private void PlayDeathParticels(Boss boss)
    {
        boss.transform.GetChild(0).gameObject.SetActive(false);
        for (int i = 0; i < boss.deathParticals.Count; i++)
        {
            boss.deathParticals[i].Play();
        }
    }
    private void OnDestroy()
    {
        OnBossDeath -= PlayDeathParticels;
    }
}
