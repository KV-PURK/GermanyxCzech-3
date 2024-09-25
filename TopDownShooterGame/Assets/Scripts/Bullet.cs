using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject destroyEffect;
    public float speed = 5.0f;
    public int damage = 15;
    public float maxBounces = 2;

    private Rigidbody2D rb;
    private int bounces;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 forward = transform.up;
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(damage);
            DestroyBullet();
        }

        if (bounces < maxBounces)
        {
            Vector2 movementVector = transform.up;
            Vector2 surfaceNormal = collision.contacts[0].normal;
            Vector2 bounceVector = Vector2.Reflect(movementVector, surfaceNormal);

            float angle = Mathf.Atan2(bounceVector.y, bounceVector.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle - 90.0f);

            bounces++;
        }else
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        if (destroyEffect != null)
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
