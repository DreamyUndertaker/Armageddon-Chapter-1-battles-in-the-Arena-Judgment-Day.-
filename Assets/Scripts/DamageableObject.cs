using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DamageableObject : MonoBehaviour
{
    private Animator animatorComponent;
    public int sceneIndex;
    public float StartHealth;
      [SerializeField] private LayerMask health;
    [SerializeField] private LayerMask health2;
    private Collider2D coll;
    public GameObject Health;
    public GameObject Health2; 
    [SerializeField] private LayerMask spikes;
    [SerializeField] private float _healthPoints;
    void Start()
    {
        StartHealth = _healthPoints;
        animatorComponent = gameObject.GetComponent<Animator>();
       


        coll = gameObject.GetComponent<Collider2D>();



    }
    
    public void TakeDamage(float damage)
    {
      
        _healthPoints -= damage;
       animatorComponent.SetInteger("state( for take hit)", 1);
        

         if (_healthPoints <= 0)
         {
            gameObject.GetComponent<Test>().enabled = false;

            animatorComponent.SetInteger("state( for take hit)", 2);
           
         }
         
       

    }
    void Update()
      { 
        if (coll.IsTouchingLayers(spikes))
        {
            _healthPoints = 0;
            animatorComponent.SetInteger("state( for take hit)", 2);
            gameObject.GetComponent<Test>().enabled = false;
        }
        if (coll.IsTouchingLayers(health) && Input.GetKey(KeyCode.E))
        {
            _healthPoints = _healthPoints + (StartHealth - _healthPoints);
            Destroy(Health);
        }
        if (coll.IsTouchingLayers(health2) && Input.GetKey(KeyCode.E))
        {
            _healthPoints = _healthPoints + (StartHealth - _healthPoints);
            Destroy(Health2);
        }

        GameObject.Find("HP").GetComponent<Image>().fillAmount = _healthPoints / StartHealth;
      }

    private void NoAnim()
    {
        animatorComponent.SetInteger("state( for take hit)", 0); 
    }
    private void Scene()
    { 
        SceneManager.LoadScene(sceneIndex);
    }
   
}