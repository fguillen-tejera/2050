using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneLoader : MonoBehaviour
{

    bool shouldLoad = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (shouldLoad)
        {
            SceneManager.LoadScene("Level 2");
            shouldLoad = false;

        }

    }

}
