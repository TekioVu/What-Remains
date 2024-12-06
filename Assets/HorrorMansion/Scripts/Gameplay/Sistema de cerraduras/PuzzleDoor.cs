using UnityEngine;
using UnityEngine.InputSystem;  // Añadir el nuevo namespace
using UnityEngine.UI;

public class PuzzleDoor : MonoBehaviour
{
    bool trig, open;
    bool ePressed = false;
    public float smooth = 2.0f;
    public float DoorOpenAngle = 90.0f;
    public float rotationTolerance = 1.0f; // Tolerance for stopping rotation
    private Quaternion defaultRot;
    private Quaternion openRot;
    public Text txt;

    [SerializeField] private GameObject HandleButtons;
    [SerializeField] private GameObject puzzleCamera;

    private KeyLockManager keyLockManager;
    private PuzzleCamera puzzleCameraScript;

    void Start()
    {
        defaultRot = transform.rotation;
        openRot = Quaternion.Euler(defaultRot.eulerAngles + Vector3.up * DoorOpenAngle);

        keyLockManager = HandleButtons.GetComponent<KeyLockManager>();
        puzzleCameraScript = puzzleCamera.GetComponent<PuzzleCamera>();
    }

    void Update()
    {
        if (ePressed && trig)
        {
            open = !open;
            ePressed = false;
        }

        if (open && Quaternion.Angle(transform.rotation, openRot) > rotationTolerance)
        {
            if(!keyLockManager.DoorLocked())
             transform.rotation = Quaternion.Slerp(transform.rotation, openRot, Time.deltaTime * smooth);
             else {
                    puzzleCamera.SetActive(true);
                    puzzleCameraScript.CameraActivated();
                }
        }
        else if (!open && Quaternion.Angle(transform.rotation, defaultRot) > rotationTolerance)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, defaultRot, Time.deltaTime * smooth);
        }

        if (trig)
        {
            if (open)
            {
                if(!keyLockManager.DoorLocked())
                txt.text = "Close E";
                else txt.text = " ";
            }
            else
            {
                if(!keyLockManager.DoorLocked())
                txt.text = "Open E";
                else txt.text = "Unlock Door";
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            if (!open)
            {
                if(!keyLockManager.DoorLocked())
                txt.text = "Close E";
                else txt.text = " ";
            }
            else
            {
                if(!keyLockManager.DoorLocked())
                txt.text = "Open E";
                else txt.text = "Unlock Door";
            }
            trig = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            txt.text = " ";
            trig = false;
        }
    }

    private void OnTriggerStay(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            // Cambiar esta línea para usar el nuevo Input System
            if (Keyboard.current.eKey.wasPressedThisFrame)  // Nueva API
            {
                ePressed = true;
            }
        }
    }
}
