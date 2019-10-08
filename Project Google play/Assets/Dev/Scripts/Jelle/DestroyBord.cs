using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBord : MonoBehaviour
{
    private SpawnBord spawnBord;
    private Score score;
    void Start()
    {
        score = FindObjectOfType<Score>();
        spawnBord = GetComponent<SpawnBord>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ThrownBall")
        {
            spawnBord.GoBackDown();
            score.TotalScore += 100;
        }
    }
}
