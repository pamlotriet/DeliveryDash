using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float steerSpeed = 200f;
    float steer;
    float move;
    float moveAmount;
    float steerAmount;
    bool hasBoost = false;
    [SerializeField] float boostMultiplier = 2f;
    [SerializeField] float timeoutSeconds = 3f;
    float currentMoveSpeed;
    Coroutine boostCoroutine;

    void Start()
    {
        currentMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
            moveAmount = move * currentMoveSpeed * Time.deltaTime;
            MoveCarForward(moveAmount);
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = 1f;
            moveAmount = move * currentMoveSpeed * Time.deltaTime;
            MoveCarBackward(moveAmount);
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
            steerAmount = steer * steerSpeed * Time.deltaTime;
            SteerLeft(steerAmount);
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = 1f;
            steerAmount = steer * steerSpeed * Time.deltaTime;
            SteerRight(steerAmount);
        }
    }

    IEnumerator BoostTimeout()
    {
        yield return new WaitForSeconds(timeoutSeconds);

        ResetBoost();
        Debug.Log("Boost timed out");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
            if (hasBoost)
            {
                ResetBoost();
                Debug.Log("Boost lost due to collision");
            }else
            {
                Debug.Log("Collided with obstacle");
            }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boost") && !hasBoost)
        {
            hasBoost = true;
            currentMoveSpeed = moveSpeed * boostMultiplier;
            boostCoroutine = StartCoroutine(BoostTimeout());

            Destroy(collision.gameObject);
            Debug.Log("Boost activated");
        }
    }

    void ResetBoost()
    {
        hasBoost = false;
        currentMoveSpeed = moveSpeed;

        if (boostCoroutine != null)
        {
            StopCoroutine(boostCoroutine);
            boostCoroutine = null;
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
