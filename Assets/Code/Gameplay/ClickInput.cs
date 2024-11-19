using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace Code.Gameplay
{
  public class ClickInput : MonoBehaviour
  {
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private string _actionNameOrId;

    public event Action<Vector2> Started;
    
    private void Awake()
    {
      InputAction action = _playerInput.actions[_actionNameOrId];
      action.started += ClickStarted;
    }

    private void ClickStarted(CallbackContext ctx) => 
      Started?.Invoke(Pointer.current.position.ReadValue());
  }
}