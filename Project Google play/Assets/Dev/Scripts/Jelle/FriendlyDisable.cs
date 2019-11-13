using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyDisable : MonoBehaviour
{
    private DestroyBord destroyBord;

    private void Awake()
    {
        destroyBord = GetComponent<DestroyBord>();
    }
    private void OnEnable()
    {
        StartCoroutine(DisableObject());
    }

    private IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(5f);
        destroyBord.animator.SetBool("Turn", false);
        destroyBord.SoundEffects[1].Play();
    }
}
