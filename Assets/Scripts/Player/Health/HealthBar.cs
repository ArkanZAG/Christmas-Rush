using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [FormerlySerializedAs("playerHealth")] [SerializeField] private HealthComponent playerHealthComponent;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHeathBar;
    
    void Start()
    {
        totalHealthBar.fillAmount = playerHealthComponent.GetCurrentHealth() / 10;
    }

    
    void Update()
    {
        currentHeathBar.fillAmount = playerHealthComponent.GetCurrentHealth() / 10;
    }
}
