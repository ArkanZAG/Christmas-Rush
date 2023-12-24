using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Collectible
{
    public class CollectibleSpawner : MonoBehaviour
    {
        [SerializeField] private ScoreController scoreController;
        [SerializeField] private GameObject collectiblePrefab;
        [SerializeField] private Transform[] spawnPoints;

        private void Start()
        {
            //Untuk setiap point di spawnPoints
            foreach (var point in spawnPoints)
            {
                GameObject copy = Instantiate(collectiblePrefab, point.position, point.rotation);
                CollectibleItem collectible = copy.GetComponent<CollectibleItem>();
                //Inject score controller to collectible
                collectible.Initialize(scoreController);
            }
        }
    }
}