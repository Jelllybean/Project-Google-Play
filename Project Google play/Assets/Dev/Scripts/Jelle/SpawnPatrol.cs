using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPatrol : MonoBehaviour
{

    public Vector3 direction;
    public bool canPlace;
    private float moveSpeed;
    private float distance;

    void Update()
    {
        transform.Translate(direction);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Wall")
        {
            direction.x *= -1;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Board")
        {
            canPlace = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canPlace = true;
    }
}
