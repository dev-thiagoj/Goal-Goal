using UnityEngine;
using DevUtills.Core.Singleton;

public class BallBase : Singleton<BallBase>
{
    private Vector3 speed = new Vector3(1, 1, 0);
    private Vector3 startSpeed;
    public GameObject ball;
    public GameObject midField;
    public Vector3 midFieldPos;

    [Header("Limits")]
    public int safeBoundary = 1000;

    [Header("Randomization")]
    public Vector2 randSpeedX;
    public Vector2 randSpeedY;

    private Vector3 _startPosition;
    public bool canMove = false;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _startPosition = transform.position;
        //speed = new Vector3(Random.Range(randSpeedX.x, randSpeedX.y), Random.Range(randSpeedY.x, randSpeedY.y));
        ResetBall();

    }

    //adiciona movimento a ball
    void Update()
    {
        if (!canMove) return;

        else
        {
            transform.Translate(Time.deltaTime * speed);

            Boundary(true);

            if (speed.x == 0)
            {
                speed.x = Random.Range(randSpeedX.x, randSpeedX.y);
            }
            else if (speed.y <= 0.1 && speed.y >= -0.1)
            {
                speed.y = Random.Range(randSpeedY.x, randSpeedY.y);
            }
        }
    }

    //inverte o deslocamento da ball qdo colide com as bordas e/ou player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            speed.y *= -1;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            OnPlayerCollision();
        }
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

        if (ball.transform.position.y > safeBoundary || ball.transform.position.y < -safeBoundary)
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
        speed = new Vector3(Random.Range(randSpeedX.x, randSpeedX.y), Random.Range(randSpeedY.x, randSpeedY.y));
    }

    public void CanMove(bool state)
    {
        canMove = state;
    }
}
