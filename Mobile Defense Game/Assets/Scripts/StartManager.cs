﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public void GameStart()
    {
        //ShowRewardedAd();
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void GameExit()
    {
        Application.Quit();
    }

    void Start()
    {
        Screen.SetResolution(1920, 1200, true);
        //Advertisement.Initialize("3087395", false);
    }

    //private void HandleShowResult(ShowResult result)
    //{
    //    switch (result)
    //    {
    //        case ShowResult.Finished:
    //            Debug.Log("사용자가 광고를 성공적으로 보았습니다.");
    //            break;
    //        case ShowResult.Skipped:
    //            Debug.Log("사용자가 광고가 끝나기 전에 스킵했습니다.");
    //            break;
    //        case ShowResult.Failed:
    //            Debug.Log("광고가 보여지는 과정에서 오류가 발생했습니다.");
    //            break;
    //    }
    //}

    //private void ShowRewardedAd()
    //{
    //    if (Advertisement.IsReady("rewardedVideo"))
    //    {
    //        var options = new ShowOptions { resultCallback = HandleShowResult };
    //        Advertisement.Show("rewardedVideo", options);
    //    }
    //}

    void Update()
    {
        
    }
}
