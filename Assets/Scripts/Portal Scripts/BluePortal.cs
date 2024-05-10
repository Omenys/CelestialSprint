using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePortal : MonoBehaviour
{
    PortalEntered portal;

    private void OnTriggerEnter(Collider other)
    {
        portal.portalsEntered += 1;
    }
}
