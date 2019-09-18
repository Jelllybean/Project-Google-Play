﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBord : MonoBehaviour
{
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = SpawnPoint.position;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Turn", false);
        }
    }
    private void OnEnable()
    {
        animator.SetBool("Turn", true);
    }
    private void OnDisable()
    {
    }
}
