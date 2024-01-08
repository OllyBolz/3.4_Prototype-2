using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private GameObject chosenChick;

    private float spawn = 20f;

    private float startDelay = 1f;
    private float spawnInterval = 0.5f;

    public static int designation;

    void Start() 
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
            
        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0://Top
                chosenChick = Instantiate(animalPrefabs[animalIndex], new Vector3(Random.Range(-spawn, spawn), 0, spawn), Quaternion.Euler(0f, 180f, 0f));
                break;
            case 1://Bottom
                chosenChick = Instantiate(animalPrefabs[animalIndex], new Vector3(Random.Range(-spawn, spawn), 0, -spawn), Quaternion.Euler(0f, 0f, 0f));
                break;
            case 2://Left
                chosenChick = Instantiate(animalPrefabs[animalIndex], new Vector3(-spawn, 0, Random.Range(-spawn, spawn)), Quaternion.Euler(0f, 90f, 0f));
                break;
            case 3://Right
                chosenChick = Instantiate(animalPrefabs[animalIndex], new Vector3(spawn, 0, Random.Range(-spawn, spawn)), Quaternion.Euler(0f, 270f, 0f));
                break;
        }

        designation += 1;
        chosenChick.gameObject.name = "Chicken " + designation.ToString();
    }
}
