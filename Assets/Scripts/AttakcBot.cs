using UnityEngine;

public class AttakcBot: MonoBehaviour
{
    public Transform AttackPoint;
    public LayerMask DamageableLayerMask;
    public float Damage;
    public float AttackRange;
    public float TimeBtwAttack;

    private Animator animatorComponent;
    private float _timer;

    private void Start()
    {
        animatorComponent = gameObject.GetComponent<Animator>();
        GetReferences();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

 void OnTriggerStay2D(Collider2D col)
    {
        if (_timer <= 0)
        {
            if (col.GetComponent<Collider2D>().tag == "Player") 
            {
               

                Collider2D[] enemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, DamageableLayerMask);

                if (enemies.Length != 0)
                {
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].GetComponent<DamageableObject>().TakeDamage(Damage);
                    }
                }

                _timer = TimeBtwAttack;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<Collider2D>().tag == "Player")
        {
            animatorComponent.SetInteger("state(for attack)", 0); 
        }
    }

    private void GetReferences()
    {
        animatorComponent = GetComponent<Animator>();
    }
}