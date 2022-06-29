using UnityEngine;
using DevUtills.Core.Singleton;
using System.Collections.Generic;

public class BallBase : Singleton<BallBase>
{
    private Vector3 speed = new Vector3(1, 1, 0);
    [SerializeField] private List<int> rangeSpeed;
    public GameObject ball;
    //public GameObject midField;
    //public Vector3 midFieldPos;

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
        //speed = new Vector3(Random.Range(-10f, randSpeedX.y), Random.Range(randSpeedY.x, randSpeedY.y));

        rangeSpeed.Add(-1);
        rangeSpeed.Add(1);
        rangeSpeed.Add(0);

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

            if (speed.x == 0) ResetBall();
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
        speed.x *= -1.2f;

        float rand = Random.Range(randSpeedY.x, randSpeedY.y);
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
    }

    public void ResetBall()
    {
        transform.position = _startPosition;

        speed.x = rangeSpeed[Random.Range(0, rangeSpeed.Count)];
        speed = new Vector2(speed.x * Random.Range(1, 3), 0);
    }

    public void CanMove(bool state)
    {
        canMove = state;
    }
}
