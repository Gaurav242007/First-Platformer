using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    public int health = 10;
    
    void OnTriggerEnter2D(Collider2D other)
{
    // healthpack must have a collider in order to run this function
    if (other.CompareTag("player"))
    {
        Player playerScript = other.GetComponent<Player>();
        playerScript.TakeHealth(health);
        Destroy(gameObject);
    }
}
}
