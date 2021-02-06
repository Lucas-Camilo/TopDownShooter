using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;

    public List<Gun> arma;

    public int localArma = 0;

    public float bulletForce = 20f;

    public TextMeshProUGUI bulletCont;

    public int municao = 30 ;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(arma[localArma].pente > 0)
                Shoot();
            else
            {
                if(municao > 0)
                {
                    arma[localArma].recarregar();
                    municao -= arma[localArma].maxPente;
                }
            }

        }
        bulletCont.text = arma[localArma].pente.ToString() + "/" + municao.ToString();
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        AudioMenager.instanciate.PlaySFX(arma[localArma].Som);
        arma[localArma].pente--;
    }
}

[Serializable]
public class Gun 
{
    public string Nome;
    public AudioClip Som;
    public float Dano;
    public Sprite forma;
    public int pente;
    public int maxPente;
    
    public Gun(string n_nome, float n_dano)
    {
        Nome = n_nome;
        Dano = n_dano;
    }
    public void recarregar()
    {
        pente = maxPente;
    }
}
