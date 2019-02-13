using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

	// Use this for initialization
	VideoPlayer m_VideoPlayer;
	public VideoClip m_clip;

	void Start () {
        m_VideoPlayer = GetComponent<VideoPlayer>();
        m_VideoPlayer.loopPointReached += OnMovieFinished; // loopPointReached is the event for the end of the video
    }

    void OnMovieFinished(VideoPlayer player)
    {
        Debug.Log("Event for movie end called");
        m_VideoPlayer.Stop();
		
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
