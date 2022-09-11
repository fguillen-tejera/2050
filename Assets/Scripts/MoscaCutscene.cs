using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoscaCutscene : MonoBehaviour
{
    public GameObject mosca;
    public GameObject invisibleWall;
    public GameObject video;

    public GameObject canvasVideo;

    public GameObject barrier;

    public GameObject player;

    private AudioSource audio;


    private bool shouldPlay = true;

    private UnityEngine.Video.VideoPlayer videoPlayer;
    private void Start()
    {
        audio = player.GetComponent<AudioSource>();

        videoPlayer = video.GetComponent<UnityEngine.Video.VideoPlayer>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (shouldPlay)
        {
            StartCoroutine(playVideo());
            shouldPlay = false;
        }


    }

    IEnumerator playVideo()
    {
        video.SetActive(true);
        canvasVideo.SetActive(true);
        invisibleWall.SetActive(true);
        barrier.SetActive(true);
        yield return new WaitForSeconds(9f);

        video.SetActive(false);
        canvasVideo.SetActive(false);
        mosca.SetActive(true);
        audio.Play();
    }
}
