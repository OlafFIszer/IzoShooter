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

    // Start is called before the first frame update
    void Start()
    {

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
            GameObject z = Instantiate(Zombie, new Vector3(xPos, 43, zPos), Quaternion.identity);
            zombieList.Add(z);
            
            
        }
     
     
        



    }
}
