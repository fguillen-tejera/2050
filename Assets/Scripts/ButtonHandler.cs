using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonHandler : MonoBehaviour
{

    public void LoadNextScene(GameObject video)
    {

        video.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
}
