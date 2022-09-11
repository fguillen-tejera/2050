using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform rockSpawn;
    public GameObject gargajo;
    public GameObject gargajo2;

    public GameObject barrier;

    public GameObject roca;


    public GameObject hitBox;

    Animator moscaAnimator;
    private void Start()
    {
        moscaAnimator = GetComponent<Animator>();
        StartCoroutine(Shoot());
    }
    void Update()
    {

    }

    IEnumerator Shoot()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(6.3f);
            moscaAnimator.SetBool("IsDamage", false);
            if (i != 0)
            {
                yield return new WaitForSeconds(0.8f);
            }
            spawnBullet();
            yield return new WaitForSeconds(1.7f);
            spawnBullet();
            yield return new WaitForSeconds(1.7f);
            spawnBullet();
            yield return new WaitForSeconds(3.6f);


            yield return new WaitForSeconds(6.3f);
            if (i < 3)
            {
                moscaAnimator.SetBool("IsDamage", true);
            }
            else
            {
                moscaAnimator.SetBool("IsDeath", true);
            }
            spawnBullet();
            yield return new WaitForSeconds(1.7f);
            spawnBullet();
            yield return new WaitForSeconds(1.7f);
            spawnBullet();
            yield return new WaitForSeconds(0.6f);
            if (i < 3)
            {
                Instantiate(roca, new Vector2(rockSpawn.position.x, rockSpawn.position.y), rockSpawn.rotation);
            }
            else
            {

                yield return new WaitForSeconds(10f);
                GetComponent<AudioSource>().Pause();
                barrier.SetActive(false);
                hitBox.GetComponent<PolygonCollider2D>().isTrigger = true;

            }
            yield return new WaitForSeconds(1.6f);

        }
        //3 more times


    }

    private void spawnBullet()
    {
        int num = Random.Range(1, 4);
        float addFactor = num == 1 ? 0 : num == 2 ? 0.3f : -0.6f;
        int spriteNum = Random.Range(1, 3);
        Instantiate(spriteNum == 1 ? gargajo : gargajo2, new Vector2(firePoint.position.x, firePoint.position.y + addFactor), firePoint.rotation);
    }
}


