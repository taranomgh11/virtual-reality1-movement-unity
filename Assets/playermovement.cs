using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
   
public GameObject pathPrefab; 
    public float initialSpeed = 2.0f; // سرعت اولیه  
    public float speedIncrease = 0.2f;  
    public float moveDistance = 1.0f;  
    private float currentSpeed; 
    private Vector3 lastPathPosition; 
    private bool hasPath = false; 



    public float moveSpeed = 5f; // سرعت حرکت پلیر  
    public float jumpForce = 300f; 
    private bool isGrounded; 
    private Rigidbody rb;  






    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = initialSpeed;  
        rb = GetComponent<Rigidbody>();  
   



    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 newPosition = transform.position;

        
        if (Input.GetKey(KeyCode.W))   
        {  
            newPosition += transform.forward * currentSpeed * Time.deltaTime; 
            currentSpeed += speedIncrease * Time.deltaTime; 
        }   

    
        if (Input.GetKey(KeyCode.A))   
        {  
            newPosition -= transform.right * Time.deltaTime;  
        }  

        
        if (Input.GetKey(KeyCode.D))   
        {  
            newPosition += transform.right * Time.deltaTime; 
        }  



        // ایجاد مسیر  
        if (newPosition != transform.position)  
        {  
            transform.position = newPosition;  

            
            if (!hasPath)  
            {  
                lastPathPosition = transform.position; 
                lastPathPosition.y = 0; 
                Instantiate(pathPrefab, lastPathPosition, Quaternion.identity); 
                hasPath = true; 
            }  
            else  
            {  
                
                if (Vector3.Distance(lastPathPosition, transform.position) >= moveDistance)  
                {  
                    lastPathPosition = transform.position; 
                    lastPathPosition.y = 0;
                    Instantiate(pathPrefab, lastPathPosition, Quaternion.identity); 
                }  
            }  
        } 



         // حرکت
        float moveHorizontal = Input.GetAxis("Horizontal");  
        float moveVertical = Input.GetAxis("Vertical");  
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);  
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);  
        
        // پرش  
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)  
        {  
            Jump();  
        }  




    }



      private void OnCollisionEnter(Collision collision)  
    {  
         
        if (collision.collider.CompareTag("Ground"))  
        {  
            isGrounded = true; 
        }  
    }  

    private void OnCollisionExit(Collision collision)  
    {  
        
        if (collision.collider.CompareTag("Ground"))  
        {  
            isGrounded = false; 
        }  
    }  

    private void Jump()  
    {  
    
        rb.AddForce(Vector3.up * jumpForce);  
    }  




}


//برای گیت هاب
