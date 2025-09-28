using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject[] fishPrefabs;    // prefab ikan yang bisa dimunculin
    public float spawnInterval = 2f;    // jeda antar spawn
    public float spawnRangeX = 10f;     // area horizontal spawn
    public float spawnRangeY = 5f;      // area vertical spawn
    public float spawnOffset = 15f;     // jarak dari player biar munculnya ga nabrak player

    [Header("Reference")]
    public Transform player;            // posisi player

    private void Start()
    {
        StartCoroutine(SpawnFishRoutine());
    }

    IEnumerator SpawnFishRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnFish();
        }
    }

    void SpawnFish()
    {
        if (fishPrefabs.Length == 0) return;

        // random prefab ikan
        GameObject fishPrefab = fishPrefabs[Random.Range(0, fishPrefabs.Length)];

        // random posisi spawn (sekitar player, bisa kiri/kanan/atas/bawah)
        Vector2 spawnPos = player.position;
        int dir = Random.Range(0, 4);

        switch (dir)
        {
            case 0: // kiri
                spawnPos += Vector2.left * spawnOffset + new Vector2(0, Random.Range(-spawnRangeY, spawnRangeY));
                break;
            case 1: // kanan
                spawnPos += Vector2.right * spawnOffset + new Vector2(0, Random.Range(-spawnRangeY, spawnRangeY));
                break;
            case 2: // atas
                spawnPos += Vector2.up * spawnOffset + new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 0);
                break;
            case 3: // bawah
                spawnPos += Vector2.down * spawnOffset + new Vector2(Random.Range(-spawnRangeX, spawnRangeX), 0);
                break;
        }

        // spawn ikan
        Instantiate(fishPrefab, spawnPos, Quaternion.identity);
    }
}
