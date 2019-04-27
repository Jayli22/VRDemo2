using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotScript : MonoBehaviour
{
    private Animator animator;
    private Collider tcollider;
    private bool alive = true;
    [SerializeField]
    private int hp;
    private Vector3 move_direction;
    GameObject target;
    private CharacterController characterController;
    private bool attackable = false;
    private NavMeshAgent navMeshAgent;
    private Timer attackcooldown_timer;
    // Start is called before the first frame update
    void Start()
    {
        attackcooldown_timer = gameObject.AddComponent<Timer>();
        animator = GetComponent<Animator>();
        tcollider = GetComponent<CapsuleCollider>();
        characterController = GetComponent<CharacterController>();
        target = GameObject.Find("EnergyTower");
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        attackcooldown_timer.Duration = 1.5f;
        attackcooldown_timer.Run();

    }

    // Update is called once per frame
    void Update()
    {
        if(alive)
        {
            
            move_direction = target.transform.position - transform.position;
            move_direction.y = 0;
           // characterController.Move(move_direction * Time.deltaTime /3);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move_direction), Time.deltaTime * 10);
            AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);

            if (attackable && !stateinfo.IsName("attack")&& attackcooldown_timer.Finished == true)
            {
                Attack();
                target.GetComponent<TowerScript>().GetAttacked(20);
                attackcooldown_timer.Run();
            }
            navMeshAgent.SetDestination(target.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            TakeDamage();
        }
        if(collision.transform.tag == "EnergyTower")
        {
            attackable = true;
            navMeshAgent.isStopped = true ;
           // navMeshAgent.Stop();
        }
    }
    public void TakeDamage()
    {
        hp -= 10;
        if (hp <= 0)
        {
            tcollider.enabled = false;
            characterController.enabled = false;
            navMeshAgent.isStopped = true;
            alive = false;
            animator.SetTrigger("Die");
        }
    }
    public void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
