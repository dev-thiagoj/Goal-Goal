using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Player player; 
   
    private float speed = 40;
    public Image uiPlayer;
    public string playerName;
    //public Vector3 initialPosition;

    [Header("Limits in X")]
    public Vector2 limitsX = new Vector2(-4f, 4f);

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

    private Vector3 _pos;


    private void Awake()
    {
        ResetPlayer();
        //initialPosition = transform.position;
    }

    void Start() {
        
        //player.transform.position = initialPosition;
    }

    void Update()
    {
        _pos.y = myRigidBody2d.transform.position.y;
        _pos.x = myRigidBody2d.transform.position.x;

        if (_pos.x < limitsX.x) _pos.x = limitsX.x;
        else if (_pos.x > limitsX.y) _pos.x = limitsX.y;

        myRigidBody2d.transform.position = _pos;

        PlayerMovement();
        FinalPoint();
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }

    private void PlayerMovement(){

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
