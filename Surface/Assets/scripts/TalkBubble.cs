using UnityEngine;

namespace TalkBubble
{
    public class TalkBubble : MonoBehaviour
    {
        public GameObject talkBubble; // Assign the talk bubble UI element
        public Transform player; // Assign the Player GameObject
        public float activationDistance = 3.0f; // Distance to activate the talk bubble

        void Start()
        {
            if (player == null)
            {
                player = GameObject.Find("Player").transform;
            }

            if (talkBubble != null)
            {
                talkBubble.SetActive(false); // Hide the talk bubble at start
            }
        }

        void Update()
        {
            if (player != null && talkBubble != null)
            {
                float distance = Vector3.Distance(player.position, transform.position);
                if (distance <= activationDistance)
                {
                    talkBubble.SetActive(true);
                }
                else
                {
                    talkBubble.SetActive(false);
                }
            }
        }
    }
}
