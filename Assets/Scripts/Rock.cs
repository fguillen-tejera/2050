using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    public GameObject roca;
    private void OnTriggerEnter2D(Collider2D other)
    {

        roca.SetActive(false);
    }


}