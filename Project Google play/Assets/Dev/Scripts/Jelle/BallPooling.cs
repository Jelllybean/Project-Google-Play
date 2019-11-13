using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPooling : MonoBehaviour
{
    [SerializeField] private GameObject[] Balls;
    [SerializeField] private int currentBall = 0;
    [SerializeField] private Transform OriginPoint;
    private Rigidbody[] BallsRigids;

    void Start()
    {
        Balls = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Balls[i] = transform.GetChild(i).gameObject;
        }
        BallsRigids = new Rigidbody[Balls.Length];
        for (int i = 0; i < BallsRigids.Length; i++)
        {
            BallsRigids[i] = transform.GetChild(i).gameObject.GetComponent<Rigidbody>();
        }
        EnableNewBall();
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "ThrownBall")
        //{
        //    EnableNewBall();
        //}
    }

    public void EnableNewBall()
    {
        if(currentBall == Balls.Length)
        {
            currentBall = 0;
        }
        Balls[currentBall].transform.position = OriginPoint.position;
        BallsRigids[currentBall].isKinematic = true;
        Balls[currentBall].SetActive(true);
        currentBall++;

        //for (int i = 0; i < Balls.Length; i++)
        //{
        //    if (!Balls[i].activeSelf)
        //    {
        //        Balls[i].transform.position = OriginPoint.position;
        //        Balls[i].SetActive(true);
        //        break;
        //    }
        //}
    }
}
