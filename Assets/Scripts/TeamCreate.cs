using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamCreate : MonoBehaviour
{
    public InputField team1Input;
    public InputField team2Input;
    public Dropdown timeDropdown; // Süre seçimi için Dropdown
    public Dropdown categoryDropdown;

    void Start()
    {
        // Varsayýlan süreyi GameManager'a ata
        GameManager.Instance.gameTime = int.Parse(timeDropdown.options[timeDropdown.value].text);
        GameManager.Instance.category = categoryDropdown.options[categoryDropdown.value].text;

        // Dropdown deðiþtiðinde callback ekle
        timeDropdown.onValueChanged.AddListener(delegate { OnTimeChanged(); });
        categoryDropdown.onValueChanged.AddListener(delegate { OnCategoryChanged(); });
    }

    // Dropdown deðiþtiðinde çaðrýlýr
    void OnTimeChanged()
    {
        GameManager.Instance.gameTime = int.Parse(timeDropdown.options[timeDropdown.value].text);
    }
    void OnCategoryChanged()
    {
        GameManager.Instance.category =  categoryDropdown.options[categoryDropdown.value].text;
    }

    public void OnStartGame()
    {
        // Eðer InputField boþsa varsayýlan isimleri kullan
        GameManager.Instance.team1Name = string.IsNullOrEmpty(team1Input.text)? "Takým 1": team1Input.text;

        GameManager.Instance.team2Name = string.IsNullOrEmpty(team2Input.text)? "Takým 2": team2Input.text;

        // Skorlarý sýfýrla
        GameManager.Instance.team1Score = 0;
        GameManager.Instance.team2Score = 0;

        // Turu baþa al
        GameManager.Instance.currentTeam = 1;

        // Game sahnesine geç
        SceneManager.LoadScene("Game");
    }

}
