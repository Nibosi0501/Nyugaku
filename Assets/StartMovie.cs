using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartMovie : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    [SerializeField] private GameObject display1Background;
    [SerializeField] private GameObject display2Background;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += OnVideoPrepared;

    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        display1Background.SetActive(false);
        display2Background.SetActive(false);
        videoPlayer.Play();
    }
}
