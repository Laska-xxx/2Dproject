using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPoint;
    [SerializeField] float reload;
    private float time;
    PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        Vector2 direction = (player.transform.position - shootPoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        shootPoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        time += Time.deltaTime;
        if (time >= reload)
        {
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            time = 0f;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (collision.collider.CompareTag("PlayerBullet")) Destroy(gameObject);
    }
}
