using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int maxHealth = 100;
	public int currentHealth;
	
	public EnemyHealthBar healthBar;
	public GameObject deathEffect;
	public GameObject bulletPrefab;
	public Transform firePoint;

    public float timeBetweenShoot = 1f;
    public float timeToShoot = 2f;

	public void Start ()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

	}

	public void Update()
	{
		 // Amount of time passed by since we started the game
        if (Time.time >= timeToShoot)
        {
            Shoot();
            timeToShoot = Time.time + timeBetweenShoot;

        }
	}


	void Shoot ()
	{
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}

	public void TakeDamage (int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		FindObjectOfType<GameManager>().IncreaseScore(20);
		Destroy(gameObject);
	}

}
