using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public int Speed;

    public int jumpSpeed;
    public bool isRightSide = true;
    private Rigidbody2D rb;
    private Animator animatorComponent;
    
    void Start()
        {
        animatorComponent = gameObject.GetComponent<Animator>();


        rb = GetComponent<Rigidbody2D>();
    }
    
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.GetComponent<Collider2D>().tag == "ladder")
        {
           
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

        }
        else
        if (col.GetComponent<Collider2D>().tag == "Test")
        {
           
            Run();

        } else
        if (col.GetComponent<Collider2D>().tag == "Player")
        {
            rb.velocity = Vector2.zero;
            animatorComponent.SetInteger("state(for walk)", 0); // Бег
            
            animatorComponent.SetInteger("state(for attack)", 1);


        }
        if (col.GetComponent<Collider2D>().tag == "Test2")
        {
            
            animatorComponent.SetInteger("state(for walk)", 0); // Бег



        }
        else

        if (col.GetComponent<Collider2D>().tag == "Player2")
        {
         
            Run2();
            
        }

    }
   
        
    
    
    
    // Update is called once per frame
    void Update()
    {
        if ((rb.velocity.x > 0f && !isRightSide) || (rb.velocity.x < 0f && isRightSide))
        {
            if (rb.velocity.x != 0f)
            {
                Spin();
            }
        }
     
    }
    void Run()
    {
        animatorComponent.SetInteger("state(for walk)", 1); // Бег
        rb.velocity = new Vector2(-Speed, rb.velocity.y);
    }
    void Run2()
    {
        animatorComponent.SetInteger("state(for walk)", 1); // Бег
        rb.velocity = new Vector2(Speed, rb.velocity.y);
    }

    void Spin()
    {
        isRightSide = !isRightSide;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y * 1,  1f);
    }

}
