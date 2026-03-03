using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
/// <summary>
/// player move speed
/// </summary>
    public float Speed = 6f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("no Rigidbody");
            enabled = false;
            return;
        }
    }

    private void FixedUpdate()
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Move(h, v);///move

        Turning();


    }


    void Move(float h, float  v)
    {
        Vector3 movementV3 = new Vector3(h , 0 ,v);
        movementV3 = movementV3.normalized * Speed * Time.deltaTime;

        rb.MovePosition(transform.position + movementV3);
    }
    void Turning()
    {
        //create camera(mouse positon)
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        int floorLayer = LayerMask.GetMask("Floor");

        RaycastHit floorHit;
        //radiographic inspection
        bool isTouchFloor = Physics.Raycast(cameraRay, out floorHit, 100, floorLayer);
        if (isTouchFloor)
        {
            Vector3 v3 = floorHit.point - transform.position;
            v3.y = 0;

            Quaternion quaternion = Quaternion.LookRotation(v3);
            rb.MoveRotation(quaternion);
        }
    }


}
