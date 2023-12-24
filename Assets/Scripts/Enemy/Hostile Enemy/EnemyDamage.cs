using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        /*if (col.tag == "Player")
        {
            col.GetComponent<HealthComponent>().TakingDamage(1);
        }*/
        
        /*HealthComponent health = col.GetComponent<HealthComponent>();
        if (health == null) return;
        health.TakingDamage(1);*/

        if (col.TryGetComponent(out HealthComponent component))
            component.TakingDamage(1);
    }
}
