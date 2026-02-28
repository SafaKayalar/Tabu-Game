using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class GameUI : MonoBehaviour
{
    [Header("UI Elements")]
    public Text teamNameText;
    public Text scoreText;
    public Text timerText;
    public Text passButtonText;
    public GameObject pauseMenu;
    public GameObject pauseButton;

    public Button tabuButton;
    public Button passButton;
    public Button correctButton;
    

    [Header("Card System")]
    public Card cardSystem; // Card scriptini inspector'dan ekle

    private float timeLeft;
    private int passCount = 3;
    private bool timerRunning;
    void Start()
    {
        pauseButton.SetActive(true);
        timerRunning = true;
        pauseMenu.SetActive(false);
        StartTurn();
    }

    void StartTurn()
    {
        // Takým adý ve skor
        teamNameText.text = GameManager.Instance.GetCurrentTeamName();
        scoreText.text = GameManager.Instance.GetCurrentTeamScore().ToString();

        // Süreyi baþlat
        timeLeft = GameManager.Instance.gameTime;

        // Pas hakkýný baþlat
        passCount = 3;
        UpdatePassButton();

        // Ýlk kartý göster
        cardSystem.ShowNext();

        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (timeLeft > 0 && timerRunning)
        {
            timerText.text = Mathf.Ceil(timeLeft).ToString();
            yield return new WaitForSeconds(1f);
            timeLeft -= 1f;
        }
        if (timerRunning)
        {
            timerText.text = "0";
            // Süre bitti, Score sahnesine geç
            SceneManager.LoadScene("Score"); 
        }
    }

    // ---------------- BUTTONS ----------------

    public void OnCorrect()
    {
        GameManager.Instance.AddScore(1); // Skoru artýr
        scoreText.text = GameManager.Instance.GetCurrentTeamScore().ToString();
        cardSystem.ShowNext(); // Yeni kart
    }

    public void OnTabu()
    {
        GameManager.Instance.AddScore(-1); // Skoru azalt
        scoreText.text = GameManager.Instance.GetCurrentTeamScore().ToString();
        cardSystem.ShowNext(); // Yeni kart
    }

    public void OnPass()
    {
        if (passCount > 0)
        {
            passCount--;
            UpdatePassButton();
            cardSystem.ShowNext(); // Yeni kart
        }
    }

    void UpdatePassButton()
    {
        passButtonText.text = "Pas (" + passCount + ")";
        passButton.interactable = passCount > 0;
    }

    public void PauseMenu()
    {
        timerRunning = false;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void DevamButton()
    {
        timerRunning = true;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);

        StartCoroutine(Timer()); 
    }



    public void FinishGame()
    {
        // Skorlarý ve takým isimlerini sýfýrla
        GameManager.Instance.team1Score = 0;
        GameManager.Instance.team2Score = 0;
        GameManager.Instance.team1Name = "";
        GameManager.Instance.team2Name = "";
        GameManager.Instance.currentTeam = 1; // isteðe baðlý olarak turu baþa al

        // Teacreate sahnesine geç
        SceneManager.LoadScene("TeamCreate");
    }

}
