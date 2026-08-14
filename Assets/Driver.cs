using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.05f;
    [SerializeField] float steerSpeed = 1.5f;

    // Update is called once per frame
    void Update()
    {
        float steer;
        float move;
        
        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
            MoveCarForward(move);
            Debug.Log("W key is pressed");
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = 1f;
            MoveCarBackward(move);
            Debug.Log("S key is pressed");
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
            SteerLeft(steer);
            Debug.Log("A key is pressed");
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = 1f;
            SteerRight(steer);
            Debug.Log("D key is pressed");
        }
    }
    void MoveCarForward(float move)
    {

        transform.Translate(0, move*moveSpeed, 0);
    }
        
    void MoveCarBackward(float move)
    {
        transform.Translate(0, move*-moveSpeed, 0);
    }

    void SteerLeft(float steer)
    {
        transform.Rotate(0, 0, steer*steerSpeed);
    }

    void SteerRight(float steer)
    {
        transform.Rotate(0, 0, steer*-steerSpeed);
    }
}
