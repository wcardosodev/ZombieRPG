using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Animator anim;

    int floorMask;                     
    float camRayLength = 100f;

    Rigidbody rb;
    Vector3 movement;

    [SerializeField] float speed;
    [SerializeField] bool translate = true;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Move(x, z);
        Turning();
        Animate(x, z);
    }

    void Move(float x, float z)
    {
        if (translate)
        {
            transform.Translate(x * Time.deltaTime * speed, 0, z * Time.deltaTime * speed);
        }
        else
        {
            movement.Set(x, 0, z);

            movement = movement.normalized * Time.deltaTime * speed;

            rb.MovePosition(transform.position + movement);
        }
        print(translate);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(camRay, out hit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }
    }

    void Animate(float x, float z)
    {
        bool isMoving = x != 0 || z != 0;
        anim.SetBool("IsMoving", isMoving);
    }
}
