using UnityEngine;
using UnityEngine.InputSystem;  // Añadir el nuevo namespace
using UnityEngine.UI;
using System.Collections;

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
    [SerializeField] private GameObject keyTriggerManagerHolder;

    private KeyLockManager keyLockManager;
    private PuzzleCamera puzzleCameraScript;
    private AudioManager audioManager;
    private KeyTriggerManager keyTriggerManager;

    private bool alreadyDialogued = false;
    private bool lookingPuzzle = false;

    void Start()
    {
        defaultRot = transform.rotation;
        openRot = Quaternion.Euler(defaultRot.eulerAngles + Vector3.up * DoorOpenAngle);

        keyLockManager = HandleButtons.GetComponent<KeyLockManager>();
        puzzleCameraScript = puzzleCamera.GetComponent<PuzzleCamera>();
        audioManager = audioManagerHolder.GetComponent<AudioManager>();
        keyTriggerManager = keyTriggerManagerHolder.GetComponent<KeyTriggerManager>();
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
            else if(keyTriggerManager.AllKeysObtained() && trig)
            {
                lookingPuzzle = true;

                txt.text = "";
                puzzleCamera.SetActive(true);
                puzzleCameraScript.CameraActivated();
            } 
        }

        if (trig && keyLockManager.DoorLocked() && !lookingPuzzle)
        {
            txt.text = "Unlock Door \\[E\\]";
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
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                ePressed = true;

                if(!keyTriggerManager.AllKeysObtained() && !alreadyDialogued)
                {
                    alreadyDialogued = true;
                    audioManager.PlaySFX(audioManager.needToFindKeys);
                    StartCoroutine(DialogueCooldown());
                    txt.text = "";
                }
            }
        }
    }

    private IEnumerator DialogueCooldown()
    {
        yield return new WaitForSeconds(6f);
        alreadyDialogued = false;
    }
}
