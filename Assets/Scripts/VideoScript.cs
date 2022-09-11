using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoScript : MonoBehaviour
{
    BoxCollider2D myBoxCollider;
    UnityEngine.Video.VideoPlayer myVideoPlayer;

    [SerializeField] GameObject videoCanvas;
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
        myVideoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoCanvas.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        videoCanvas.SetActive(true);
        myVideoPlayer.Play();
    }
}
