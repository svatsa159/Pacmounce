using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public bool active = true;
    public int walkSpeed = 10;
    public int runSpeed = 15;
    public int randomSpeed = 10;
    public float rotationSpeed = 20.0f;
    public bool reversePatrol = true;
    public Transform[] waypoints;
    public bool requireTarget = true;
    public Transform target;
    public float maxDistance = 100f;
    public NavMeshAgent agent;
    private bool initialGo = false;
    CharacterController characterController;
    private bool executeBufferState = false;
    private bool walkInRandomDirection = false;
    private int estCheckDirection = 0;
    private bool wpCountdown = false;
    private int wpPatrol = 0;
    void Start()
    {
        StartCoroutine(Initialize());
    }
    IEnumerator Initialize()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        initialGo = true;
        yield return null;
    }
    void Update()
    {
        if (!active || !initialGo)
        {
            return;
        }
        else
        {
            AIMove();
        }
    }
    void AIMove()
    {
        if ((!target) && (requireTarget))
        {
            return;
        }
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance<maxDistance)
        {
            chase();
        }
        else
        {
            Patrol();
        }
    }
    void Patrol()
    {
        Vector3 destination = CurrentPath();
        Vector3 moveToward = destination - transform.position;
        float distance = Vector3.Distance(transform.position, destination);
        MoveTowards(moveToward);
        if (distance <= 1.5f)
        {
            NewPath();
        }
    }
    Vector3 CurrentPath()
    {
        return waypoints[wpPatrol].position;
    }
    void NewPath()
    {
        if (!wpCountdown)
        {
            wpPatrol++;
            if (wpPatrol >= waypoints.GetLength(0))
            {
                if (reversePatrol)
                {
                    wpCountdown = true;
                    wpPatrol -= 2;
                }
                else
                {
                    wpPatrol = 0;
                }
            }
        }
        else if (reversePatrol)
        {
            wpPatrol--;
            if (wpPatrol < 0)
            {
                wpCountdown = false;
                wpPatrol = 1;
            }
        }
    }
    void MoveTowards(Vector3 direction)
    {
        direction.y = 0;
        int speed = walkSpeed;
        if (walkInRandomDirection)
        {
            speed = randomSpeed;
        }
        if (executeBufferState)
        {
            speed = runSpeed;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float speedModifier = Vector3.Dot(forward, direction.normalized);
        speedModifier = Mathf.Clamp01(speedModifier);
        direction = forward * speed * speedModifier;
        characterController.Move(direction * Time.deltaTime);
    }
    private void chase()
    {
        agent.SetDestination(target.position);
    }
}