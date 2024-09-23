using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 5.0f;

    private Rigidbody2D rb;

    Vector2 inputDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        Vector2 movementDirection = inputDirection * movementSpeed;
        rb.MovePosition(rb.position + movementDirection * Time.fixedDeltaTime);
    }
}
