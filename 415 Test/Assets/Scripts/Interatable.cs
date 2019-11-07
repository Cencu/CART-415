using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interatable : MonoBehaviour
{
    // interactable items within the game that all share common values


        //Radius in which the player needs to be within in order to interact with an object
    public float radius = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);


            }
}
