using UnityEngine;
using UnityEngine.Networking;

namespace HouraiTeahouse.SmashBrew.Characters {

    [RequireComponent(typeof(CharacterController))]
    public class PhysicsState : NetworkBehaviour, ICharacterState {

        // Character Constrants
        [Header("Constants")]
        [SerializeField]
        [Tooltip("How much the character weighs")]
        float _weight = 1.0f;

        [SerializeField]
        [Tooltip("How fast a charactter reaches their max fall speed, in seconds.")]
        float _gravity = 1.5f;

        [SerializeField]
        [Tooltip("The maximum downward velocity of the character under normal conditions")]
        float _maxFallSpeed = 5f;

        [SerializeField]
        [Tooltip("The downward velocity of the character while fast falling")]
        float _fastFallSpeed = 5f;

        [SerializeField]
        [Tooltip("The minimum walking speed of the character")]
        float _slowWalkSpeed = 2f;

        [SerializeField]
        [Tooltip("The maximum walking speed of the character")]
        float _fastWalkSpeed = 4f;

        [SerializeField]
        [Tooltip("The running speed of the character")]
        float _runSpeed = 4f;

        // Character Variables 
        [Header("Variables")]
        [SyncVar, SerializeField, ReadOnly]
        Vector2 _velocity;

        [SyncVar, SerializeField, ReadOnly]
        Vector2 _acceleration;

        [SyncVar, SerializeField, ReadOnly]
        bool _grounded;

        [SyncVar, SerializeField, ReadOnly]
        bool _isFastFalling;

        public float Weight {
            get { return _weight; }
        }

        public float Gravity {
            get { return _gravity; }
        }

        public float MaxFallSpeed {
            get { return _maxFallSpeed; }
        }

        public float FastFallSpeed {
            get { return _fastFallSpeed; }
        }

        public float SlowWalkSpeed {
            get { return _slowWalkSpeed; }
        }

        public float FastWalkSpeed {
            get { return _fastWalkSpeed; }
        }

        public float RunSpeed {
            get { return _runSpeed; }
        }

        public Vector2 Velocity {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Vector2 Acceleration {
            get { return _acceleration; }
            set { _acceleration = value; }
        }

        public bool Grounded {
            get { return _grounded; }
        }

        public void ResetState() {
            Velocity = Vector2.zero;
            Acceleration = Vector2.zero;
        }

        public CharacterController CharacterController { get; private set; }

        public bool IsFastFalling {
            get { return _isFastFalling; }
        }

        void Awake() { CharacterController = GetComponent<CharacterController>(); }

        void Update() {
            if (!isLocalPlayer)
                return;
            var acceleration = Acceleration + Vector2.down * Gravity;
            if (!Grounded)
                acceleration.y = 0;
            Velocity += acceleration * Time.deltaTime;
            var velocity = Velocity;
            if (Input.GetKey(KeyCode.LeftArrow))
                velocity -= Vector2.right * FastWalkSpeed;
            if (Input.GetKey(KeyCode.RightArrow))
                velocity += Vector2.right * FastWalkSpeed;
            CharacterController.Move(velocity * Time.deltaTime);
        }

    }

}

