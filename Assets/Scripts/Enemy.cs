using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject alvo;
    private float vida = 2;
    public GameObject drop;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerMove>().score += 10;
            Destroy(gameObject);
        }
        if (alvo)
        {
            Vector2 temp = new Vector2(alvo.transform.position.x, alvo.transform.position.y);
            Vector2 lookDir = temp - GetComponent<Rigidbody2D>().position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            GetComponent<Rigidbody2D>().rotation = angle;

            transform.position = Vector2.MoveTowards(transform.position, alvo.transform.position, 2f * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            alvo = other.gameObject;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag =="Player")
        {
            other.gameObject.GetComponent<PlayerMove>().TomaDano();
            Destroy(gameObject, 2f);
        }
    }
    public void TomaDano()
    {
        vida--;
    }
    private void OnDestroy() 
    {
    }
}
