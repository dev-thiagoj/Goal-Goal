using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Player player; 
   
    private readonly float speed = 40;
    public Image uiPlayer;
    public string playerName;
    //public Vector3 initialPosition;

    [Header("Limits")]
    public Vector2 limitsX = new Vector2(-4f, 4f);
    public Vector2 limitsY = new Vector2(-4f, 4f);

    [Header("Key Setup")]
    public KeyCode KeyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode KeyCodeMoveDown = KeyCode.DownArrow;
    public KeyCode KeyCodeMoveLeft = KeyCode.LeftArrow;
    public KeyCode KeyCodeMoveRight = KeyCode.RightArrow;

    [Header("Texts")]
    public TextMeshProUGUI uiTextPoints;
    //public TextMeshProUGUI uiTextEndGame;

    /*[Header("Boundaries")]
    public float leftBound;
    public float rightBound;*/

    public GameManager gameManager;
    public Rigidbody2D myRigidBody2d;
    public int currentPoints;

    private Vector3 _pos;
    


    private void Awake()
    {
        
        ResetPlayer();
        //initialPosition = transform.position;
    }

    void Update()
    {
        Bounds();
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

        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCodeMoveUp)) moveY = +1f;
        if (Input.GetKey(KeyCodeMoveDown)) moveY = -1f;
        if (Input.GetKey(KeyCodeMoveRight)) moveX = +1f;
        if (Input.GetKey(KeyCodeMoveLeft)) moveX = -1f;

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;

        transform.position += 20 * speed * Time.deltaTime * moveDir;

    }

    public void Bounds()
    {
        _pos.y = myRigidBody2d.transform.position.y;
        _pos.x = myRigidBody2d.transform.position.x;

        if (_pos.x < limitsX.x) _pos.x = limitsX.x;
        else if (_pos.x > limitsX.y) _pos.x = limitsX.y;

        if (_pos.y < limitsY.x) _pos.y = limitsY.x;
        else if (_pos.y > limitsY.y) _pos.y = limitsY.y;

        myRigidBody2d.transform.position = _pos;
    }
    
    /*public void SetName(string s)
    {
        player.name = s;
    }*/

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
            //player.name = (string) playerName;
            gameManager.ChangeStateToEnd();
        }
    }
}
