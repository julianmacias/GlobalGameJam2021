using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private bool spawnClear = true;
    public Transform spawnPoint;
    public GameObject coin;
    int coinCount = 0;

    void Update()
    {
        if (spawnClear == true)
            StartCoroutine(SpawnDelay());
    }
    IEnumerator SpawnDelay()
    {
        spawnClear = false;
        yield return new WaitForEndOfFrame();
        GameObject newKey = Instantiate(coin, new Vector3((Random.Range(spawnPoint.position.x - 0.2f , spawnPoint.position.x + 0.2f)), 
            (Random.Range(spawnPoint.position.y - 0.03f, spawnPoint.position.x + 0.3f) + 0.1f), 
            (Random.Range(spawnPoint.position.x - 0.05f, spawnPoint.position.x + 0.05f) + 1.3f)),
            Quaternion.Euler(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f)));
        coinCount = coinCount + 1;
        if (coinCount > 200)
        {
            this.enabled = false;
        }
        spawnClear = true;
    }
}
