using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInputController.IPlayerActions
{
    public event Action PlayerIsMovingEvent;

    public event Action PlayerIsPaintingEvent;

    public event Action PlayerIsChangingGravityEvent;

    public event Action<Vector2> PlayerChangeOrientationEvent;
    
    public Vector2 DirectionPlayer { get; private set; }
    public bool IsPainting;
    

    public void OnMove(InputAction.CallbackContext context)
    {   
        DirectionPlayer = context.ReadValue<Vector2>();
        PlayerIsMovingEvent?.Invoke();
        PlayerChangeOrientationEvent?.Invoke(DirectionPlayer);
        SoundManager.Instance.FootStepsPlayer();

        if (context.canceled)
        {
            SoundManager.Instance.StopFootStepsPlayer();
        }
    }

    public void OnPaint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PlayerIsPaintingEvent?.Invoke();
        }
        
    }

    public void OnChangeGravity(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PlayerIsChangingGravityEvent?.Invoke();
        }
    }
}
