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

    public static void Load(Scene targetScene, bool _hasAdditiveScene)
    {
        LoaderScript.targetScene = targetScene;
        hasAdditiveScene = _hasAdditiveScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }


    public static void LoaderCallback()
    {
        (hasAdditiveScene ? (Action)LoadAdditiveScene : LoadSingleScene)();
    }

    private static void LoadAdditiveScene()
    {
        SceneManager.LoadScene(Scene.DatesScene.ToString(), LoadSceneMode.Single);
        SceneManager.LoadSceneAsync(targetScene.ToString(), LoadSceneMode.Additive);
    }

    private static void LoadSingleScene()
    {
        SceneManager.LoadScene(targetScene.ToString());

    }

}
