using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    private const float MOVE_SPEED = 15.0f;
    private Rigidbody2D rb;
    private Vector2 moveDir;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMovement(InputValue value)
    {
        moveDir = value.Get<Vector2>().normalized;
    }

    void Update()
    {
        //float moveX = 0.0f;
        //float moveY = 0.0f;

        //if (Input.GetKey(KeyCode.W))
        //{
        //    moveY = 1f;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    moveY = -1f;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    moveX = -1f;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    moveX = 1f;
        //}

        //moveDir = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = moveDir * MOVE_SPEED;
    }
}
