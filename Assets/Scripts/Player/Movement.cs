using UnityEngine;

namespace Game.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;

        public void Move(Vector3 direction)
        {           
            this.transform.position += direction.normalized * (_movementSpeed * Time.deltaTime);
        }
    }
}

