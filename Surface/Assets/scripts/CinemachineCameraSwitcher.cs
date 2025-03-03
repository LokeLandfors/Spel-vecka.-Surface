using UnityEngine;
using Cinemachine;

public class CinemachineCameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera targetCamera; //Aktiverar kameran

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //S�kerst�ller att Player �r i triggerzone
        {
            ActivateCamera();
        }
    }

    void ActivateCamera()
    {
        // Deactivate all other cameras
        CinemachineVirtualCamera[] allCameras = FindObjectsOfType<CinemachineVirtualCamera>();
        foreach (var cam in allCameras)
        {
            cam.Priority = 0; //S�tter alla kameror till l�g prioritet
        }

        //Aktiverar m�lkameran
        targetCamera.Priority = 10; //S�tter m�lkameran till h�g prioritet
    }
}
