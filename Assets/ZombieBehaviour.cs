using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.AI;

public class ZombieBehaviour : MonoBehaviour
{
    public float sightRange = 15f;
    public float hearRange = 5f;
    int hp = 1;

    GameObject player;
    NavMeshAgent agent;

    private bool playerVisible = false;
    private bool playerHearable = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 raySource = transform.position + Vector3.up * 1.8f;
        Vector3 rayDirection = player.transform.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(raySource, rayDirection, out hit, sightRange))
        {
            Debug.Log(hit.transform.gameObject.name.ToString());
            if (hit.transform.CompareTag("Player"))
                playerVisible = true;
            else
                playerVisible = false;
        }

        Collider[] heardObjects = Physics.OverlapSphere(transform.position, hearRange);
        playerHearable = false;
        foreach (Collider collider in heardObjects)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                playerHearable = true;
            }
        }


        agent.isStopped = !playerVisible && !playerHearable;
        if (hp > 0)
        {
            agent.destination = player.transform.position;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            hp--;
            if (hp <= 0)
            {
                Die();
            }
        }
    }
    private void Die()
    {
        agent.isStopped = true;
        transform.Translate(Vector3.up);
        transform.Rotate(transform.right * -90);
        GetComponent<BoxCollider>().enabled = false;
        Destroy(transform.gameObject, 1);
    }
}