using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [HideInInspector] public int TotalScore;
    [SerializeField] private string text; 
    [SerializeField] private TextMeshProUGUI[] TextScore;

    void Update()
    {
        for (int i = 0; i < TextScore.Length; i++)
        {
            TextScore[i].text = text + TotalScore;
        }
    }
}
