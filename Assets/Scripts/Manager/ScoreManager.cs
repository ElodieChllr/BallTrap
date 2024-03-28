using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    void Start()
    {
        score = scoreInitial;

        int savedBestScore = PlayerPrefs.GetInt("BestScore", 0);
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
        
        if(score > bestScore)
        {
            txt_scoreFinal.text = score.ToString();
            bestScore = score;
            PlayerPrefs.SetInt(bestScoreKey,bestScore);
            PlayerPrefs.Save();
            UpdateBestScoreText(bestScore);
        }

        score = 0;
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
