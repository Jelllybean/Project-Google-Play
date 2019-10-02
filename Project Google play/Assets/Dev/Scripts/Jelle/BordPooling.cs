using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordPooling : MonoBehaviour
{
    //private GameObject Bords;
    [SerializeField] private SpawnBord[] spawnBord;
    [SerializeField] private List<GameObject> BordList;
    [SerializeField] private Transform[] SpawnPoint;
    [SerializeField] private float spawnSpeed;
    private SpawnPatrol[] spawnPatrol = new SpawnPatrol[3];
    private float timer;
    private bool goTroughFor = true;

    void Start()
    {
        for (int i = 0; i < BordList.Count; i++)
        {
            spawnBord[i] = BordList[i].GetComponent<SpawnBord>();
            BordList[i].gameObject.transform.rotation = Quaternion.Euler(0,
                                                                         -90,
                                                                         0);
            BordList[i].SetActive(false);
        }
        for (int i = 0; i < SpawnPoint.Length; i++)
        {
            spawnPatrol[i] = SpawnPoint[i].GetComponent<SpawnPatrol>();
        }
    }


    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= spawnSpeed)
        {
            Debug.Log("spawn een bord");
            int randomNum = Random.Range(0, BordList.Count);
            int randomNumSpawn = Random.Range(0, spawnPatrol.Length);
            int randomNumInactive = randomIntExcept(0, BordList.Count, randomNum);
            for (int i = 0; i < BordList.Count; i++)
            {
                if (!BordList[i].activeSelf)
                {
                    SpawnBordFunction(i, randomNumSpawn);
                    break;
                }
            }
            //if (!BordList[randomNum].activeSelf)
            //{
            //    SpawnBordFunction(randomNum, randomNumSpawn);
            //}
            //else if(!BordList[randomNumInactive].activeSelf)
            //{
            //    SpawnBordFunction(randomNumInactive, randomNumSpawn);
            //}
            timer = 0;
        }
    }

    private void SpawnBordFunction(int selectedBord, int randomNumSpawn)
    {
        goTroughFor = true;
        spawnBord[selectedBord].followPosition = false;
        BordList[selectedBord].gameObject.transform.rotation = Quaternion.Euler(0,
                                                                             -90,
                                                                             0);
        BordList[selectedBord].SetActive(true);
        for (int i = 0; i < spawnPatrol.Length; i++)
        {
            if(!spawnPatrol[i].canPlace)
            {
                BordList[selectedBord].transform.position = SpawnPoint[randomIntExcept(0, spawnPatrol.Length, i)].position;
            }
            else
            {
                BordList[selectedBord].transform.position = SpawnPoint[Random.Range(0, spawnPatrol.Length)].position;
            }
        }
        //if (spawnPatrol[randomNumSpawn].canPlace)
        //{
        //    BordList[selectedBord].transform.position = SpawnPoint[randomNumSpawn].position;
        //}
        //else
        //{
        //    //print("random nummer van de spawn: " + randomNumSpawn);
        //    int aaa = randomIntExcept(0, spawnPatrol.Length, randomNumSpawn);
        //    BordList[selectedBord].transform.position = SpawnPoint[aaa].position;
        //}
    }
    private int randomIntExcept(int min, int max, int except)
    {
        int result = Random.Range(min, max - 1);
        if (result >= except) result += 1;
        return result;
    }
}
