using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  _____           _      _   _     _           _     _ _   
// |  ___|   _  ___| | __ | |_| |__ (_)___   ___| |__ (_) |_ 
// | |_ | | | |/ __| |/ / | __| '_ \| / __| / __| '_ \| | __|
// |  _|| |_| | (__|   <  | |_| | | | \__ \ \__ \ | | | | |_ 
// |_|   \__,_|\___|_|\_\  \__|_| |_|_|___/ |___/_| |_|_|\__|

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
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
        Vector2 movementDirection = inputDirection * PlayerStats.Singleton.movementSpeed;
        rb.MovePosition(rb.position + movementDirection * Time.fixedDeltaTime);
    }
}
