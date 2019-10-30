using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    private HealthManagement HealthManager;
    void Start()
    {
        HealthManager = FindObjectOfType<HealthManagement>();
    }

    
}
