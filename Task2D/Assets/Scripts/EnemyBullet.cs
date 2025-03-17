using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float lifetime;
    [SerializeField] float speed;

    void Start()
    {
        Destroy(gameObject, lifetime);
        Invoke("OnColl", 0.2f);
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnColl()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Destroy(gameObject);
    }
}
