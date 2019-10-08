using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [HideInInspector] public int TotalScore;
    [SerializeField] private TextMeshProUGUI TextScore;

    void Update()
    {
        TextScore.text = "" + TotalScore;        
    }
}
