﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerMovment : MonoBehaviour
{
    public float moveSpeed;
    private Animator anim;
    public JoystickHandler jsMovement;
    private Vector3 direction;
    public Sprite NORTHWEST, NORTH, NORTHEAST, WEST, EAST, SOUTHWEST, SOUTH, SOUTHEAST;
    public GameObject hitArea;
    public LayerMask layerMask;
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
    bool moving;
    public float dashCooldown = 1.5f;
    private int directionNumber;
    public Text dashButton;


    BoxCollider2D colliderbox;
    public bool fireOrb;

    void Update()

    {

        anim.SetInteger("Direction", directionNumber);
        anim.SetBool("Speed", moving);
        Debug.Log(directionNumber);
        float oldX = transform.position.x;
        float oldY = transform.position.y;
    
       
        direction = jsMovement.InputDirection;
        if (direction.x != 0 && direction.y != 0)
        {
           lastDirection = direction;
        }
        if(direction.x == 0 && direction.y == 0)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }
        targetDash = direction * 2;
        if (dashingOnCooldown == true)
        {
            dashCooldown -= Time.deltaTime;
            int tempNum = (int)dashCooldown + 1;
            dashButton.text = tempNum.ToString();
            if (dashCooldown <= 0)
            {
                dashButton.text = "Dash";
                dashCooldown = 1.5f;
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
            if (Physics2D.Raycast(transform.position,direction, 1f, layerMask) == true)
                colliderbox.enabled = true;
            else
                colliderbox.enabled = !enabled;
            if (i2 == 10)
            {
                
                rb.velocity = Vector2.zero;
                isDashing = false;
                i2 = 0;
                dashingOnCooldown = true;
                colliderbox.enabled = true;
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
                directionNumber = 1;
                switchArea(1);
            }

            else if (jsMovement.angle > -22 && jsMovement.angle < 22)
            {
                //  Debug.Log("North");
                this.GetComponent<SpriteRenderer>().sprite = NORTH;
                directionNumber = 2;
                switchArea(2);
            }
            else if (jsMovement.angle > 22 && jsMovement.angle < 67)
            {
                //    Debug.Log("NorthEast");
                this.GetComponent<SpriteRenderer>().sprite = NORTHEAST;
                directionNumber = 3;
                switchArea(3);
            }
            else if (jsMovement.angle > -112 && jsMovement.angle < -67)
            {
                //Debug.Log("West");
                this.GetComponent<SpriteRenderer>().sprite = WEST;
                directionNumber = 4;
                switchArea(4);
            }
            else if (jsMovement.angle > 67 && jsMovement.angle < 112)
            {
                //Debug.Log("East");
                this.GetComponent<SpriteRenderer>().sprite = EAST;
                directionNumber = 5;
                switchArea(5);
            }
            else if (jsMovement.angle > -157 && jsMovement.angle < -112)
            {
                //Debug.Log("SouthWest");
                this.GetComponent<SpriteRenderer>().sprite = SOUTHWEST;
                directionNumber = 6;
                switchArea(6);
            }
            else if (jsMovement.angle > 157 || jsMovement.angle <= (-157))
            {
                //Debug.Log("South");
                this.GetComponent<SpriteRenderer>().sprite = SOUTH;
                directionNumber = 7;
                switchArea(7);
            }
            else if (jsMovement.angle > 112 && jsMovement.angle < 156)
            {
                // Debug.Log("SouthEast");
                this.GetComponent<SpriteRenderer>().sprite = SOUTHEAST;
                directionNumber = 8;
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
    void Start()
    {
        moving = false;
        this.GetComponent<SpriteRenderer>().sprite = SOUTH;
        float cooldownTime = Time.deltaTime;
        colliderbox = this.GetComponent<BoxCollider2D>();
        anim = gameObject.GetComponent<Animator>();
    }
}



