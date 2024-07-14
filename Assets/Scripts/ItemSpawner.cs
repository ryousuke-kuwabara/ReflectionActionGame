using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Stage stage;
    [SerializeField] private List<Item> itemList;

    [SerializeField] private float spawnDelayTime;

    private void Start()
    {
        StartCoroutine(SpawnItem());
    }

    IEnumerator SpawnItem()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelayTime);

            Vector3 spawnPosition = stage.GenerateRandomPositionInRadius();
            int spwanItemindex = Random.Range(0, itemList.Count);

            Item newItem =
                Instantiate(itemList[spwanItemindex], spawnPosition, Quaternion.identity);
        }
    }
}
