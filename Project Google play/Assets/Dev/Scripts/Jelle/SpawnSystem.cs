using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private Transform[] SpawnPoints;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private GameObject[] Boards;
    private SpawnPatrol[] spawnPatrol;
    private Animator[] BoardAnimator;
    private int currentBoard;
    private float timer;

    void Start()
    {
        BoardAnimator = new Animator[Boards.Length];
        spawnPatrol = new SpawnPatrol[SpawnPoints.Length];
        for (int i = 0; i < Boards.Length; i++)
        {
            BoardAnimator[i] = Boards[i].GetComponent<Animator>();
        }
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            spawnPatrol[i] = SpawnPoints[i].GetComponent<SpawnPatrol>();
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
                timer = 0;
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
        print("spawn een board");
        BoardAnimator[currentBoard].SetBool("Turn", true);
        Boards[currentBoard].SetActive(true);
        int pointToSpawnOn = Random.Range(0, SpawnPoints.Length);
        if(spawnPatrol[pointToSpawnOn].canPlace)
        {
            Boards[currentBoard].transform.position = SpawnPoints[pointToSpawnOn].position;
        }
        else
        {
            Boards[currentBoard].transform.position = SpawnPoints[randomIntExcept(0, SpawnPoints.Length, pointToSpawnOn)].position;
        }
    }
}
