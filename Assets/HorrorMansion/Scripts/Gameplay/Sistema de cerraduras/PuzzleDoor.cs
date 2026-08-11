using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;

public class PuzzleDoor : MonoBehaviour
{
    private bool trig;
    private bool open;

    public float smooth = 2.0f;
    public float DoorOpenAngle = 90.0f;
    public float rotationTolerance = 1.0f;

    private Quaternion defaultRot;
    private Quaternion openRot;

    public Text txt;

    [SerializeField] private GameObject HandleButtons;
    [SerializeField] private GameObject puzzleCamera;
    [SerializeField] private GameObject audioManagerHolder;
    [SerializeField] private GameObject keyTriggerManagerHolder;

    private KeyLockManager keyLockManager;
    private PuzzleCamera puzzleCameraScript;
    private AudioManager audioManager;
    private KeyManager keyTriggerManager;

    private bool alreadyDialogued = false;
    private bool lookingPuzzle = false;

    void Start()
    {
        defaultRot = transform.rotation;

        openRot = Quaternion.Euler(
            defaultRot.eulerAngles + Vector3.up * DoorOpenAngle
        );

        keyLockManager = HandleButtons.GetComponent<KeyLockManager>();
        puzzleCameraScript = puzzleCamera.GetComponent<PuzzleCamera>();
        audioManager = audioManagerHolder.GetComponent<AudioManager>();
        keyTriggerManager = keyTriggerManagerHolder.GetComponent<KeyManager>();

        txt.text = " ";
    }

    void Update()
    {
        if (lookingPuzzle && !puzzleCamera.activeSelf)
        {
            lookingPuzzle = false;
        }
        // Comprobar la E aquí, no en OnTriggerStay
        if (trig && Keyboard.current.eKey.wasPressedThisFrame)
        {
            // Si la puerta está cerrada
            if (!open)
            {
                // Si necesita las llaves y todavía no las tiene
                if (!keyTriggerManager.AllKeysObtained())
                {
                    if (!alreadyDialogued)
                    {
                        alreadyDialogued = true;

                        audioManager.PlaySFX(audioManager.needToFindKeys);

                        StartCoroutine(DialogueCooldown());

                        txt.text = "";
                    }

                    return;
                }

                // Si las llaves están conseguidas pero el puzzle
                // todavía está bloqueando la puerta
                if (keyLockManager.DoorLocked())
                {
                    lookingPuzzle = true;

                    txt.text = "";

                    puzzleCamera.SetActive(true);
                    puzzleCameraScript.CameraActivated();

                    return;
                }

                // Si no está bloqueada, puede abrirse
                open = true;

                if (audioManager != null)
                {
                    audioManager.PlaySFX(audioManager.openDoor);
                }
            }
            else
            {
                // Cerrar la puerta
                open = false;

                if (audioManager != null)
                {
                    audioManager.PlaySFX(audioManager.closeDoor);
                }
            }
        }

        // Abrir
        if (open && Quaternion.Angle(transform.rotation, openRot) > rotationTolerance)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                openRot,
                Time.deltaTime * smooth
            );
        }
        // Cerrar
        else if (!open && Quaternion.Angle(transform.rotation, defaultRot) > rotationTolerance)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                defaultRot,
                Time.deltaTime * smooth
            );
        }

        // Actualizar texto
        if (trig && !lookingPuzzle)
        {
            if (open)
            {
                txt.text = "Close [E]";
            }
            else if (keyLockManager.DoorLocked())
            {
                txt.text = "Unlock Door [E]";
            }
            else
            {
                txt.text = "Open [E]";
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            trig = true;

            if (!lookingPuzzle)
            {
                if (open)
                    txt.text = "Close [E]";
                else if (keyLockManager.DoorLocked())
                    txt.text = "Unlock Door [E]";
                else
                    txt.text = "Open [E]";
            }
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            trig = false;
            txt.text = " ";
        }
    }

    private IEnumerator DialogueCooldown()
    {
        yield return new WaitForSeconds(6f);
        alreadyDialogued = false;
    }
}