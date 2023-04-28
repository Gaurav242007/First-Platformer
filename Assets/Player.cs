using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth;

	public EnemyHealthBar healthBar;
	public GameObject deathEffect;
    public Rigidbody2D rb;
    public float danagerYPosition = -3f;

    public void Update()
    {
        
		if (rb.position.y < danagerYPosition) 
		{
            Die();
		}
    }

    public void Start ()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

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

	public void TakeHealth(int health)
	{
		if(currentHealth >= 90)
		{
			currentHealth = 100;
		}
		else {
			currentHealth += health;
		}
	}

	void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
	}

}
