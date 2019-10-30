using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBord : MonoBehaviour
{
    private SpawnBord spawnBord;
    private Score score;
    [SerializeField] private GameObject DeathPoster;
    [SerializeField] private GameObject IdlePoster;
    [SerializeField] private GameObject ShootPoster;
    void Start()
    {
        score = FindObjectOfType<Score>();
        spawnBord = GetComponent<SpawnBord>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ThrownBall")
        {
            IdlePoster.SetActive(false);
            ShootPoster.SetActive(false);
            DeathPoster.SetActive(true);
            StartCoroutine(spawnBord.GoBackDown());
            score.TotalScore += 100;
        }
    }
}
