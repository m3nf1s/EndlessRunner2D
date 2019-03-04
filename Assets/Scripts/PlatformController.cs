using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class PlatformController : MonoBehaviour
{
    private SpriteRenderer sr; // Переменная для доступа к графическим составляющим GameObject'а

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();

        sr.color = Random.Range(0,2) == 0 ? Color.red : Color.blue;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SpriteRenderer>().color == sr.color)
            GameManager.instance.AddScore();
        else
            GameManager.instance.GameOver();
    }
}
