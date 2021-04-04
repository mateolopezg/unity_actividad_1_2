using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugadora : MonoBehaviour
{

    public float fuerzaSalto;
    public GameManager gameManager;
    private Rigidbody2D rigidbody2D;
    private Animator animator; //Para agregar animación 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); //Para agregar animación 
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
    }

    void OnCollision2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "suelo")
        {
            //animator.SetBool("estaSaltando") //Para agregar animación
        }
        if(collision.gameObject.tag == "roca")
        {
            gameManager.gameOver = true;
        }
    }

    void Controls(){
        if(Input.GetKey("a")){
            this.transform.position = new Vector2(-3,0); //(x,y)
        } 

        if(Input.GetKey("d")){
            this.transform.position = new Vector2(3,0); //(x,y)
        }

        if(Input.GetKey("e")){
            transform.Rotate(0,0,-4); //rotacion
        }

        if(Input.GetKey("q")){
            transform.Rotate(0,0,4); //rotacion
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //animator.SetBool("animator.SetBool("estaSaltando")", true); //Para agregar animación
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
        }
        if(Input.GetKeyDown("w"))
        {
            //animator.SetBool("saltar", true); //Para agregar animación
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto)); 
        }
    }
}
