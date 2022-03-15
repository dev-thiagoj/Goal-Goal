using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Player player;
    //public Player player02;

    public Vector2 initialPosition;
    private float speed = 40;
    public Image uiPlayer;
    public string playerName;

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
        player.transform.position = initialPosition;
    }


    void Update()
    {
        if (player.transform.position.x < leftBound)
        {
            player.transform.position = new Vector3(leftBound, transform.position.y);
        }

        if (player.transform.position.x > rightBound)
        {
            player.transform.position = new Vector3(rightBound, transform.position.y);
        }   
        
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

    /*public void Player02Movement(){

        if(player02.myRigidBody2d.position.x < rightBound && player01.myRigidBody2d.position.x > leftBound){

            if (Input.GetKey(KeyCodeMoveUp))
            {
                player02.myRigidBody2d.MovePosition(transform.position + transform.up * speed * Time.deltaTime * 100);
            }
            else if (Input.GetKey(KeyCodeMoveDown))
            {
                player02.myRigidBody2d.MovePosition(transform.position + transform.up * -speed * Time.deltaTime * 100);
            }
            else if (Input.GetKey(KeyCodeMoveLeft))
            {
                player02.myRigidBody2d.MovePosition(transform.position + transform.right * -speed * Time.deltaTime * 100);
            }
            else if (Input.GetKey(KeyCodeMoveRight))
            {
                player02.myRigidBody2d.MovePosition(transform.position + transform.right * speed * Time.deltaTime * 100);
            }

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
