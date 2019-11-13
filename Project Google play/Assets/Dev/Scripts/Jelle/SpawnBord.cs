using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBord : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Transform SpawnPoint;
    [HideInInspector] public bool followPosition = true;
    [SerializeField] private AudioSource BoardFlyIn;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //if(followPosition)
        //{
        //    transform.position = SpawnPoint.position;
        //}
        //if(Input.touchCount > 0)
        //{
        //    animator.SetBool("Turn", false);
        //}
    }

    //to start the animation when the object gets enabled
    private void OnEnable()
    {
        BoardFlyIn.Play();
        animator.SetBool("Turn", true);
    }
    //this one gets used by an animation
    public void GoBackDownEvent()
    {
        animator.SetBool("End", true);
        gameObject.SetActive(false);
    }
    //you use this one in another script when you hit a board
}
