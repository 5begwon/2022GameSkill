using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : Singleton<SceneChangeManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public string SceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void SceneChange(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
