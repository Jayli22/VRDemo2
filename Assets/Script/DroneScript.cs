using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour
{
    private Animator animator;
    private Collider tcollider;
    private bool alive = true;
    [SerializeField]
    private int hp;
    private Vector3 move_direction;
    GameObject target;
    private CharacterController characterController;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        tcollider = GetComponent<SphereCollider>();
        characterController = GetComponent<CharacterController>();
        target = GameObject.Find("EnergyTower");

    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {

            move_direction = target.transform.position - transform.position;
            move_direction.y = 0;
            characterController.Move(move_direction * Time.deltaTime /5);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move_direction), Time.deltaTime * 10);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            TakeDamage();
        }
        if (collision.transform.tag == "EnergyTower")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            collision.gameObject.GetComponent<TowerScript>().GetAttacked(100);
            Destroy(gameObject);
        }
    }
    public void TakeDamage()
    {
        hp -= 10;
        if (hp <= 0)
        {
            tcollider.enabled = false;
            characterController.enabled = false;
            alive = false;
            //animator.SetTrigger("Die");
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
