using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public Text team1NameText;
    public Text team1ScoreText;
    public Text team2NameText;
    public Text team2ScoreText;

    void Start()
    {
        // Her iki takýmýn adý ve skorunu GameManager’dan al
        team1NameText.text = GameManager.Instance.team1Name;
        team1ScoreText.text = GameManager.Instance.team1Score.ToString();

        team2NameText.text = GameManager.Instance.team2Name;
        team2ScoreText.text = GameManager.Instance.team2Score.ToString();
    }

    // ---------------- TUR DEÐÝÞÝMÝ ----------------
    public void OnContinue()
    {
        if (GameManager.Instance.currentTeam == 1)
        {
            // Team1 turu bitti, Team2 baþlayacak
            GameManager.Instance.NextTeam();
            SceneManager.LoadScene("Game");
        }
        else
        {
            GameManager.Instance.NextTeam();
            SceneManager.LoadScene("Game");
        }
    }

    // ---------------- OYUNU BÝTÝR ----------------
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
