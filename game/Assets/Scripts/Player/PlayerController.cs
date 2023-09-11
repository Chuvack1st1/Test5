using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float rotationSpeed = 10f;
    public float movementSpeed = 10f;

    public float roll;
    public float pitch;

    public bool IsAlive = true;

    [SerializeField] private FixedJoystick joystick;

    private void Update()
    {   if (IsGameStoped.IsGameCountined && IsAlive)
            HandleInput();
    }
    private void HandleInput()
    {
        roll = joystick.Horizontal;
        pitch = joystick.Vertical;

        if (transform.position.x > 4)
            roll = Mathf.Clamp(roll, -1, 0);
        else if (transform.position.x < -4)
            roll = Mathf.Clamp(roll, 0, 1);

        if (transform.position.y > 8.9)
            pitch = Mathf.Clamp(pitch, 0, 1);
        else if (transform.position.y < 1.1) 
            pitch = Mathf.Clamp(pitch, -1, 0);

        pitch *= -1;
    }
}