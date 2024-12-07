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
    [SerializeField] private GameObject audioManagerHolder;

    private KeyLockManager keyLockManager;
    private PuzzleCamera puzzleCameraScript;
    private AudioManager audioManager;

    void Start()
    {
        defaultRot = transform.rotation;
        openRot = Quaternion.Euler(defaultRot.eulerAngles + Vector3.up * DoorOpenAngle);

        keyLockManager = HandleButtons.GetComponent<KeyLockManager>();
        puzzleCameraScript = puzzleCamera.GetComponent<PuzzleCamera>();
        audioManager = audioManagerHolder.GetComponent<AudioManager>();
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
                    txt.text = "";
                    puzzleCamera.SetActive(true);
                    puzzleCameraScript.CameraActivated();
                }
        }

        if (trig)
        {
            if (!open && keyLockManager.DoorLocked())
            {
                txt.text = "Unlock Door [E]";
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
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
