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

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Bullet"))
        {
            // zderzyli?my si? z pociskiem - usu? pocisk i asteroid? z gry

            //zniszcz pocisk
            Destroy(other);

            //zniszcz asteroide
            Destroy(gameObject);
        }
    }
}
