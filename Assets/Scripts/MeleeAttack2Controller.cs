using UnityEngine;

public class MeleeAttack2Controller : MonoBehaviour
{
    public Transform AttackPoint;
    public LayerMask DamageableLayerMask;
    public float Damage;
    public float AttackRange;
    public float TimeBtwAttack;

    private Animator _animator;
    private float _timer;
    private void Start()
    {
        
        _animator = gameObject.GetComponent<Animator>();
        GetReferences();
    }

    private void Update()
    {
        Attack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

    private void Attack()
    {
        float Fire2Input = Input.GetAxis("Fire2");
        if (_timer <= 0)
        { 
            if (Fire2Input > 0) 
            {
                _animator.SetInteger("state(for attck2)", 1);
                Collider2D[] enemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, DamageableLayerMask);

                if (enemies.Length != 0)
                {
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].GetComponent<DamageableObject2>().TakeDamage(Damage);
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
    private void NoAnim()
    {
        _animator.SetInteger("state(for attck2)", 0);
    }
    private void GetReferences()
    {
        _animator = GetComponent<Animator>();
    }
}