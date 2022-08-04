using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGeneration : MonoBehaviour
{
    [SerializeField]
    GameObject[] clouds;

    [SerializeField]
    float spawnInterval;

    [SerializeField]
    GameObject endPoint;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        Prewarm();
        Invoke("AttemptSpawn", spawnInterval);

    }

    void SpawnCloud(Vector3 startPos)
    {
        int randomIndex = Random.Range(0, clouds.Length);
        var cloudToSummon = clouds[randomIndex];

        GameObject cloud = Instantiate(cloudToSummon);

        float startY = Random.Range(startPos.y - 4f, startPos.y + 4f);

        cloud.transform.position = new Vector3(startPos.x, startY, startPos.z);

        cloud.transform.localScale = new Vector2(cloud.transform.localScale.x * 0.8f, cloud.transform.localScale.y * 1.2f);

        float speed = Random.Range(6f, 12f);

        cloud.GetComponent<CloudScript>().StartFloating(speed, endPoint.transform.position.x);
    }

    void AttemptSpawn()
    {
        //check some things.
        SpawnCloud(startPos);

        Invoke("AttemptSpawn", spawnInterval);
    }

    void Prewarm()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 spawnPos = startPos + Vector3.right * (i * 2);
            SpawnCloud(spawnPos);
            new WaitForSecondsRealtime(Random.Range(2.5f, 4));
        }
    }
}
