using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBord : MonoBehaviour
{
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private Animator animator;
    [HideInInspector] public bool followPosition = true;

    void Update()
    {
        if(followPosition)
        {
            transform.position = SpawnPoint.position;
        }
        //if(Input.touchCount > 0)
        //{
        //    animator.SetBool("Turn", false);
        //}
    }
    //this one gets used by an animation
    public void GoBackDownEvent()
    {
        animator.SetBool("End", true);
        gameObject.SetActive(false);
    }
    //you use this one in another script when you hit a board
    public void GoBackDown()
    {
        animator.SetBool("Turn", false);
    }
    //to start the animation when the object gets enabled
    private void OnEnable()
    {
        animator.SetBool("Turn", true);
    }
}
