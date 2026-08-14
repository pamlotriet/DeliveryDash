using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float steerSpeed = 200f;

    // Update is called once per frame
    void Update()
    {
      float steer;
      float move;
      float moveAmount;
      float steerAmount;

    

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
            moveAmount = move * moveSpeed * Time.deltaTime;
            MoveCarForward(moveAmount);
            Debug.Log("W key is pressed");
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = 1f;
            moveAmount = move * moveSpeed * Time.deltaTime;
            MoveCarBackward(moveAmount);
            Debug.Log("S key is pressed");
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
            steerAmount = steer * steerSpeed * Time.deltaTime;
            SteerLeft(steerAmount);
            Debug.Log("A key is pressed");
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = 1f;
            steerAmount = steer * steerSpeed * Time.deltaTime;
            SteerRight(steerAmount);
            Debug.Log("D key is pressed");
        }
    }
    void MoveCarForward(float moveAmount)
    {

        transform.Translate(0, moveAmount, 0);
    }
        
    void MoveCarBackward(float moveAmount)
    {
        transform.Translate(0, -moveAmount, 0);
    }

    void SteerLeft(float steerAmount)
    {
        transform.Rotate(0, 0, steerAmount);
    }

    void SteerRight(float steerAmount)
    {
        transform.Rotate(0, 0, -steerAmount);
    }
}
