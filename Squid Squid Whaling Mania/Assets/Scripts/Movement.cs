using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 target;
    private bool shouldMove = false;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) // Hold Left-click to move
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target = new Vector2(mousePos.x, transform.position.y); // Only move left/right
            shouldMove = true;
        }

        if (Input.GetMouseButtonUp(1)) // Stop moving when letting go of click
        {
            shouldMove = false;
        }

        if (shouldMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) // Prevents Players From Phasing Through
        {
            speed = -0.2f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) // Prevents Players From Phasing Through
        {
            speed = 5f;
        }
    }
}