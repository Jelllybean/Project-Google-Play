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
    [SerializeField] private SpawnPatrol[] spawnPatrol;
    private float timer;

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
        timer += spawnSpeed * Time.deltaTime;
        if(timer >= 0.5f)
        {
            int randomNum = Random.Range(0, BordList.Count);
            int randomNumSpawn = Random.Range(0, spawnPatrol.Length);
            if(!BordList[randomNum].activeSelf)
            {
                spawnBord[randomNum].followPosition = false;
                BordList[randomNum].gameObject.transform.rotation = Quaternion.Euler(0,
                                                                                     -90,
                                                                                     0);
                BordList[randomNum].SetActive(true);
                if(spawnPatrol[randomNumSpawn].canPlace)
                {
                    BordList[randomNum].transform.position = SpawnPoint[randomNumSpawn].position;
                }
                else
                {
                    int aaaa = randomIntExcept(0, spawnPatrol.Length, randomNumSpawn);
                    BordList[randomNum].transform.position = SpawnPoint[aaaa].position;
                    print("he het werkt");
                    print("RandomNumSpawn: " + randomNumSpawn + " Uitzondering: " + aaaa);
                }
            }
            timer = 0;
        }
    }

    public int randomIntExcept(int min, int max, int except)
    {
        int result = Random.Range(min, max - 1);
        if (result >= except) result += 1;
        return result;
    }
}
