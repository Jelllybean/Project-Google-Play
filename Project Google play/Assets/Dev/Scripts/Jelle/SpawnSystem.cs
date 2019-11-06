using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private Transform[] SpawnPoints;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private GameObject[] Boards;
    private Animator[] BoardAnimator;
    private int currentBoard;
    private float timer;

    void Start()
    {
        BoardAnimator = new Animator[Boards.Length];
        for (int i = 0; i < Boards.Length; i++)
        {
            BoardAnimator[i] = Boards[i].GetComponent<Animator>();
        }
    }

    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= spawnSpeed)
        {
            int randomNum = Random.Range(0, Boards.Length);
            if (!Boards[randomNum].activeSelf)
            {
                currentBoard = randomNum;
                timer = 0;
                SpawnBord();
            }
            else
            {
                int randomNumExcept = randomIntExcept(0, Boards.Length, randomNum);
                currentBoard = randomNumExcept;
                SpawnBord();
            }
        }
    }

    private int randomIntExcept(int min, int max, int except)
    {
        int result = Random.Range(min, max - 1);
        if (result >= except) result += 1;
        return result;
    }

    private void SpawnBord()
    {
        BoardAnimator[currentBoard].SetBool("Turn", true);
        Boards[currentBoard].SetActive(true);
        Boards[currentBoard].transform.position = SpawnPoints[Random.Range(0, SpawnPoints.Length)].position;
    }
}
