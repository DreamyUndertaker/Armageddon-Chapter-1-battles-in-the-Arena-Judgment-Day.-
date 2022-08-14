using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DamageableObject2 : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Obstacle;
    public GameObject Attack;
    private Animator animatorComponent;
    [SerializeField] private float _healthPoints;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorComponent = gameObject.GetComponent<Animator>();
        


    }
    public void TakeDamage(float damage)
    {
        

        _healthPoints -= damage;
        animatorComponent.SetInteger("state(for hit)", 1);
        
        if (_healthPoints <= 0)
        {
            rb.gravityScale = 100f;
            Destroy(Attack);
            Destroy(Obstacle);            
            animatorComponent.SetInteger("state(for hit)", 2);
        }
    }
    
    public void NoAnim1()
    {
        rb.velocity = Vector2.zero;
    }
    public void NoAnim2()
    {


        animatorComponent.SetInteger("state(for hit)", 0);

    }
    public void Die()
    {


        Destroy(gameObject);

    }
}