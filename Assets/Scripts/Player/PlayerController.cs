using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerInputs))]
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Rotation))]
    [RequireComponent(typeof(Appearance))]

    public class PlayerController : MonoBehaviour
    {
        private PlayerInputs _playerInputs;
        private Movement _movement;
        private Rotation _rotation;
        private Appearance _appearance;

        private void Awake()
        {
            _playerInputs = GetComponent<PlayerInputs>();
            _movement = GetComponent<Movement>();
            _rotation = GetComponent<Rotation>();
            _appearance = GetComponent<Appearance>();
        }

        private void Update()
        {
            HandleMovement();
            HandleRotation();       
            HandleColorChange();
        }

        private void HandleMovement()
        {
            _movement.Move(_playerInputs.MovementDirection);
        }

        private void HandleRotation()
        {
            float rotation;

            if (_playerInputs.RotationPressed(out rotation))
            {
                _rotation.Rotate(rotation);
            }
        }

        private void HandleColorChange()
        {
            if(_playerInputs.ChangeColorReleased)
            {
                _appearance.RandomizeColor();
            }
        }

    }
}

