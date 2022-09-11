using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject deathEffect;
    Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health == 2)
        {
            Destroy(heart3);
        }
        else if (health == 1)
        {
            Destroy(heart2);
        }
        else
        {
            Destroy(heart1);
        }
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }



    IEnumerator Die()
    {

        myAnimator.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.1f);
        myAnimator.SetBool("IsDead", false);
        yield return new WaitForSeconds(3.6f);
        Destroy(gameObject);
        SceneManager.LoadScene("Level 1");

    }
}
