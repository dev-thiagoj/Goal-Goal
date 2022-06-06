using UnityEngine;
using DevUtills.Core.Singleton;

public class BallBase : Singleton<BallBase>
{
    private Vector3 speed = new Vector3(1, 1, 0);
    private Vector3 startSpeed;
    public GameObject ball;
    public GameObject midField;
    public Vector3 midFieldPos;
    public int boundary = 1000;

    [Header("Limits")]
    //public Vector2 limitsX = new Vector2(-4f, 4f);
    public Vector2 limitsY = new Vector2(-4f, 4f);

    [Header("Randomization")]
    public Vector2 randSpeedY = new Vector2(1, 10);
    public Vector2 randSpeedX = new Vector2(1, 10);

    private Vector3 _startPosition;
    public bool canMove = false;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _startPosition = transform.position;
        speed = new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), 0);
    }

    //adiciona movimento a ball
    void Update()
    {
        if (!canMove) return;

        else
        {
            transform.Translate(100 * Time.deltaTime * speed);

            Boundary(true);

            if (speed.x == 0)
            {
                speed.x = Random.Range(-15, 15);
            }
            else if (speed.y == 0)
            {
                speed.y = Random.Range(-15, 15);
            }
        }
    }

    //inverte o deslocamento da ball qdo colide com as bordas e/ou player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPlayerCollision();
        }

        else if (collision.gameObject.CompareTag("Wall"))
        {
            speed.y *= -1;
        }

        else return;

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if (hit.gameObject.CompareTag("Player")) OnPlayerCollision();
    }

    private void OnPlayerCollision()
    {
        speed.x *= -1;

        float rand = Random.Range(randSpeedX.x, randSpeedX.y);

        if (speed.x < 0)
        {
            rand *= -1;
        }

        speed.x = rand;

        rand = Random.Range(randSpeedY.x, randSpeedY.y);
        speed.y = rand;
    }

    public void Boundary(bool b)
    {
        b = false;

        if (ball.transform.position.y > boundary || ball.transform.position.y < -boundary)
        {
            b = true;

            if (b == true)
            {
                Invoke(nameof(ResetBall), 2);
            }
        }
        else
        {
            return;
        }
    }

    public void ResetBall()
    {
        transform.position = _startPosition;
        speed = new Vector2(Random.Range(-15, 15), Random.Range(-15, 15));
    }

    public void CanMove(bool state)
    {
        canMove = state;
    }
}
