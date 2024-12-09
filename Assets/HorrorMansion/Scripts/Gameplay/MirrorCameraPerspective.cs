using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCameraPerspective : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform portal;
    [SerializeField] private Transform otherPortal;

    [SerializeField] private Camera playerCameraC;
    [SerializeField] private Camera mirrorCamera;


    void Start()
    {
        mirrorCamera.fieldOfView = playerCameraC.fieldOfView;
    }

    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;
    }

}
