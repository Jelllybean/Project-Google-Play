using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    private SpawnBord spawnBord;
    private HealthManagement HealthManager;
    [SerializeField] private GameObject IdlePoster;
    [SerializeField] private GameObject ShooterPoster;
    private Animator animator;
    [SerializeField] private AudioSource[] SoundEffects;

    void Awake()
    {
        HealthManager = FindObjectOfType<HealthManagement>();
        spawnBord = GetComponent<SpawnBord>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        Invoke("Shoot", 5f);
        IdlePoster.SetActive(true);
        ShooterPoster.SetActive(false);
    }

    private void Shoot()
    {
        SoundEffects[0].Play();
        IdlePoster.SetActive(false);
        ShooterPoster.SetActive(true);
        HealthManager.TotalHealth -= 1;
        StartCoroutine(GoBackDown());
    }

    private IEnumerator GoBackDown()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Turn", false);
    }
}
