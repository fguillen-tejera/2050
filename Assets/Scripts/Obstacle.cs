using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public Transform playerSpawn;
    // Start is called before the first frame update
    // Update is called once per frame

    private bool istriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {

        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            if (istriggered == false)
            {

                istriggered = true;
                player.TakeDamage(1);
                if (player.health > 0)
                {
                    Transform playerTransform = other.GetComponent<Transform>();
                    playerTransform.position = playerSpawn.position;
                }
            }

        }

    }

    void OnTriggerExit2D(Collider2D coll)
    {
        istriggered = false;
    }
}
