using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int damage;
    [SerializeField] GameObject particles;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerBullet") || collision.collider.CompareTag("EnemyBullet"))
        {
            health -= damage;
        }
        if(health <= 0)
        {
            Vector3 particlePosition = transform.position;
            particlePosition.z -= 0.5f;
            Instantiate(particles, particlePosition , Quaternion.Euler(180f, 0f, 0f));
            Destroy(gameObject);
        }
    }
}
