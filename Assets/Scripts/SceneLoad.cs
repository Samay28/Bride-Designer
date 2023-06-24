using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public string sceneName; // Name of the scene you want to load
    public string TutorialScene;
    private AsyncOperation loadingOperation;
    public MainMenuManager mm;
    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        if (!mm.FirstTimeLoaded())
        {
            // Load the scene asynchronously
            loadingOperation = SceneManager.LoadSceneAsync(sceneName);

            // Don't activate the scene immediately
            loadingOperation.allowSceneActivation = false;
            Debug.Log("1");
        }
        else
        {
            loadingOperation = SceneManager.LoadSceneAsync(TutorialScene);

            Debug.Log("2");
            loadingOperation.allowSceneActivation = false;
        }

        yield return null;
    }
}
