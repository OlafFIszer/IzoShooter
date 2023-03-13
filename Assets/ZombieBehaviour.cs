using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    GameObject player;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = maxHealth;


    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if(health <= 0) { 
        Destroy(gameObject);
        }

       
        
    }
        

    void Update()
    {
        transform.LookAt(player.transform.position);
        
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    }

