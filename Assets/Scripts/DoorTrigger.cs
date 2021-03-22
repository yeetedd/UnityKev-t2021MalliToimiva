using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    public enum TriggerState {Open, Close};
    public TriggerState state = TriggerState.Open;

    public DoorController door;


    private void OnTriggerEnter(Collider other)
    {
        if(state == TriggerState.Open)
        {
            door.OpenDoor();
        }

        if(state == TriggerState.Close)
        {
            door.CloseDoor();
        }
    }

 
}
