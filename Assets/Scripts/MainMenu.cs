using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        Debug.Log("Loading Game...");
        Time.timeScale = 1; // Đảm bảo thời gian được đặt lại bình thường
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();
    }
}

