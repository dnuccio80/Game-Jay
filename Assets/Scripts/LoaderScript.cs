using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoaderScript 
{

    public enum Scene
    {
        MainMenuScene,
        DatesScene,
        Level1Game,
        LoadingScene,
        Training
    }


    private static Scene targetScene;
    private static bool hasAdditiveScene;
    private static bool wantToPlayTraining;

    public static void Load(Scene targetScene, bool _hasAdditiveScene)
    {
        LoaderScript.targetScene = targetScene;
        hasAdditiveScene = _hasAdditiveScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }


    public static void LoaderCallback()
    {
        (hasAdditiveScene ? (Action)LoadGamingScene : LoadSingleScene)();
    }

    private static void LoadGamingScene()
    {
        SceneManager.LoadScene(Scene.DatesScene.ToString());
        SceneManager.LoadScene(targetScene.ToString(), LoadSceneMode.Additive);
    }

    private static void LoadSingleScene()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }

    public static void ChangeTrainingPlayStatus(bool _newTrainingStatus)
    {
        wantToPlayTraining = _newTrainingStatus;
    }

    public static bool GetIfWantToPlayTraining()
    {
        return wantToPlayTraining;
    }

}
