using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    private bool trig;
    private bool open;

    public float smooth = 2.0f;
    public float DoorOpenAngle = 90.0f;
    public float rotationTolerance = 1.0f;

    private Quaternion defaultRot;
    private Quaternion openRot;

    public Text txt;

    [SerializeField] private GameObject audioManagerHolder;
    private AudioManager audioManager;

    [SerializeField] private bool audioManagerNecessary = false;

    void Start()
    {
        defaultRot = transform.rotation;
        openRot = Quaternion.Euler(
            defaultRot.eulerAngles + Vector3.up * DoorOpenAngle
        );

        if (audioManagerNecessary)
        {
            audioManager = audioManagerHolder.GetComponent<AudioManager>();
        }

        txt.text = " ";
    }

    void Update()
    {
        // Comprobar la E aquí, no en OnTriggerStay
        if (trig && Keyboard.current.eKey.wasPressedThisFrame)
        {
            open = !open;

            if (audioManagerNecessary)
            {
                if (open)
                    audioManager.PlaySFX(audioManager.openDoor);
                else
                    audioManager.PlaySFX(audioManager.closeDoor);
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
        if (trig)
        {
            if (open)
                txt.text = "Close [E]";
            else
                txt.text = "Open [E]";
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            trig = true;

            if (open)
                txt.text = "Close [E]";
            else
                txt.text = "Open [E]";
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
}