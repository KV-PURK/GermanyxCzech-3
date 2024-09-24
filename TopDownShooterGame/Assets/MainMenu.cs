using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Diese Methode wird aufgerufen, wenn der Start-Button gedrückt wird
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);  // Name der Szene, die geladen werden soll
    }
}