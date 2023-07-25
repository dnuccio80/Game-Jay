using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
using System;
using StarterAssets;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		public static StarterAssetsInputs Instance { get; private set; }

		private ThirdPersonController thirdPersonController;
		private ThirdPersonShooterController thirdPersonShooterController;
		public event EventHandler OnInteractButtonPressed;
		public event EventHandler OnInteractAlternatePressed;
		public event EventHandler OnReturnButtonPressed;
		private Animator animator;

		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool aim;
		public bool shoot;

		private bool hasAnObject = false;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM

		private void Awake()
		{
			Instance = this;
			animator = GetComponent<Animator>();
			thirdPersonController = GetComponent <ThirdPersonController>();
			thirdPersonShooterController = GetComponent<ThirdPersonShooterController>();
        }

        private void Start()
        {
            GeneralGameLogic.Instance.OnMissionCompleted += GeneralGameLogic_OnMissionCompleted;
        }

        private void GeneralGameLogic_OnMissionCompleted(object sender, EventArgs e)
        {
			animator.SetTrigger("Dance");
        }

        public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnAim(InputValue value)
		{
			AimInput(value.isPressed);
		}

		public void OnShoot(InputValue value)
		{
			ShootInput(value.isPressed);
		}

		public void OnInteractAlternate(InputValue value)
        {
			OnInteractAlternatePressed?.Invoke(this, EventArgs.Empty);
			ChangeCharacterControllerStatus(false);
		}

		public void OnReturn(InputValue value)
        {
			OnReturnButtonPressed?.Invoke(this, EventArgs.Empty);
        }

#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void ShootInput(bool newShootInput)
		{
			shoot = newShootInput;
		}

		public void AimInput(bool newAimState)
		{
			aim = newAimState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

		private void OnInteraction(InputValue value)
        {
			if(value.isPressed)
            {
				OnInteractButtonPressed?.Invoke(this, EventArgs.Empty);

			}
        }

		public void ChangeObjectStatus(bool _hasAnObject, float _newSpeed, bool _newJumpStatus)
        {
			hasAnObject = _hasAnObject;
			thirdPersonController.setMoveSpeed(_newSpeed);
			thirdPersonController.ChangeJumpStatus(_newJumpStatus);
        }

		public bool GetObjectStatus()
        {
			return hasAnObject;
        }

		public void ChangeCharacterControllerStatus(bool status)
        {
			thirdPersonController.enabled = status;
			thirdPersonShooterController.enabled = status;
		}
		
	}
	
	

}