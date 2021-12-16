using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public float  velociadade = 5f;
    public Rigidbody2D rb;
    public Animator ani;
    public GameObject cam;
    Vector2 movimento;
    private Vector3 esquerda;
    private Vector3 direita;
    private Vector3 posi;


    void Start()
    {
        esquerda = transform.localScale;
        esquerda.x = esquerda.x * -1;
        direita = transform.localScale;


       
    }


    void Update()
    {
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");

        ani.SetFloat("Horizontal", movimento.x);
        ani.SetFloat("Vertical", movimento.y);
        ani.SetFloat("Velocidade", movimento.sqrMagnitude);

        posi = transform.position;
        posi.z = posi.z - 10;
        cam.transform.position = posi;

        if (movimento.x < 0)
        { 
            transform.localScale = esquerda;
        }
        else
        {
            
            transform.localScale = direita;
        }
    }
        void FixedUpdate()
        {
            rb.MovePosition(rb.position + movimento * velociadade * Time.fixedDeltaTime);
        }
    
}
