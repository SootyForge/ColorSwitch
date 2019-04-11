using UnityEngine;
using UnityEngine.Events;

namespace ColorSwitch
{
    public class Player : MonoBehaviour
    {
        public float jumpForce = 10f;

        public Rigidbody2D rigid;
        public SpriteRenderer rend;

        public Color[] colors = new Color[4];

        public UnityEvent onGameOver;

        private Color currentColor;

        void Start()
        {
            RandomizeColor();
            // Set the current color at start.
            currentColor = rend.color;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            {
                rigid.velocity = Vector2.up * jumpForce;
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.name == "ColorChanger")
            {
                RandomizeColor();
                Destroy(col.gameObject);
                return;
            }

            if (col.name == "Star")
            {
                // Add score
                Destroy(col.gameObject);
                return;
            }

            SpriteRenderer spriteRend = col.GetComponent<SpriteRenderer>();
            if (spriteRend != null &&
               spriteRend.color != rend.color)
            {
                Debug.Log("GAME OVER!");
                onGameOver.Invoke();
            }
        }

        void RandomizeColor()
        {
            int index = Random.Range(0, 4);
            rend.color = colors[index];
            
            // Because we can get the same color several times in a row: Run RandomizeColor() again and again until we get a brand new color.
            if (colors[index] == currentColor)
            {
                print("Same color!"); // For debugging things. Feel free to use it, or remove it.
                RandomizeColor();
            }
            else
            {
                print("New color!");
                currentColor = colors[index];
            }
        }
    }
}