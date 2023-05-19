using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cart : MonoBehaviour
{
    [Header("Movment")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float vehicleWidth;


    [Header("Wheel")]
    [SerializeField] private Transform[] wheels;
    [SerializeField] private float wheelRadius;

    //[SerializeField] private CoinSpawner coinSpawner;

    [HideInInspector] public UnityEvent CollisionStone;

    private Vector3 movementTarget;
    private float deltaMovment;
    private float lastPositionX;
    private float timer;

    static public bool protect;

    private void Start()
    {
        movementTarget = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Stone stone = collision.transform.root.GetComponent<Stone>();

        if (protect == false)
        {
            if (stone != null)
            {
                CollisionStone.Invoke();            
            }
        }
            
    }

    private void Update()
    {

        if (protect == true)
        {
            timer += 1f * Time.deltaTime;

            if (timer >= 5)
            {
                protect = false;
                timer = 0f * Time.deltaTime;
            }
        }

        Move();

        RotateWheel();
    }

    private void Move()
    {
        lastPositionX = transform.position.x;
        transform.position = Vector3.MoveTowards(transform.position, movementTarget, movementSpeed * Time.deltaTime);
        deltaMovment = transform.position.x - lastPositionX;
    }

    private void RotateWheel()
    {
        float angel = (180 * deltaMovment) / (Mathf.PI * wheelRadius * 2);

        for(int i = 0; i < wheels.Length;i++)
        {
            wheels[i].Rotate(0, 0, -angel);
        }
    }

    public void SetMovementTarget(Vector3 target)
    {
        movementTarget = ClampMovmentTarget(target);
    }

    private Vector3 ClampMovmentTarget(Vector3 target)
    {
        float leftBorder = LevelBoundary.Instantce.LeftBorder + vehicleWidth * 0.5f;
        float rightBorder = LevelBoundary.Instantce.RightBorder - vehicleWidth * 0.5f;

        Vector3 movTarget = target;

        movTarget.z = transform.position.z;
        movTarget.y = transform.position.y;

        if (movTarget.x < leftBorder) movTarget.x = leftBorder;
        if (movTarget.x > rightBorder) movTarget.x = rightBorder;

        return movTarget;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position - new Vector3(vehicleWidth * 0.5f, 0.5f, 0), transform.position + new Vector3(vehicleWidth * 0.5f, -0.5f, 0));
    }

#endif
}
