using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagement : MonoBehaviour
{
    [SerializeField] private Image[] HearthImages;
    [SerializeField] private GameObject DeathScreen;
    public int TotalHealth = 3;

    void Update()
    {
        for (int i = 0; i < HearthImages.Length; i++)
        {
            HearthImages[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < TotalHealth; i++)
        {
            HearthImages[i].gameObject.SetActive(true);
        }

        if(TotalHealth <= 0)
        {
            DeathScreen.SetActive(true);
        }
    }
}
