using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    private const float MOVE_SPEED = 150.0f;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    public GameObject Head;
    private SpriteRenderer head;
    public GameObject Eyes;
    private SpriteRenderer eyes;
    public GameObject Body;
    private SpriteRenderer body;
    public GameObject Shadow;
    private SpriteRenderer shadow;
    private BoxCollider2D col;

    private void Awake()
    {
        head = Head.GetComponent<SpriteRenderer>();
        eyes = Eyes.GetComponent<SpriteRenderer>();
        body = Body.GetComponent<SpriteRenderer>();
        shadow = Shadow.GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMovement(InputValue value)
    {
        moveDir = value.Get<Vector2>().normalized;
    }



    void Update()
    {
        if (moveDir.x < 0)
        {
            head.flipX = false;
            eyes.flipX = false;
            body.flipX = false;
            shadow.flipX = false;
        }
        else if (moveDir.x > 0)
        {
            head.flipX = true;
            eyes.flipX = true;
            body.flipX = true;
            shadow.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveDir * MOVE_SPEED * Time.deltaTime;
    }
}
