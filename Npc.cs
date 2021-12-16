using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{

  
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;

    public LayerMask playerLayer;
    public float radius;
   bool onRadius;

    private Gerenciador gr;

    private void Start()
    {
        gr = FindObjectOfType<Gerenciador>();
    }
    private void FixedUpdate()
    {
        Interact();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onRadius)
        {
            gr.Speech(profile, speechTxt, actorName);
        }
    }
    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);

        if(hit != null)
        {
            onRadius = true;
        }
        else
        {
            onRadius = false;
        }
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
