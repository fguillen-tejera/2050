using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    bool shouldLoad = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (shouldLoad)
        {
            SceneManager.LoadScene("Level 3");
            shouldLoad = false;

        }

    }
}
