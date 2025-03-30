using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartMovie : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    [SerializeField] private GameObject QRpanel;
    [SerializeField] private GameObject QRCode1;
    [SerializeField] private GameObject QRCode2;

    private bool isVideoPrepared = false;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += OnVideoPrepared;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isVideoPrepared)
        {
            QRCode1.SetActive(false);
            QRCode2.SetActive(false);
            QRpanel.SetActive(false);

            videoPlayer.Play();
        }
    }

    private void OnVideoPrepared(VideoPlayer vp)
    {
        isVideoPrepared = true;
    }
}
