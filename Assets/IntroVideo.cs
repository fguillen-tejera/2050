using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroVideo : MonoBehaviour
{
    public GameObject instrucciones;
    void Start()
    {
        StartCoroutine(playVideo());

    }

    // Update is called once per frame
    IEnumerator playVideo()
    {
        yield return new WaitForSeconds(49f);
        instrucciones.SetActive(true);

    }
}
