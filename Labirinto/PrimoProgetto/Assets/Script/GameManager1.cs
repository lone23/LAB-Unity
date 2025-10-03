using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject atmoPrefab;

    [SerializeField]
    Vector3 initPosAtmo;

    public int score;

    public int Healt = 3; 

    public TextMeshProUGUI ScoreText;

    public TextMeshProUGUI HealtText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(atmoPrefab, initPosAtmo, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {




    }

    public void UpdateScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }

    public void UpdateHealt()
    {
        Healt--;
        HealtText.text = Healt.ToString();
        if(Healt <= 0)
        {
            SceneManager.LoadScene("SampleScene");
            Healt = 3; 
        }
    }

}
