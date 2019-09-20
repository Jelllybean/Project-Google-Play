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
    private float timer;

    void Start()
    {
        for (int i = 0; i < BordList.Count; i++)
        {
            spawnBord[i] = BordList[i].GetComponent<SpawnBord>();
            BordList[i].SetActive(false);
        }
    }

    
    void Update()
    {
        timer += spawnSpeed * Time.deltaTime;
        if(timer >= 2.5f)
        {
            int randomNum = Random.Range(0, BordList.Count);
            if(!BordList[randomNum].activeSelf)
            {
                spawnBord[randomNum].followPosition = false;
                BordList[randomNum].SetActive(true);
                BordList[randomNum].transform.position = SpawnPoint[Random.Range(0, SpawnPoint.Length)].position;
                print("dgjdfijodsf");
            }
            timer = 0;
        }
    }
}
