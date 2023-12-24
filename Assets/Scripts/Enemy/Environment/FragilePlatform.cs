using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    [SerializeField] private Collider2D collider2D;
    private bool isCrumbling;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && isCrumbling == false)
        {
            StartCoroutine(FragilePlatformCountDown());
        }
    }

    private IEnumerator FragilePlatformCountDown()
    {
        Debug.Log("Coroutine Start!");
        isCrumbling = true;
        float crackDuration = 1f;
        yield return new WaitForSeconds(crackDuration);
        collider2D.enabled = false;
        float platformReturn = 3f;
        yield return new WaitForSeconds(platformReturn);
        collider2D.enabled = true;
        isCrumbling = false;
    }
}
