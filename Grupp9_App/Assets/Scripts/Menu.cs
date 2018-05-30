using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void disable()
    {
        Destroy(this.transform.parent.gameObject);
    }
    public void restart()
    {
        SceneManager.LoadScene(1);
    }
}
