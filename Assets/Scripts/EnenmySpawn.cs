using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmySpawn : MonoBehaviour
{
    public GameObject EnemyPreFab;
    public int MaxEnemy = 20;
    public int atualEnemyCont = 0;
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        while (i < MaxEnemy)
        {
            gerarEnemy();
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        atualEnemyCont = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(atualEnemyCont < MaxEnemy)
        {
            gerarEnemy();
        }
    }
    public void gerarEnemy()
    {
        float x = Random.Range(-10.0f, 26.0f);
        float y = getY(x);
        Vector3 local = new Vector3(x, y, 0);
        GameObject n_enemy = Instantiate(EnemyPreFab, local,  Quaternion.identity);
    }
    public float getY(float x)
    {
        float numero = Random.Range(-26.0f, 26.0f);
        if(x > 6 && numero >8)
        {
            numero = getY(x);
        }
        return numero;
    }
}
