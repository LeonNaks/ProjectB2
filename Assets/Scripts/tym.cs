using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tym : MonoBehaviour
{
    public int Mang = 3; // Đảm bảo rằng giá trị khởi tạo là 3
    private GameObject[] listHealth;
    public Text StatusGame;

    void Start()
    {
        listHealth = GameObject.FindGameObjectsWithTag("health");
        Mang = 3; // Đặt lại giá trị khi khởi động lại
        UpdateHealthUI(); // Cập nhật hiển thị mạng khi bắt đầu
        Debug.Log("Initial Mang: " + Mang); // Log để kiểm tra giá trị ban đầu của Mang
    }

    void Update()
    {
        if (Mang <= 0)
        {
            StatusGame.text = "GAMEOVER";
            StatusGame.gameObject.SetActive(true);
            StatusGame.color = Color.black;
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flower")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Mang--;
            UpdateHealthUI();
            Debug.Log("Basket hit Enemy. Lives remaining: " + Mang);
            Destroy(collision.gameObject); // Hủy kẻ thù khi va chạm với giỏ
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeathZone")
        {
            Mang--;
            UpdateHealthUI();
            Debug.Log("Flower hit DeathZone. Lives remaining: " + Mang);
        }
    }

    private void UpdateHealthUI()
    {
        for (int i = 0; i < listHealth.Length; i++)
        {
            listHealth[i].SetActive(i < Mang);
        }
    }

    public void ResetLives()
    {
        Mang = 3; // Đặt lại giá trị khi khởi động lại
        UpdateHealthUI(); // Cập nhật hiển thị mạng khi khởi động lại
        StatusGame.gameObject.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Lives reset and game resumed");
    }
}








