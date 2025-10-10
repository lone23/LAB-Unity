using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class GameMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leaderboardText;

    void Start()
    {
        MostraLeaderboard();
    }

    public void startGame()
    {
        SceneManager.LoadScene("BasicScene");
    }

    private void MostraLeaderboard()
    {
        if (!PlayerPrefs.HasKey("Leaderboard"))
        {
            leaderboardText.text = "Nessun punteggio registrato.";
            return;
        }

        string json = PlayerPrefs.GetString("Leaderboard");
        var wrapper = JsonUtility.FromJson<Wrapper<ScoreEntry>>(json);

        List<ScoreEntry> sorted = wrapper.list
            .OrderByDescending(entry => entry.score)
            .Take(5) // prendo 5
            .ToList();

        leaderboardText.text = "LEADERBOARD\n";
        int rank = 1;
        foreach (var entry in sorted)
        {
            leaderboardText.text += $"{rank}. ID: {entry.id.Substring(0, 6)} -> Score: {entry.score}\n";
            rank++;
        }
    }


    [System.Serializable]
    private class Wrapper<T>
    {
        public List<T> list;
    }

    [System.Serializable]
    private class ScoreEntry
    {
        public string id;
        public int score;
    }
}