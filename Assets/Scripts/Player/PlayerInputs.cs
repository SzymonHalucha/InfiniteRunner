using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerInputs : PlayerBaseComponent
    {
        [SerializeField] private InputActionReference _mouse = null;

        public InputAction Mouse { get; private set; }

        private void OnEnable()
        {
            Mouse = _mouse.action.Clone();
            EnableControls();
        }

        private void OnDisable()
        {
            DisableControls();
        }

        public void EnableControls()
        {
            Mouse.Enable();
        }

        public void DisableControls()
        {
            Mouse.Disable();
        }
    }
}