using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    [SerializeField] private PlayerController _player;

    private void Update()
    {
        if (IsGameStoped.IsGameCountined && _player.IsAlive)
            Rotate();
    }

    private void Rotate()
    {
        Vector3 rotationDirection = -new Vector3(_player.pitch, 0f, _player.roll) * _player.rotationSpeed;
        Quaternion quaternion = Quaternion.Euler(rotationDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, 0.1f);
    }
}
