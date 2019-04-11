using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch
{
    public class Death : MonoBehaviour
    {
        // Because we're Invoking Death.cs via OnTriggerEnter2D inside of Player.cs, call this as a new fuction.
        public void Destroy(Collider2D other)
        {
            Destroy(other.gameObject);
        }
    }
}