using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //animatör
    Animator animator;
    int isWalkingHash;

    public Transform attackPoint;
    public float attackRange;
    public int attackDamage;

    public LayerMask enemyLayers;


    private InputHandler _input;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private bool rotateTowardsMouse;

    [SerializeField]
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<InputHandler>();

        //animatör component
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        //koşma animasyonu execute
        bool forwardPressed = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d");
        bool isWalking = animator.GetBool(isWalkingHash);
        
        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        //dodge animasyonu execute
        if (Input.GetKeyDown("space"))
        {
            Dodge();
        }

//---------------------------------------------------kılıç saldırı animasyonu execute-------------------------------------------------------------//

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Attack
                Attack();
            }

        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        var movementVector = MoveTowardTarget(targetVector);

        if (!rotateTowardsMouse)
            RotateTowardMovementVector(movementVector);
        else
            RotateTowardMouseVector();
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        FMODUnity.RuntimeManager.PlayOneShot("event:/link_sword");
        //Enemy detector
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //Damage
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Link hits " + enemy.name);
            enemy.GetComponent<EnemyBehaviour>().TakeDamage(attackDamage);
        }
    }


    void Dodge()
    {
        animator.SetTrigger("Dodge");
    }

    private void RotateTowardMouseVector()
    {
        Ray ray = cam.ScreenPointToRay(_input.MousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0) { return; }

        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;


        targetVector = Quaternion.Euler(0, cam.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;

        return targetVector;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
