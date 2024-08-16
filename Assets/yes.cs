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
        videoPlayer.loopPointReached += EndReached;
    }

    public async void ShowRandomImage()
    {
        var randomResult = await GiphyQuery.Random(apiKey, searchKeywords);
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = randomResult.Data.Images.OriginalMp4.Mp4;
        videoPlayer.Play();
        
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        EndReachFunc();
    }

    IEnumerator EndReachFunc()
    {
        yield return new WaitForSeconds(2);
        ShowRandomImage();
    }
}




