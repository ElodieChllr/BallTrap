using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int scoreInitial = 0;

    public Text textScore;

    public int scoreActuel;


    void Start()
    {
        scoreActuel = scoreInitial;

        MettreAJourAffichageScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AjouterPoints(int points)
    {
        scoreActuel += points;

        MettreAJourAffichageScore();
    }

    public void EnleverPoints(int pointAEnlever)
    {
        scoreActuel -= pointAEnlever;

        MettreAJourAffichageScore();
    }

    private void MettreAJourAffichageScore()
    {
        textScore.text = scoreActuel.ToString();
    }

    public void ReinitialiserScore()
    {
        scoreActuel = scoreInitial;

        MettreAJourAffichageScore();
    }
}
