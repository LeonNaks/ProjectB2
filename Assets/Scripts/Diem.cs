using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Diem : MonoBehaviour
{
    public Text ScoreText;
    public GameObject flowerPrefab;
    private int Score = 0;
    private AudioManager audioManager;
    private float spawnInterval = 15; // Khoảng thời gian giữa các lần sinh hoa
    private float minSpawnY = 10; // Vị trí Y tối thiểu để tránh va chạm ngay lập tức
    private float maxSpawnY = 20; // Vị trí Y tối đa
    public LevelManager levelManager;

    void Start()
    {
        GameObject audioObject = GameObject.FindGameObjectWithTag("Audio");
        if (audioObject != null)
        {
            audioManager = audioObject.GetComponent<AudioManager>();
        }
        else
        {
            Debug.LogError("No GameObject with tag 'Audio' found in the scene.");
        }
        ResetScore();
        StartCoroutine(SpawnFlowers());
        Debug.Log("Initialized Diem script.");
    }

    IEnumerator SpawnFlowers()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnFlower();
        }
    }

    private void SpawnFlower()
    {
        Debug.Log("Attempting to spawn a flower...");
        if (flowerPrefab != null)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(minSpawnY, maxSpawnY), 0.0f);
            GameObject spawnedFlower = Instantiate(flowerPrefab, spawnPosition, Quaternion.identity);
            if (spawnedFlower != null)
            {
                spawnedFlower.tag = "Flower"; // Gán tag "Flower" cho đối tượng hoa
                Debug.Log("Spawned a flower at: " + spawnPosition);
            }
            else
            {
                Debug.LogError("Failed to spawn flower at: " + spawnPosition);
            }
        }
        else
        {
            Debug.LogError("flowerPrefab is not assigned in the Inspector.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flower")
        {
            Score++;
            levelManager.AddScore(1); // Thêm điểm và cập nhật cấp độ
            ScoreText.text = "Hoa hồng: " + Score;
            Destroy(collision.gameObject);
            audioManager.PlaySFX(audioManager.checkpoint);
        }
    }

    public void UpdateScore(int newScore)
    {
        Score = newScore;
        ScoreText.text = "Hoa hồng: " + Score;
    }

    public void ResetScore()
    {
        Score = 0;
        ScoreText.text = "Hoa hồng: " + Score;
        levelManager.ResetScore(); // Đặt lại điểm và cấp độ
        StopAllCoroutines(); // Dừng tất cả coroutine hiện tại
        StartCoroutine(SpawnFlowers()); // Bắt đầu lại coroutine SpawnFlowers
        Debug.Log("Score reset and flowers should respawn.");
    }
}




