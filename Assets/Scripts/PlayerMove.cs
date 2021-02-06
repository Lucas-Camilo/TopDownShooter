using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    public TextMeshProUGUI vidaUI;
    public TextMeshProUGUI pont;

    Vector2 movement;
    Vector2 mousePos;

    private int vida = 5;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        vidaUI.text = vida.ToString();
        pont.text = score.ToString();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        rb.rotation = angle;
    }
    public void TomaDano()
    {
        vida--;
        if (vida <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}

