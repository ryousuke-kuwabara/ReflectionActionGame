using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Stage stage;
    [SerializeField] private List<Item> itemList;

    [SerializeField] private float spawnDelayTime;

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _minimumDistanceFromPlayer;

    private void Start()
    {
        StartCoroutine(SpawnItem());
    }

    IEnumerator SpawnItem()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelayTime);

            Vector3 spawnPosition = GetValidSpawnPosition();
            int spwanItemindex = Random.Range(0, itemList.Count);

            Item newItem =
                Instantiate(itemList[spwanItemindex], spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetValidSpawnPosition()
    {
        Vector3 spawnPosition;
        float currentDistance;

        do
        {
            spawnPosition = stage.GenerateRandomPositionInRadius();
            currentDistance = Vector3.Distance(spawnPosition, _playerTransform.position);

            if (currentDistance >= _minimumDistanceFromPlayer)
            {
                return spawnPosition;
            }
        } while (true);
    }
}
