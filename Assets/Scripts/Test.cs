using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour {
    /**
    ** Ускорение игрока
    **/
  [Header("Player velocity")]
    // Ось Ox
    public int xVelocity = 5;
    // Ось Oy
    public int yVelocity = 8;

    [SerializeField] private LayerMask ground;

    private Rigidbody2D rigidBody;
    private Collider2D coll;
    private SpriteRenderer spriteRenderer; 
    private Animator animatorComponent;

    private void Start() 
    {
      rigidBody = gameObject.GetComponent<Rigidbody2D>();
      coll = gameObject.GetComponent<Collider2D>();
      spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      animatorComponent = gameObject.GetComponent<Animator>();
    }
 
    private void Update() 
    {
       
        updatePlayerPosition();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    // Обновляем местоположение игрока
    public void updatePlayerPosition() 
    {
      float moveInput = Input.GetAxis("Horizontal");
      float jumpInput = Input.GetAxis("Jump");
     

      if (moveInput < 0) 
      { // Влево
        rigidBody.velocity = new Vector2(-xVelocity, rigidBody.velocity.y);
        animatorComponent.SetInteger("state(for run)", 1); // Бег
        spriteRenderer.flipX = true;
      } 
      else if (moveInput > 0) 
      { // Вправо
        rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
        animatorComponent.SetInteger("state(for run)", 1); // Бег
        spriteRenderer.flipX = false;
      } 
      else if (coll.IsTouchingLayers(ground)) 
      {
        rigidBody.velocity = Vector2.zero; // Отключение инерции в стороны
        animatorComponent.SetInteger("state(for run)", 0); // Стоим
      }

      if (jumpInput > 0 && coll.IsTouchingLayers(ground)) 
      { 
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, yVelocity);
        animatorComponent.SetInteger("state(for jump)", 1);

      } 
      else if (coll.IsTouchingLayers(ground) && jumpInput <= 0)
      {
        animatorComponent.SetInteger("state(for jump)", 0);
      }
     
    }
   

}