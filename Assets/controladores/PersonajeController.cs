using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool morir;
    public GameObject kunai;
    public GameObject kunai1;
    public Transform position;
    public Transform position2;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sp;
    public int velocidad = 3;
    public int saltar = 1;
    private const int animacion_quieto = 0;
    private const int animacion_correr = 1;
    private const int animacion_saltar = 2;
    private const int animacion_lanzar = 3;
    private const int animacion_morir = 4;
    //private const int animacion_morir = 4;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (morir != true) { 
            rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetInteger("estado_animacion", animacion_quieto);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
            animator.SetInteger("estado_animacion", animacion_correr);
            sp.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            animator.SetInteger("estado_animacion", animacion_correr);
            sp.flipX = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, saltar);
                 animator.SetInteger("estado_animacion", animacion_saltar);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            if (sp.flipX == false)
            {
                Instantiate(kunai, position.position, Quaternion.identity);
                animator.SetInteger("estado_animacion", animacion_lanzar);
            }
            else
            {
                Instantiate(kunai1, position2.position, Quaternion.identity);
                animator.SetInteger("estado_animacion", animacion_lanzar);
            }

        }
        }
        else
        {
            animator.SetInteger("estado_animacion", animacion_morir);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "zombie")
            morir = true;
    }
}
