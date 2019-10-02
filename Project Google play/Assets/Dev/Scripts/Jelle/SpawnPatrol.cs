using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPatrol : MonoBehaviour
{

    public Vector3 direction;
    public bool canPlace = true;
    private float moveSpeed;
    private float distance;
    [SerializeField] private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer.GetComponent<MeshRenderer>();
    }
    void Update()
    {
        transform.Translate(direction);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Wall")
        {
            direction.x *= -1;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Board")
        {
            canPlace = false;
            meshRenderer.enabled = true;
        }
        else
        {
            canPlace = true;
            meshRenderer.enabled = false;
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //}
}
