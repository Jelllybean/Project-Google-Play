using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBord : MonoBehaviour
{
    private SpawnBord spawnBord;
    private Score score;
    private Enemys enemy;
    public Animator animator;
    [SerializeField] private int pointsToGive = 100;
    [SerializeField] private GameObject DeathPoster;
    [SerializeField] private GameObject IdlePoster;
    [SerializeField] private GameObject ShootPoster;
    [SerializeField] private GameObject ScoreText;
    public AudioSource[] SoundEffects;
    void Start()
    {
        enemy = GetComponent<Enemys>();
        score = FindObjectOfType<Score>();
        spawnBord = GetComponent<SpawnBord>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        DeathPoster.SetActive(false);
        IdlePoster.SetActive(true);
        if (ShootPoster)
            ShootPoster.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ThrownBall")
        {
            ScoreText.SetActive(true);
            ScoreText.transform.position = transform.position;
            IdlePoster.SetActive(false);
            if (ShootPoster)
                ShootPoster.SetActive(false);
            DeathPoster.SetActive(true);
            StartCoroutine(GoBackDown());
            score.TotalScore += pointsToGive;
            SoundEffects[0].Play();
            if (enemy)
                enemy.CancelInvoke("Shoot");
        }
    }

    public IEnumerator GoBackDown()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Turn", false);
        SoundEffects[1].Play();
    }
}
