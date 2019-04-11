using UnityEngine;

namespace ColorSwitch
{
    public class FollowPlayer : MonoBehaviour
    {

        public Transform player;

        void Update()
        {
            // Only run if we have a player (destroying it with Death.cs returns Null References).
            if (player != null)
            {
                Vector3 camPos = transform.position;
                Vector3 playerPos = player.position;
                if (playerPos.y > camPos.y)
                {
                    transform.position = new Vector3(camPos.x, playerPos.y, camPos.z);
                } 
            }
        }
    }
}
