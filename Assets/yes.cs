using Gameframe.Giphy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class yes : MonoBehaviour
{
    public string apiKey;
    public string searchKeywords;
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        ShowRandomImage();  
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying == false)
        {
            ShowRandomImage();
        }

    }

    public async void ShowRandomImage()
    {
        //Get a single random result
        var randomResult = await GiphyQuery.Random(apiKey, searchKeywords);

        //Display the random image result using Unity's video player
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = randomResult.Data.Images.OriginalMp4.Mp4;
        videoPlayer.Play();
        
    }
}


