using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string team1Name;
    public string team2Name;
    public int team1Score;
    public int team2Score;
    public int gameTime;
    public string category;

    [HideInInspector]
    public int currentTeam = 1; // 1 veya 2

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SetDefaultTeamNames(); // boþsa isimleri ayarla
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDefaultTeamNames()
    {
        if (string.IsNullOrEmpty(team1Name))
            team1Name = "takým1";

        if (string.IsNullOrEmpty(team2Name))
            team2Name = "takým 2";
    }

    // Skor ekleme fonksiyonu
    public void AddScore(int points)
    {
        if (currentTeam == 1)
            team1Score += points;
        else
            team2Score += points;
    }

    // Takým deðiþtir
    public void NextTeam()
    {
        currentTeam = (currentTeam == 1) ? 2 : 1;
    }

    public string GetCurrentTeamName()
    {
        return (currentTeam == 1) ? team1Name : team2Name;
    }

    public int GetCurrentTeamScore()
    {
        return (currentTeam == 1) ? team1Score : team2Score;
    }
}
