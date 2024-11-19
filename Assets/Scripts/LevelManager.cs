using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1;
    public Text levelText;
    private int score = 0;
    public Diem diemScript;

    void Start()
    {
        UpdateLevelUI();
    }

    void Update()
    {
        UpdateLevel();
    }

    void UpdateLevel()
    {
        if (score >= 1 && score < 9)
        {
            currentLevel = 1;
        }
        else if (score >= 9 && score < 18)
        {
            currentLevel = 2;
        }
        else if (score >= 18)
        {
            currentLevel = 3; // Tiếp tục thêm các cấp độ khác nhau
        }

        UpdateLevelUI();
    }

    void UpdateLevelUI()
    {
        levelText.text = "Level: " + currentLevel;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateLevel();
        diemScript.UpdateScore(score);
    }

    public void ResetScore()
    {
        score = 0;
        currentLevel = 1;
        UpdateLevelUI();
    }
}



