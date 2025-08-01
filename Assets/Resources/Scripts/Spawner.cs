using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    [SerializeField] int dogSpeed = 30;
    [SerializeField] int cowSpeed = 15;
    [SerializeField] int horseSpeed = 30;
    [SerializeField] int deerSpeed = 20;

    public void SpawnAnimal()
    {
        int spawnPointX = Random.Range(-48, 54);
        int spawnPointY = 95;
        int spawnPointZ = 30;

        Vector3 spawn = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

        int idx = Random.Range(0, animalPrefabs.Length);
        GameObject animal = Instantiate(animalPrefabs[idx], spawn, Quaternion.Euler(0, 180, 0));
        switch (animal.tag)
        {
            case "Dog":
                animal.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.back * dogSpeed);
                break;
            case "Cow":
                animal.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.back * cowSpeed);
                break;
            case "Horse":
                animal.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.back * horseSpeed);
                break;
            case "Deer":
                animal.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.back * deerSpeed);
                break;
            default:
                Debug.LogWarning("Unknown animal type: " + animal.tag);
                break;
        }
        Destroy(animal, 8f);
    }

    void Start()
    {
        InvokeRepeating("SpawnAnimal", 1f, 2f);
    }
}
