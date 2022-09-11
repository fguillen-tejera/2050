using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargajo : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    private bool istriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            if (istriggered == false)
            {

                istriggered = true;
                player.TakeDamage(1);
            }
        }
        Destroy(gameObject);
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        istriggered = false;
    }

}
