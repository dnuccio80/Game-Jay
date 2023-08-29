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


    public static void Load(Scene targetScene)
    {
        LoaderScript.targetScene = targetScene;

        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }


    public static void LoaderCallback()
    { 
            SceneManager.LoadScene(Scene.DatesScene.ToString() , LoadSceneMode.Single);
            SceneManager.LoadSceneAsync(targetScene.ToString(), LoadSceneMode.Additive);

    }

}
