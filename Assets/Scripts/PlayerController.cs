using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class PlayerController : MonoBehaviour
{
    public bool isGround; // находится игрок на земле или нет
    public LayerMask Grounds; // список масок с которым будет происходить проверка на нахождение на земле

    private float moveSpeed = 7.0f; // скорость передвижения
    private float jumpSpeed = 13.0f; // скорость прыжка
    private Rigidbody2D rb2D; // доступ к компоненту RigidBody 2D
    private SpriteRenderer sr; // доступ к визуальному состовляющему GameObject
    private Collider2D characterCollider; // доступ к компоненту Collider2D

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        rb2D = GetComponent<Rigidbody2D>();

        characterCollider = GetComponent<Collider2D>();

        sr.color = Random.Range(0, 2) == 0 ? Color.red : Color.blue;
    }

    void Update()
    {
        if (!GameManager.instance.gameOver)
        {
            PlayerMove();
        }
        else
            rb2D.velocity = Vector2.zero;;
    }

    /// <summary>
    /// Передвижение игрока
    /// </summary>
    void PlayerMove()
    {
        isGround = Physics2D.IsTouchingLayers(characterCollider, Grounds);

        rb2D.velocity = new Vector2(moveSpeed, rb2D.velocity.y);

        if (Input.GetButtonDown("Jump") && isGround)
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);

        if (!isGround)
        {
            if (Input.GetButtonDown("Jump"))
                sr.color = sr.color == Color.red ? Color.blue : Color.red;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "DeathZone")
            GameManager.instance.GameOver();
    }
}