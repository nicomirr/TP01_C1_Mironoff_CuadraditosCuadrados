using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerInputs : MonoBehaviour
    {
        private enum Player
        {
            PlayerOne, 
            PlayerTwo
        }

        [SerializeField] private Player _player;

        private PlayerControls _playerControls;

        private InputAction _moveAction;
        public Vector2 MovementDirection => _moveAction.ReadValue<Vector2>();
        public bool ChangeColorReleased => _playerControls.Appearance.ChangeColor.WasReleasedThisFrame();

        public bool RotationPressed(out float value)
        {
            value = _playerControls.Rotation.Rotate.ReadValue<float>();

            return _playerControls.Rotation.Rotate.WasPressedThisFrame();
        }

        private void Awake()
        {
            _playerControls = new PlayerControls();

            _moveAction = _player switch
            {
                Player.PlayerOne => _playerControls.PlayerOne.Move,
                Player.PlayerTwo => _playerControls.PlayerTwo.Move,
                _ => throw new System.ArgumentOutOfRangeException()
            };
        }       

        private void OnEnable()
        {
            _moveAction.Enable();
            _playerControls.Rotation.Enable();
            _playerControls.Appearance.Enable();
        }

        private void OnDisable()
        {
            _moveAction.Disable();
            _playerControls.Rotation.Disable();
            _playerControls.Appearance.Disable();
        }                      
    }
}


