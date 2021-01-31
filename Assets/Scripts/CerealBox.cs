﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealBox : MonoBehaviour
{
    public GameObject key;
    public Transform spawnPoint;
    private int keyCount = 0;
    public bool pickedUp = false;
    private bool spawnClear = true;
    public float positionTrigger = -0.25f;
    void Update()
    {
        if(spawnPoint.position.y < transform.position.y + positionTrigger)
        {
            if(spawnClear == true)
            StartCoroutine(KeyDelay());
        }
    }
    IEnumerator KeyDelay()
    {
        spawnClear = false;
        yield return new WaitForSeconds(0.1f);
        GameObject newKey = Instantiate(key, spawnPoint.position, Quaternion.Euler(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f)));
        newKey.name = "Key";
        keyCount = keyCount + 1;
        if (keyCount > 50)
        {
            this.enabled = false;
        }
        spawnClear = true;
    }
}
