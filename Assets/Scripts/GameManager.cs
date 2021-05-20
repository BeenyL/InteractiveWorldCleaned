using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    [SerializeField] Image blackScreen;
    private void Awake()
    {
        #region Singleton

        if(gm == null)
        {
            DontDestroyOnLoad(gameObject);
            gm = this;
        }
        else if (gm != null)
        {
            Destroy(gameObject);
        }
        #endregion
    }

    void Update()
    {
        
    }

    public void LoadScene(string scene)
    {
        StartCoroutine(LoadSceneCoroutine(scene));
    }

    public void loadScene(Rooms scene)
    {
        switch (scene)
        {
            case Rooms.Main:
                LoadScene("Main");
                break;
            case Rooms.MainDusk:
                LoadScene("MainDusk");
                break;
            case Rooms.Room1:
                LoadScene("Room1");
                break;


        }


    }

    private IEnumerator LoadSceneCoroutine(string scene)
    {
        // Fade to black
        blackScreen.raycastTarget = true;
        float fraction;
        for (float i = 0f; i <= 0.9f; i += Time.unscaledDeltaTime)
        {
            fraction = i / 0.9f;
            blackScreen.color = new Color32(0, 0, 0, (byte)(255 * fraction));
            yield return null;
        }
        blackScreen.color = new Color32(0, 0, 0, 255);
        yield return new WaitForSecondsRealtime(0.1f);

        // Set variables
        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Load scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        while (!asyncLoad.isDone)
            yield return null;
        yield return null;

        // Fade out
        for (float i = 0f; i <= 0.6f; i += Time.unscaledDeltaTime)
        {
            fraction = 1 - (i / 0.6f);
            blackScreen.color = new Color32(0, 0, 0, (byte)(255 * fraction));
            yield return null;
        }
        blackScreen.raycastTarget = false;
        blackScreen.color = new Color32(0, 0, 0, 0);
    }

}
