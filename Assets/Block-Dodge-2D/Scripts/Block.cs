using System.Collections;
using UnityEngine;

public class Block : MonoBehaviour
{
    void Start () 
    {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 20f;
    }
    void Update () 
    {
        if(transform.position.y < -2f)
        {
            FindObjectOfType<GameManager>().IncreaseScore(0.5f);
            // gameObject refer to current object (is a keyword)
            Destroy(gameObject);
        }
    }
}
