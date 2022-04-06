using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Test_RayCast : MonoBehaviour
{
    public Player player;

    private float speed = 40;
    public Image uiPlayer;
    public string playerName;
    public Vector3 initialPosition;

    [Header("Key Setup")]
    public KeyCode KeyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode KeyCodeMoveDown = KeyCode.DownArrow;
    public KeyCode KeyCodeMoveLeft = KeyCode.LeftArrow;
    public KeyCode KeyCodeMoveRight = KeyCode.RightArrow;

    [Header("Texts")]
    public TextMeshProUGUI uiTextPoints;
    public TextMeshProUGUI uiTextEndGame;

    [Header("Boundaries")]
    public float leftBound;
    public float rightBound;

    public GameManager gameManager;
    public Rigidbody2D myRigidBody2d;
    public int currentPoints;


    private void Awake()
    {
        ResetPlayer();
        initialPosition = transform.position;
    }

    void Start()
    {

        //player.transform.position = initialPosition;
    }

    void Update()
    {
        /*if (myRigidBody2d.position.x < leftBound)
        {
            player.transform.position = new Vector2(this.leftBound, transform.position.y);
        }

        if (myRigidBody2d.position.x > rightBound)
        {
            player.transform.position = new Vector2(this.rightBound, transform.position.y);
        }*/

        PlayerMovement();

        FinalPoint();
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }

    private void PlayerMovement()
    {

        if (Input.GetKey(KeyCodeMoveUp))
        {
            myRigidBody2d.MovePosition(transform.position + transform.up * speed * Time.deltaTime * 100);
        }
        else if (Input.GetKey(KeyCodeMoveDown))
        {
            myRigidBody2d.MovePosition(transform.position + transform.up * -speed * Time.deltaTime * 100);
        }
        else if (Input.GetKey(KeyCodeMoveLeft))
        {
            myRigidBody2d.MovePosition(transform.position + transform.right * -speed * Time.deltaTime * 100);
        }
        else if (Input.GetKey(KeyCodeMoveRight))
        {
            myRigidBody2d.MovePosition(transform.position + transform.right * speed * Time.deltaTime * 100);
        }


    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("RightBound"))
        {            
            transform.position = new Vector2(rightBopund, transform.position.y);
        }

        if (collision.transform.CompareTag("LeftBound"))
        {            
            transform.position = new Vector2(leftBound, transform.position.y);
        }
       
    }*/

    public void SetName(string s)
    {
        playerName = s;
    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }

    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    public void FinalPoint()
    {
        if (currentPoints == gameManager.endPoint)
        {
            gameManager.ChangeStateToEnd();
        }
    }
}
