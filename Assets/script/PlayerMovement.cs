using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    Vector2 direction;

    Rigidbody2D rbplayer;

    Animator animator;

    public int hp = 5;
    public int maxhp = 5;
    bool isattack;

    [SerializeField] UImanager Uimanager;



    private void Start()
    {
        hp = maxhp;
        rbplayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rbplayer.velocity = direction * speed;
    }

    private void Update()
    {
        Animations();
        Movement();

        if (hp > maxhp)
        {
            hp = maxhp;
        }
    }

    private void Movement()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("attack");
            isattack = true;
        }
    }

    private void Animations()
    {
        if (isattack)
        {
            return;
        }

        if (direction.magnitude != 0)
        {
            animator.SetFloat("horizontal", direction.x);
            animator.SetFloat("vertical", direction.y);
            animator.Play("Run");
        }
        else animator.Play("idle");
    }

    private void endattack()
    {
        isattack = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            hp--;
            Uimanager.restarcorazones(hp);
        }


    }

    public void sumavida()
    {
        if (hp < maxhp) 
        {
            Uimanager.sumarcorazones(hp);
            hp++;

        }
    }


}
