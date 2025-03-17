using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SimpleShootingEnemy : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPoint;
    [SerializeField] float reload;
    private float time;

    void Update()
    {
        time += Time.deltaTime;
        if (time >= reload)
        {
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            time = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (collision.collider.CompareTag("PlayerBullet")) Destroy(gameObject);
    }
}