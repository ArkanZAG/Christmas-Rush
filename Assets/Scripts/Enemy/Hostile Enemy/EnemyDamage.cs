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
        }
    }
}
