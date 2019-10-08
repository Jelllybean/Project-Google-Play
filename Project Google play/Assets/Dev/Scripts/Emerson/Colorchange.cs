using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorchange : MonoBehaviour
{
    Renderer m_Renderer;
    [SerializeField] private Material m_Red;


    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
            m_Renderer.material.SetColor("_Color", Color.red);
        }
    }
    
}
