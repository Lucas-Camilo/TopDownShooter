using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float damptime = 0.5f; //valor da suavização
    private Vector3 velocity = Vector3.zero; //velocidade
    private Transform target; //ponto que vai ser seguido
    void Start()
    {
        GameObject[] tempAlvo = GameObject.FindGameObjectsWithTag("Player");
        target = tempAlvo[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToScreenPoint(target.position);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, damptime);
        }
    }
}
