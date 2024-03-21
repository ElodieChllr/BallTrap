using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    public Wave[] waves;
    public int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 2f;
    public float waveCountdown;

    public float searchCountDown = 1f;
    public GameObject EndPanel;

    public SpawnState state = SpawnState.COUNTING;

   // public GameObject LevelPanel;


    void Start()
    {
        waveCountdown = timeBetweenWaves;
        //LevelPanel.SetActive(false);

        Time.timeScale = 1f;
        if (spawnPoints.Length == 0)
        {
            //Debug.LogError("No spawn points ref");
        }

    }

    void Update()
    {

        if(state == SpawnState.WAITING)
        {
            if (EnemyIsAlive() == false)
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;
        
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
       // Debug.Log("Spawning enemy : " + _enemy.name);

        

        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, sp.position, _enemy.rotation);
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length -1 && EnemyIsAlive() == true)
        {
            OpenLevel();
            //Time.timeScale = 0f;
            state = SpawnState.WAITING;
            //Debug.Log("ALL WAVES COMPLETE");
        }
        else
        {
            nextWave++;
        }

    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 0.5f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == GameObject.FindGameObjectsWithTag("Enemy").Length)
            {
               // Debug.Log("Alldead");
                return false;
            }
        }
        return true;
    }


    public void OpenLevel()
    {
        EndPanel.SetActive(true);
        Time.timeScale = 0f;
        //LevelPanel.SetActive(true);
    }

    /*public void CloseLevel()
    {
        LevelPanel.SetActive(false);
    }*/
}

[System.Serializable]
public class Wave
{
    public string name;
    public Transform enemy;
    public int count;
    public float rate;
}
