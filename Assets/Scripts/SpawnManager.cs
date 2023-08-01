using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles;
    BackgroundMove bgSc;
    int firstScore = 10;
    [SerializeField] float secondsToSpawn = 5.0f;
    
    void Start()
    {
        bgSc = GameObject.Find("Manager").GetComponent<BackgroundMove>();
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (bgSc.gameOn)
        {
            if (bgSc.score > firstScore)
            {
                firstScore += 10;
                secondsToSpawn -= 0.3f;
            }
            int randomNum = Random.Range(0,obstacles.Count);
            Instantiate(obstacles[randomNum], new Vector3(transform.position.x, obstacles[randomNum].transform.position.y, transform.position.z),
            obstacles[randomNum].transform.rotation);
            yield return new WaitForSeconds(Random.Range(secondsToSpawn - 1.8f,secondsToSpawn + 0.3f));
        }
    }
}
