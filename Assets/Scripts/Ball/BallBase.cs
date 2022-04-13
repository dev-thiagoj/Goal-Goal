using UnityEngine;

public class BallBase : MonoBehaviour
{
    private Vector3 speed = new Vector3(1, 1, 0);
    private Vector3 startSpeed;
    public GameObject ball;
    public int boundary = 1000;
    //private Player player;

    [Header("Randomization")]
    public Vector2 randSpeedY = new Vector2(1, 10);
    public Vector2 randSpeedX = new Vector2(1, 10);

    private Vector3 _startPosition;
    public bool _canmove = false;

    private void Awake()
    {
        ball.SetActive(false);
        _startPosition = transform.position;
        speed = new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), 0);
        startSpeed = speed;

        //testar esse para reiniciar posição dos players a cada ResetBall()!!!
        //player = FindObjectOfType<GameObject>().GetComponent<Player>();
    }

    //adiciona movimento a ball
    void Update()
    {
        if (!_canmove) return;

        transform.Translate(100 * Time.deltaTime * speed);
        
        Boundary(true);

        if(speed.x == 0)
        {
            speed.x = Random.Range(-15, 15);
        }
        else if (speed.y == 0)
        {
            speed.y = Random.Range(-15, 15);
        }
        
    }

    //inverte o deslocamento da ball qdo colide com as bordas e/ou player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            OnPlayerCollision();
        }

        else if(collision.gameObject.CompareTag("Wall"))
        {
            speed.y *= -1;
        }

        else return;

    }

    private void OnPlayerCollision()
    {
        speed.x *= -1;

        float rand = Random.Range(randSpeedX.x, randSpeedX.y);

        if(speed.x < 0)
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
            
            if(b == true)
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
        speed = new Vector2(Random.Range(-15, 15), Random.Range(-15, 15)).normalized;
        //player.transform.position = player.initialPosition;
    }

    public void CanMove(bool state)
    {
        _canmove = state;
    }
}
