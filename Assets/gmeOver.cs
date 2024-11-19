using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gmeOver : MonoBehaviour
{
    private Diem diemScript;
    private tym tymScript;
    private Move moveScript;

    void Start()
    {
        GameObject diemObject = GameObject.FindGameObjectWithTag("ScoreManager");
        if (diemObject != null)
        {
            diemScript = diemObject.GetComponent<Diem>();
            if (diemScript == null)
            {
                Debug.LogError("The object with tag 'ScoreManager' does not have a Diem component.");
            }
        }
        else
        {
            Debug.LogError("No GameObject with tag 'ScoreManager' found in the scene.");
        }

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            tymScript = playerObject.GetComponent<tym>();
            if (tymScript == null)
            {
                Debug.LogError("The object with tag 'Player' does not have a tym component.");
            }

            moveScript = playerObject.GetComponent<Move>();
            if (moveScript == null)
            {
                Debug.LogError("The object with tag 'Player' does not have a Move component.");
            }
        }
        else
        {
            Debug.LogError("No GameObject with tag 'Player' found in the scene.");
        }
    }

    public void Restart()
    {
        Debug.Log("Restarting game...");
        if (diemScript != null)
        {
            Debug.Log("Resetting score...");
            diemScript.ResetScore();
        }
        else
        {
            Debug.LogError("diemScript is not assigned.");
        }

        if (tymScript != null)
        {
            Debug.Log("Resetting lives...");
            tymScript.ResetLives();
        }
        else
        {
            Debug.LogError("tymScript is not assigned.");
        }

        if (moveScript != null)
        {
            Debug.Log("Resetting movement...");
            moveScript.ResetMovement();
        }
        else
        {
            Debug.LogError("moveScript is not assigned.");
        }

        Time.timeScale = 1; // Khôi phục thời gian khi khởi động lại trò chơi
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1; // Khôi phục thời gian khi trở về menu chính
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0; // Dừng thời gian khi hiển thị Game Over
    }
}











