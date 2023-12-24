using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    [SerializeField] private Collider2D collider2D;
    [SerializeField] private GameObject visual;
    private bool isCrumbling;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && isCrumbling == false)
        {
            var playerY = col.transform.position.y;
            var platformY = transform.position.y;
            if (playerY < platformY) return;
            StartCoroutine(FragilePlatformCountDown());
        }
    }

    private IEnumerator FragilePlatformCountDown()
    {
        Debug.Log("Coroutine Start!");
        isCrumbling = true;
        float crackDuration = 1f;
        var shake = visual.LeanMoveLocalY(-0.01f, crackDuration / 10f).setEase(LeanTween.shake).setLoopPingPong();
        yield return new WaitForSeconds(crackDuration);
        visual.SetActive(false);
        collider2D.enabled = false;
        float platformReturn = 3f;
        yield return new WaitForSeconds(platformReturn);
        visual.SetActive(true);
        LeanTween.cancel(shake.id);
        visual.transform.localPosition = Vector3.zero;
        collider2D.enabled = true;
        isCrumbling = false;
    }
}
