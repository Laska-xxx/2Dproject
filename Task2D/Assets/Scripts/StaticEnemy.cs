using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float Speed; 
    Transform player; 
    bool Chasing = false; 
    BoxCollider2D coll;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        coll = GetComponent<BoxCollider2D>();
        coll.size = new Vector2(coll.size.x + radius, coll.size.y + radius);
    }

    void Update()
    {
        if (Chasing) ChasePlayer();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) Chasing = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) Chasing = false;
    }

    void ChasePlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * Speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (collision.collider.CompareTag("PlayerBullet")) Destroy(gameObject);
    }
}
