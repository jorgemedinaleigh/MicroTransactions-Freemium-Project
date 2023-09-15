using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> balloons;
    public float spawnRateMin;
    public float spawnRateMax;

    void Start()
    {
        int index = Random.Range(0, balloons.Count);
        Instantiate(balloons[index]);
        StartCoroutine(SpawnBalloon());
    }

    void Update()
    {
        
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
