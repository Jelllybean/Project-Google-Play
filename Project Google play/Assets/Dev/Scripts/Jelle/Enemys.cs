using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemys : MonoBehaviour
{
    private HealthManagement HealthManager;
    [SerializeField] private GameObject IdlePoster;
    [SerializeField] private GameObject ShooterPoster;
    void Awake()
    {
        HealthManager = FindObjectOfType<HealthManagement>();
    }
    private void OnEnable()
    {
        Invoke("Shoot", 5f);
    }

    private void Shoot()
    {
        IdlePoster.SetActive(false);
        ShooterPoster.SetActive(true);
        HealthManager.TotalHealth -= 1;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
