using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.name == "Player")
        {
            col.collider.GetComponent<Health>().TakingDamage(1);
            Debug.Log($"BOX is still colliding with {col.collider.tag}");
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.name == "Player")
        {
            Debug.Log($"BOX is still colliding with {col.collider.tag}");
        }
    }
}
