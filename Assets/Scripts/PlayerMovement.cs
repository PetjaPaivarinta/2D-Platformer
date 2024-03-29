using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public BulletLogic bulletLogic;

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    public Tilemap tilemap;
    public Tile tile;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundCheckRadius = 0.2f;
    [SerializeField]

    private float movementSpeed = 2f;

    public Cinemachine.CinemachineVirtualCamera cinemachineCamera;
    
    [SerializeField]
     private float jumpForce = 15f;

    [SerializeField]
      private LayerMask collisionMask;

       [SerializeField]
       private int maxJumps = 2;

       private float runningSpeed = 10f;

        private int _jumpsLeft;

        private float healthPoints = 3f;

        public bool facingRight = true;
public float moveInput;



    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _jumpsLeft = maxJumps;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            jumpForce = 20;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            StartCoroutine(ExecuteAfterTime(5));
            jumpForce = 15;
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.FindWithTag("lAVA").SetActive(false);
    }

    void Update()
    {
          moveInput = Input.GetAxis("Horizontal");

         if (Input.GetMouseButton(0))
    {
        Debug.Log("Mouse Clicked");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPos = tilemap.WorldToCell(mousePos);
        tilemap.SetTile(gridPos, tile);
    }
    if (Input.GetMouseButton(1))
    {
        Debug.Log("Mouse Clicked");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPos = tilemap.WorldToCell(mousePos);
        tilemap.SetTile(gridPos, null);
    }
          

    if (facingRight == false && moveInput > 0)
    {
        Flip();
    }
    else if (facingRight == true && moveInput < 0)
    {
        Flip();
    }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = runningSpeed;
        }
        else
        {
            movementSpeed = 2f;
        }
        var inputX = Input.GetAxisRaw("Horizontal");
        var jumpInput = Input.GetButtonDown("Jump");

        _rigidbody.velocity = new Vector2(inputX * movementSpeed, _rigidbody.velocity.y);


        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 0)
        {
     if (IsGrounded() && _rigidbody.velocity.y <= 0)
        {
            _jumpsLeft = maxJumps;
        }

        if (jumpInput && _jumpsLeft > 0)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            _jumpsLeft -= 1;
        }
        if (transform.position.y >= 75)
        {
            GameObject[] lAVA = GameObject.FindGameObjectsWithTag("lAVA");
            foreach (GameObject l in lAVA)
            {
                Destroy(l);
            }
        }
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (IsGrounded() && _rigidbody.velocity.y <= 0)
            {
                _jumpsLeft = 1;
            }

            if (jumpInput && _jumpsLeft > 0)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
                _jumpsLeft -= 1;
            }
        }
    
    }
    void Flip()
{
    facingRight = !facingRight;
    Vector3 Scaler = transform.localScale;
    Scaler.x *= -1;
    transform.localScale = Scaler;
}

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionMask);
    }

private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Coin"))
    {
        Destroy(collision.gameObject);
    }
    if (collision.gameObject.CompareTag("Ammo"))
    {
        Destroy(collision.gameObject);
        bulletLogic.ammoCount += 5;
        bulletLogic.UpdateAmmoText();
    }
    if (collision.gameObject.CompareTag("Potion"))
    {
        Destroy(collision.gameObject);
        healthPoints += 1;
        Debug.Log(healthPoints);
        if (healthPoints == 3)
        {
            Heart3.SetActive(true);
            Debug.Log("Heart 3");
        }
        else if (healthPoints == 2)
        {
            Heart2.SetActive(true);
            Debug.Log("Heart 2");
        }
    }
    if (collision.gameObject.CompareTag("EnemyBullet"))
    {
        Destroy(collision.gameObject);
        healthPoints -= 1;
        if (healthPoints == 2)
        {
            Heart3.SetActive(false);
        }
        else if (healthPoints == 1)
        {
            Heart2.SetActive(false);
        }
        else if (healthPoints <= 0)
        {
            Heart1.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Destroy(gameObject);
        }
    }
    if (collision.gameObject.CompareTag("lAVA")) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject);
    
    }
    if (collision.gameObject.CompareTag("Boost"))
    {
        jumpForce = 70;
    }
}

private void OnTriggerExit2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Boost"))
    {
        jumpForce = 15;
    }
}


private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Enemy"))
    {
        healthPoints -= 1;
        if (healthPoints == 2) 
        {
          GameObject heart3 = GameObject.FindWithTag("Heart3");
          heart3.SetActive(false);
        
        } 
        else if (healthPoints == 1) 
        {
            GameObject heart2 = GameObject.FindWithTag("Heart2");
            heart2.SetActive(false);
        }
        else if (healthPoints <= 0) 
        {
            GameObject heart1 = GameObject.FindWithTag("Heart1");
            heart1.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Destroy(gameObject);
        }
    }
}
}