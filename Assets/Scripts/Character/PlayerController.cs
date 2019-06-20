using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


namespace Knight
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        public float playerSpeed;
        

        #region Keycodes
        [SerializeField]
        KeyCode left = KeyCode.A;
        [SerializeField]
        KeyCode right = KeyCode.D;
        #endregion

        #region Public/Private Components
        private Rigidbody2D rb2d;
        private SpriteRenderer playerSprite;

        private Animator anim;

     
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            playerSprite = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            PlayerMove();
        }

        private void Update()
        {
            PlayerAnimations();
            Debug.Log(rb2d.velocity.x);   
        }

        void PlayerMove()
        {
            #region Player Horizontal Movement
            if (Input.GetKey(left))
            {
                rb2d.velocity = new Vector2(-playerSpeed, rb2d.velocity.y);
                playerSprite.flipX = true;
                
            }
            else if (Input.GetKey(right))
            {
                rb2d.velocity = new Vector2(playerSpeed, rb2d.velocity.y);
                playerSprite.flipX = false;
            }

            else rb2d.velocity = new Vector2(0, rb2d.velocity.y);

            #endregion
        }

        void PlayerAnimations()
        {
                anim.SetFloat("isRunning", rb2d.velocity.x);
        }

    }

}