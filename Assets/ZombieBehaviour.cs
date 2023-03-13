using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        //Vector3 playerDirection = transform.position - player.transform.position;
        
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
