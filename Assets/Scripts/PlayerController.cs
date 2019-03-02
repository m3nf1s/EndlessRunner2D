using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isGround;
    public LayerMask Grounds;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Collider2D characterCollider;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();

        characterCollider = GetComponent<Collider2D>();

        sr.color = Random.Range(0, 2) == 0 ? Color.red : Color.blue;
    }

    void Update()
    {
        isGround = Physics2D.IsTouchingLayers(characterCollider, Grounds);

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGround)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        if (!isGround)
        {
            if (Input.GetButtonDown("Jump"))
                sr.color = sr.color == Color.red ? Color.blue : Color.red;
        }
    }
}