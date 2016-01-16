using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
		private Rigidbody2D charRigidBody;
		public float speed;
        //private bool m_Jump;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
			charRigidBody = GetComponent<Rigidbody2D> ();
        }


        private void Update()
        {
			
            /*if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }*/
        }


        private void FixedUpdate()
        {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
			charRigidBody.velocity = movement * speed;

            // Read the inputs.
           /* bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.

            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
			*/
        }
    }
}
