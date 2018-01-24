using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void ButtonTest()
    {
        Debug.Log("The button works just fine! :-)");
    }

    //public void StartNewGame()
    //{
    //    LoadScene(0);
    //}

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadNextScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
