using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
 {
    public float moveSpeed;
    private Rigidbody myRidgidbody;
    public Text Score_text;
    public LayerMask targetMask;
    public int Score = 0;
    private bool Fire = false;
    private Camera mainCamera;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    


    private void Start()
    {
        myRidgidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        SetCountText();
    }




    void Update()
    {


        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;



        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }


        if (Fire == true)
        {
            Ray Gun = new Ray(transform.position , transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(Gun, out hitInfo, 100, targetMask))
            {
                Debug.DrawLine(Gun.origin, hitInfo.point, Color.red);
                var health = hitInfo.collider.GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(10);
                    Score += 100 ;
                    SetCountText();
                }
                else
                {
                  
                }

              
            }
            else
            {
                Debug.DrawLine(Gun.origin, Gun.origin + Gun.direction * 100, Color.green);
            }
        }



        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire = true;
        }
        else
        {
            Fire = false;
        }
    }

  
    void SetCountText()
    {
        Score_text.text = "Score: " + Score.ToString();
    }

    private void FixedUpdate()
    {
        myRidgidbody.velocity = moveVelocity;
    }

}
