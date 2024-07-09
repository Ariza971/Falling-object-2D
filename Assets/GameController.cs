using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Controller playerController; // controller = script buat player

    public Canvas GameOverCanvas;
    public TMP_Text TimerText;

    private void Awake()
    {
        if (playerController == null)
        {
            playerController = FindObjectOfType<Controller>();
        }

        if (playerController != null)
        {
            playerController.PlayerDied += WhenPlayerDies;
        }
        else
        {
            Debug.LogError("PlayerController not found!");
        }

        if (GameOverCanvas.gameObject.activeSelf)
        {
            GameOverCanvas.gameObject.SetActive(false);
        }
    }

    void WhenPlayerDies() // method yang dipanggil saat player mati
    {
        Debug.Log("Player died, showing Game Over screen.");
        GameOverCanvas.gameObject.SetActive(true);
        TimerText.text = "Lasted For : " + System.Math.Round(Time.timeSinceLevelLoad, 2);

        // Unsubscribe from the event
        if (playerController != null)       
        {
            playerController.PlayerDied -= WhenPlayerDies;
        }
    }

    public void NewGame() // tombol restart untuk memulai game baru
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
