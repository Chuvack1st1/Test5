using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float LiveTime;

    public float BulletSpeed = 2f;

    [SerializeField] private ParticleSystem _particleSystem;
    private void Update()
    {
        Move(Vector3.forward, BulletSpeed);
    }    
    public void Move(Vector3 direction, float BulletSpeed)
    {
        Vector3 moveDirection = direction * BulletSpeed * Time.deltaTime;
        transform.localPosition += moveDirection;
    }

    private void OnTriggerEnter(Collider other)
    {
        Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            transform.GetChild(0).gameObject.SetActive(false);

            _particleSystem.Play();

            Destroy(this.gameObject, _particleSystem.main.duration);
        }
    }
}
