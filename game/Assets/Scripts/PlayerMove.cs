using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerController _player;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (IsGameStoped.IsGameCountined && _player.IsAlive)
            Move();
    }

    private void Move()
    {
        Vector3 movementDirection = new Vector3(_player.roll, _player.pitch, _player.forwardSpeed) * _player.movementSpeed * Time.deltaTime;

        _characterController.Move(movementDirection);
    }

}
