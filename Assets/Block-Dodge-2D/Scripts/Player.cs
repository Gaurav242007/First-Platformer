using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15f;
    public float mapWidth = 5f;
    public Rigidbody2D rb;
    public Joystick joystick;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float x;
        // Getting input from virtual joystick
        if (joystick.Horizontal >= .2f)
        {
            x = Time.fixedDeltaTime * speed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            x = Time.fixedDeltaTime * -speed;
        }
        else
        {
        x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        }
        Vector2 newPosition = rb.position + Vector2.right * x;
        // Clamping the current value so that player can move within the map from -5 to +5
        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        rb.MovePosition(newPosition);
    }

    void OnCollisionEnter2D()
    {
        FindObjectOfType<GameManager>().EndGame();
    }
}
