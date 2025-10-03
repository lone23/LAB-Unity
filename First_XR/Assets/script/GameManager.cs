using System;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(XRBaseInteractable interactable)
    {
        score++;
        PlayerPrefs.SetInt("Score", score);
        AggiornaUI();
        Destroy(interactable.gameObject);
    }

    private void AggiornaUI()
    {
        scoreText.text = "Score: " + score;
    }

}
