using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Script_youLose : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += VideoOver;
    }

    void VideoOver(VideoPlayer vp)
    {
        SceneManager.LoadScene("Scene_main");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
