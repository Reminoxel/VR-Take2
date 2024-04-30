using UnityEngine;

public class RecyclerEnemy : MonoBehaviour
{
    public float proximityRange = 5f;
    public float attackRange = 2f;
    public float movementSpeed = 2f;

    private Animator animator;
    private Transform player;
    private bool isPlayerInRange = false;

   
    void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>().transform;
        animator.Play("Recycler.Idle.Gnawing");
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        animator.SetBool("ProximityRangeReached", isPlayerInRange);

        animator.SetBool("AttackRangeReached", distanceToPlayer < attackRange);


        if (!isPlayerInRange)
        {

            animator.Play("Recycler.Idle.Gnawing");

            if (distanceToPlayer < proximityRange)
            {
                isPlayerInRange = true;
                animator.SetTrigger("PlayerInRange");
            }
        }
        else
        {
            animator.Play("Recycler.Walk.Forward");
            transform.LookAt(player);

            if (distanceToPlayer < attackRange)
            {
                animator.Play("Recycler.Attack.Standard");
                player.GetComponent<PlayerController>().TakeDamage();
            }
            else
            {
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
        }
    }

    public void TakeDamage()
    {
        //dies after one hit
        isPlayerInRange = false;
        animator.Play("Recycler.Damage.Die");

        Destroy(gameObject, 2f); 
    }
}