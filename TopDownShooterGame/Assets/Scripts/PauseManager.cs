using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private static PauseManager _singleton;

    public static PauseManager Singleton
    {
        get => _singleton;

        set
        {
            if (_singleton == null)
            {
                _singleton = value;
            }
            else
            {
                Debug.LogWarning($"{nameof(PauseManager)} Instance already exists, destroying duplicate");
                Destroy(value);
            }
        }
    }

    public bool IsPaused { get; private set; }

    private void Awake()
    {
        IsPaused = false;
        Singleton = this;
    }

    private void Start()
    {
        SceneManager.sceneUnloaded += OnSceneUnload;
    }

    private void OnSceneUnload(UnityEngine.SceneManagement.Scene current)
    {
        if (IsPaused)
        {
            ToggleGamePause();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !IsPaused)
        {
            ToggleGamePause();
            UIManager.Singleton.ShowPauseMenu();
        }
    }

    public void ToggleGamePause()
    {
        if (!IsPaused)
        {
            Time.timeScale = 0.0f;
            AudioListener.pause = true;
        }else
        {
            Time.timeScale = 1.0f;
            AudioListener.pause = false;
        }

        IsPaused = !IsPaused;
    }
}
