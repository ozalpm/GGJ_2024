using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class menu : MonoBehaviour
{
    public void PlayGame()
    {
        // Oyun sahnesini y�kle
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        // Uygulamadan ��k
        Application.Quit();
    }
}
