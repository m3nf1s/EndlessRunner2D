using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Platform : MonoBehaviour
{
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();

        sr.color = Random.Range(0,2) == 0 ? Color.red : Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.GetComponent<SpriteRenderer>().color != sr.color)
        //    Destroy(other.gameObject);
    }
}
