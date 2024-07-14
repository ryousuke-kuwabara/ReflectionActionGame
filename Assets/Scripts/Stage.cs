using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    [SerializeField] private float ItemSpawnRadius;
    [SerializeField] private float EndLineRadius;

    public Action _onGameOver;

    public Vector3 GenerateRandomPositionInRadius()
    {
        float randomAngle = UnityEngine.Random.Range(0f, 360f);
        float randomDistance = UnityEngine.Random.Range(0f, ItemSpawnRadius);

        float x = transform.position.x + randomDistance * Mathf.Cos(randomAngle * Mathf.Deg2Rad);
        float y = transform.position.y + randomDistance * Mathf.Sin(randomAngle * Mathf.Deg2Rad);
        Vector3 randomPosition = new Vector3(x, y, 0f);

        return randomPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0, 0, 0.25f);
        Gizmos.DrawWireSphere(this.transform.position, ItemSpawnRadius);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var baby = collision.GetComponent<BabyController>();

        if (baby != null && Time.timeScale != 0.0f)
        {
            StartCoroutine("HandleGameOver");
        }
    }

    private IEnumerator HandleGameOver()
    {
        yield return new WaitForSeconds(0.1f);

        SoundManager.Instance.StopLoopSe();

        Time.timeScale = 0.0f;
        _onGameOver?.Invoke();
    }
}
