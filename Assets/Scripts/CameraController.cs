using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;

    
    //public float minY;
    //public float maxY;


   //Variable for X camera limits
    public float minposX;
    public float maxposX;

    //Variable for Z camera limits
    public float minposZ;
    public float maxposZ;

    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    public Vector3 zoomAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newZoom;
   

    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;

    

    void Start()
    {

        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;

    }

    void Update()
    {
        HandleMouseInput();
        HandleMovementInput();

        
        //newZoom.y = Mathf.Clamp(newZoom.y, minY, maxY);
        newPosition.x = Mathf.Clamp(newPosition.x, minposX, maxposX);
        newPosition.z = Mathf.Clamp(newPosition.z, minposZ, maxposZ);
        

    }

    //Mouse buttons inputs
    void HandleMouseInput()
    {

        if (Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }

        if (Input.GetMouseButtonDown(2))
        {
            rotateStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            rotateCurrentPosition = Input.mousePosition;

            Vector3 difference = rotateStartPosition - rotateCurrentPosition;

            rotateStartPosition = rotateCurrentPosition;

            newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }
    }

    //Keyboard inputs
    void HandleMovementInput()
    {
        
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * movementSpeed);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -movementSpeed);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }

        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }


        //Makes the camera movement more smooth
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);

    }

}