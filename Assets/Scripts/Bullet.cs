using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public GameObject hitEffect;
    private void Start() 
    {
        Destroy(gameObject, 5f);
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        // GameObject effect = Instantiate(hitEffect, transform.position, Quanternion.identity);
        // Destroy(effect, 5f);
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().TomaDano();
        }
        Destroy(gameObject);
    }
}