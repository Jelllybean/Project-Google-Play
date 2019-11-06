using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBord : MonoBehaviour
{
    private SpawnBord spawnBord;
    private Score score;
    private Enemys enemy;
    private Animator animator;
    [SerializeField] private GameObject DeathPoster;
    [SerializeField] private GameObject IdlePoster;
    [SerializeField] private GameObject ShootPoster;
    void Start()
    {
        enemy = GetComponent<Enemys>();
        score = FindObjectOfType<Score>();
        spawnBord = GetComponent<SpawnBord>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ThrownBall")
        {
            IdlePoster.SetActive(false);
            ShootPoster.SetActive(false);
            if (DeathPoster)
                DeathPoster.SetActive(true);
            StartCoroutine(GoBackDown());
            score.TotalScore += 100;
            enemy.CancelInvoke("Shoot");
        }
    }

    public IEnumerator GoBackDown()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Turn", false);
    }
}
