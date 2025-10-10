using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[Serializable]
public class ScoreEntry
{
    public string id;
    public int score;
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private string currentId;

    void Start()
    {
        // genero id
        currentId = Guid.NewGuid().ToString();
        score = 0;
        AggiornaUI();
    }

    public void UpdateScore(XRBaseInteractable interactable)
    {
        score++;
        AggiornaUI();
        Destroy(interactable.gameObject);
    }

    private void AggiornaUI()
    {
        scoreText.text = "Score: " + score;
    }

    private void OnApplicationQuit()
    {
        SalvaScore();
    }

    private void OnDestroy()
    {
        SalvaScore();
    }

    private void SalvaScore()
    {
        List<ScoreEntry> leaderboard = CaricaLeaderboard();
        leaderboard.Add(new ScoreEntry { id = currentId, score = score });
        string json = JsonUtility.ToJson(new Wrapper<ScoreEntry> { list = leaderboard });
        PlayerPrefs.SetString("Leaderboard", json);
        PlayerPrefs.Save();
    }

    private List<ScoreEntry> CaricaLeaderboard()
    {
        if (!PlayerPrefs.HasKey("Leaderboard")) return new List<ScoreEntry>();
        string json = PlayerPrefs.GetString("Leaderboard");
        return JsonUtility.FromJson<Wrapper<ScoreEntry>>(json).list;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public List<T> list;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}