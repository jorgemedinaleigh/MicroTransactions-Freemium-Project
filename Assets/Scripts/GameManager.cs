using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> balloons;
    public float spawnRateMin;
    public float spawnRateMax;
    public TMP_Text scoreText;
    public int score;

    void Start()
    {
        int index = Random.Range(0, balloons.Count);
        Instantiate(balloons[index]);
        StartCoroutine(SpawnBalloon());
        score = 0;
        scoreText.text = score.ToString();
    }

    void Update()
    {
        
    }

    public void UpdateScore()
    {
        score = score + 1;
        scoreText.text = score.ToString(); 
    }

    IEnumerator SpawnBalloon()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnRateMin, spawnRateMax));

            int index = Random.Range(0, balloons.Count);
            Instantiate(balloons[index]);
        }
    }
}
