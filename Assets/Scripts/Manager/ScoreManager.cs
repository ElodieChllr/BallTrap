using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int scoreInitial = 0;

    public Text txt_score;
    public Text txt_bestScore;

    public Text txt_scoreFinal;


    public static int score;
    public static int bestScore = 0;
    private string bestScoreKey = "BestScore";


    private string GetBestScoreKeyForScene(string sceneName)
    {
        return "BestScore_" + sceneName;
    }

    private int GetBestScoreForScene(string sceneName)
    {
        string sceneBestScoreKey = GetBestScoreKeyForScene(sceneName);
        return PlayerPrefs.GetInt(sceneBestScoreKey, 0);
    }

    void Start()
    {
        score = scoreInitial;

        
        string currentSceneName = SceneManager.GetActiveScene().name;

        
        int savedBestScore = GetBestScoreForScene(currentSceneName);
        UpdateBestScoreText(savedBestScore);

        MettreAJourAffichageScore();
    }

    // Update is called once per frame
    void Update()
    {
        txt_scoreFinal.text = score.ToString();
    }

    public void AjouterPoints(int points)
    {
        score += points;

        MettreAJourAffichageScore();
    }
    public void AjouterPointPerfect(int points)
    {
        score += points;

        MettreAJourAffichageScore();
    }

    public void EnleverPoints(int pointAEnlever)
    {
        score -= pointAEnlever;

        MettreAJourAffichageScore();
    }

    private void MettreAJourAffichageScore()
    {
        txt_score.text = score.ToString();
        txt_scoreFinal.text = score.ToString();
    }

    public void ReinitialiserScore()
    {
        score = scoreInitial;

        MettreAJourAffichageScore();
    }

    void UpdateBestScoreText(int newBestScore)
    {
        txt_bestScore.text = newBestScore.ToString();
    }

    public void GameOverScore()
    {
        txt_scoreFinal.text = score.ToString();
        string currentSceneName = SceneManager.GetActiveScene().name;

        int savedBestScore = GetBestScoreForScene(currentSceneName);

        if (score > savedBestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt(GetBestScoreKeyForScene(currentSceneName), bestScore);
            PlayerPrefs.Save();
            UpdateBestScoreText(bestScore);
        }
        else
        {
            UpdateBestScoreText(savedBestScore);
        }

        MettreAJourAffichageScore();
    }

    public IEnumerator LoseScoreColor()
    {
        txt_score.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        txt_score.color = Color.white;
    }

    public IEnumerator ShootScoreColor()
    {
        txt_score.color = Color.yellow;
        yield return new WaitForSeconds(0.5f);
        txt_score.color = Color.white;
    }

    public IEnumerator PerfectScoreColor()
    {
        txt_score.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        txt_score.color = Color.white;
    }
}
