using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Spawner : MonoBehaviour
{
    public GameObject Zombie;
    List<GameObject> zombieList = new List<GameObject>();
    public int xPos;
    public int zPos;
    public GameObject healPrefab;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void usuwanie()
    {

        for (int i = zombieList.Count - 1; i >= 0; i--)
        {
            if (zombieList[i] == null)
            {
                zombieList.RemoveAt(i);
            }
        }



    }



    // Update is called once per frame
    void Update()
    {
        usuwanie();

        if (zombieList.Count <= 1)
        {
            xPos = Random.Range(1, 16);
            zPos = Random.Range(5, -13);
            GameObject z = Instantiate(Zombie, new Vector3(xPos, 1, zPos), Quaternion.identity);
            zombieList.Add(z);


        }
        if (GameObject.FindGameObjectsWithTag("Heal").Length < 1)
        {
            Instantiate(healPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        }
        Vector3 GetRandomSpawnPosition()
        {

            Vector3 spawnPoint;
            do
            {
                spawnPoint = UnityEngine.Random.insideUnitSphere;
                spawnPoint.y = 0f;
                spawnPoint = spawnPoint.normalized;
                spawnPoint *= UnityEngine.Random.Range(10f, 20f);
                spawnPoint += player.transform.position;

            }

            while (Physics.CheckSphere(new Vector3(spawnPoint.x, 1, spawnPoint.z), 0.9f));
            return spawnPoint;




        }
    }
}
