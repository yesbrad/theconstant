using UnityEngine;

public class PlayerConroller : MonoBehaviour
{
    public static PlayerConroller instance;

    [SerializeField] float speed = 10;
    [SerializeField] Transform lookAtSocket;
    public Transform LookAtSocket { get { return lookAtSocket; } }

    bool lockPlayer;

    Transform lookAtObject;
    Transform mainCamera;
    Rigidbody rigidBody;
    Collider playerCollider;

    Vector3 moveVector;
    Vector3 mouseX;
    Vector3 mouseY;

    void Start ()
    {
        instance = this;
        mainCamera = GetComponentInChildren<Camera>().transform;
        rigidBody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        ToggleCursor(false);
    }

    public void ToggleCursor (bool isOn)
    {
        Cursor.lockState = isOn ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isOn;
    }

    public void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursor(true);
        }

        if (!lockPlayer)
        {
            UpdatePosition();
            UpdateRotation();
        }
    }

    public void UpdatePosition ()
    {
        moveVector = new Vector3(Input.GetAxis("Horizontal") * speed, rigidBody.velocity.y, Input.GetAxis("Vertical") * speed);
        rigidBody.velocity = transform.TransformDirection(moveVector);
    }

    public void UpdateRotation ()
    {
        mouseX.x += -Input.GetAxis("Mouse Y");
        mouseY.y += Input.GetAxis("Mouse X");

        mouseX.x = Mathf.Clamp(mouseX.x, -85, 85);

        transform.rotation = Quaternion.Euler(mouseY);
        mainCamera.localRotation = Quaternion.Euler(mouseX);
    }

    public void LockPlayer (bool isLocked)
    {
        lockPlayer = isLocked;
    }

    public void SetLookAtObject (Transform lookAt)
    {
        lookAtObject = lookAt;
        LockPlayer(lookAt);
        playerCollider.enabled = lookAt == null;
        rigidBody.useGravity = lookAt == null;
    }
}
