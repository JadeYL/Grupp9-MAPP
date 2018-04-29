using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerMovment : MonoBehaviour
{
    public float moveSpeed = 05f;
    public VJHandler jsMovement;
    private Vector3 direction;
    public Sprite NORTHWEST, NORTH, NORTHEAST, WEST, EAST, SOUTHWEST, SOUTH, SOUTHEAST;
    public GameObject hitArea;
    private int facingDirection;
    private int i = 0;
    private int i2 = 0;
    float placeholderX;
    float placeholderY;
    Vector3 lastDirection;
    public Rigidbody2D rb;
    Vector3 targetDash;
    public bool isDashing = false;
    bool dashingOnCooldown = false;
    public float dashCooldown = 4;
    public Text dashButton;
    public int hp;
    public bool fireOrb = false;
    BoxCollider2D lel;






    void Update()
    {
       // Debug.Log(hp);
        float oldX = transform.position.x;
        float oldY = transform.position.y;
    

       
        direction = jsMovement.InputDirection;
        if (direction.x != 0 && direction.y != 0)
        {
           lastDirection = direction;
        }
        targetDash = direction * 2;
        if (dashingOnCooldown == true)
        {
            dashCooldown -= Time.deltaTime;
            int tempNum = (int)dashCooldown + 1;
            dashButton.text = tempNum.ToString();
            if (dashCooldown <= 0)
            {
                dashButton.text = "B";
                dashCooldown = 4;
                dashingOnCooldown = false;
            }
        }

        if (Input.GetKeyDown("w"))
        {
         
            dash();

        }

        if (direction.magnitude != 0 && isDashing == false)
        {
            transform.position += direction * moveSpeed;
            jsMovement.angle = Mathf.Atan2((transform.position.x - oldX), (transform.position.y - oldY)) * Mathf.Rad2Deg;
            calculateAngle();
        }

    }
    void FixedUpdate()
    {
        if (isDashing)
        {
            i2++;
            lel.enabled = !enabled; 
            if (i2 == 10)
            {
                
                rb.velocity = Vector2.zero;
                isDashing = false;
                i2 = 0;
                dashingOnCooldown = true;
                lel.enabled = true;
            }
                
        

        }
    }


    public void switchArea(int direction)
    {
        switch (direction)
        {
            case 1:
                hitArea.transform.localPosition = new Vector3(-0.1f, 0.1f);
                hitArea.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -135));
                break;
            case 2:
                hitArea.transform.localPosition = new Vector3(0, 0.1f);
                hitArea.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -180));
                break;
            case 3:
                hitArea.transform.localPosition = new Vector3(0.1f, 0.1f);
                hitArea.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 135));
                break;
            case 4:
                hitArea.transform.localPosition = new Vector3(-0.1f,0);
                hitArea.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -90));

                break;
            case 5:
                hitArea.transform.localPosition = new Vector3(0.1f, 0);
                hitArea.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));

                break;
            case 6:
                hitArea.transform.localPosition = new Vector3(-0.1f, -0.1f);
                hitArea.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -45));

                break;
            case 7:
                hitArea.transform.localPosition = new Vector3(0, -0.1f);
                hitArea.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
          
                break;
            case 8:
                hitArea.transform.localPosition = new Vector3(0.1f, -0.1f);
                hitArea.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 45));

                break;

        }
            
    }
    public void calculateAngle()
    {
        if (direction.magnitude != 0)
        {

            //  
            if (jsMovement.angle > -67 && jsMovement.angle < -22)
            {
                //Debug.Log("NorthWest");
                this.GetComponent<SpriteRenderer>().sprite = NORTHWEST;
                switchArea(1);
            }

            else if (jsMovement.angle > -22 && jsMovement.angle < 22)
            {
                //  Debug.Log("North");
                this.GetComponent<SpriteRenderer>().sprite = NORTH;
                switchArea(2);
            }
            else if (jsMovement.angle > 22 && jsMovement.angle < 67)
            {
                //    Debug.Log("NorthEast");
                this.GetComponent<SpriteRenderer>().sprite = NORTHEAST;
                switchArea(3);
            }
            else if (jsMovement.angle > -112 && jsMovement.angle < -67)
            {
                //Debug.Log("West");
                this.GetComponent<SpriteRenderer>().sprite = WEST;
                switchArea(4);
            }
            else if (jsMovement.angle > 67 && jsMovement.angle < 112)
            {
                //Debug.Log("East");
                this.GetComponent<SpriteRenderer>().sprite = EAST;
                switchArea(5);
            }
            else if (jsMovement.angle > -157 && jsMovement.angle < -112)
            {
                //Debug.Log("SouthWest");
                this.GetComponent<SpriteRenderer>().sprite = SOUTHWEST;
                switchArea(6);
            }
            else if (jsMovement.angle > 157 || jsMovement.angle <= (-157))
            {
                //Debug.Log("South");
                this.GetComponent<SpriteRenderer>().sprite = SOUTH;
                switchArea(7);
            }
            else if (jsMovement.angle > 112 && jsMovement.angle < 156)
            {
                // Debug.Log("SouthEast");
                this.GetComponent<SpriteRenderer>().sprite = SOUTHEAST;
                switchArea(8);
            }
        }
    }
    public void dash()
    {
        if (dashingOnCooldown == false)
        {
            isDashing = true;
            rb.velocity = direction * 15f; 
        }
    }
    public void hitbox()
    {
        
        if (i == 0)
        {
            hitArea.active = false;
            i = 1;
        }
        else if (i == 1)
        {
            hitArea.active = true;
            i = 0;
        }
    }
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = SOUTH;
        float cooldownTime = Time.deltaTime;
        hp = 10;
        lel = this.GetComponent<BoxCollider2D>();
    }
}



