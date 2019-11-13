using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordDeath : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    //to start the animation when the object gets enabled
    private void OnEnable()
    {
        animator.SetBool("End", true);
    }
}
