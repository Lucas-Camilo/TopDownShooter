using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour
{
    public int valorMunicao = 5;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Shooting>().municao += valorMunicao;
            Destroy(gameObject);
        }
    }
}
