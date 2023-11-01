using UnityEngine;

namespace MovementController
{
    /// <summary>
    /// VERY primitive animator example.
    /// </summary>
    public class PlayerAnimator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Animator _anim;
        [SerializeField] private SpriteRenderer _sprite;

        [Header("Settings")]

        [SerializeField] private float _maxTilt = 5;
        [SerializeField] private float _tiltSpeed = 20;

        [Header("Particles")]
        //[SerializeField] private ParticleSystem _jumpParticles;
        //[SerializeField] private ParticleSystem _launchParticles;
        [SerializeField] private ParticleSystem _moveParticles;
        //[SerializeField] private ParticleSystem _landParticles;

        //[Header("Audio Clips")]
        //[SerializeField]
        //private AudioClip[] _footsteps;

        //private AudioSource _source;
        private IPlayerController _player;
        private bool _grounded;
        private ParticleSystem.MinMaxGradient _currentGradient;

        private void Awake()
        {
            _player = GetComponentInParent<IPlayerController>();
        }

        private void OnEnable()
        {
            _player.Jumped += OnJumped;
            _player.GroundedChanged += OnGroundedChanged;

            _moveParticles.Play();
        }

        private void OnDisable()
        {
            _player.Jumped -= OnJumped;
            _player.GroundedChanged -= OnGroundedChanged;

            _moveParticles.Stop();
        }

        private void Update()
        {
            if (_player == null) return;

            HandleSpriteFlip();

            HandleCharacterTilt();

            _anim.SetFloat("Speed", Mathf.Abs(_player.FrameInput.x));
        }

        private void HandleSpriteFlip()
        {
            if (_player.FrameInput.x != 0) _sprite.flipX = _player.FrameInput.x < 0;
        }

        private void HandleCharacterTilt()
        {
            var runningTilt = _grounded ? Quaternion.Euler(0, 0, _maxTilt * _player.FrameInput.x) : Quaternion.identity;
            _anim.transform.up = Vector3.RotateTowards(_anim.transform.up, runningTilt * Vector2.up, _tiltSpeed * Time.deltaTime, 0f);
        }

        private void OnJumped()
        {
            _anim.SetBool("IsJumping", true);

            //if (_grounded) // Avoid coyote
            //{
            //    SetColor(_jumpParticles);
            //    SetColor(_launchParticles);
            //    _jumpParticles.Play();
            //}
        }

        private void OnGroundedChanged(bool grounded, float impact)
        {
            _grounded = grounded;

            if (grounded)
            {
                _anim.SetBool("IsJumping", false);

                //SetColor(_landParticles);

                _anim.SetTrigger(GroundedKey);
                //_source.PlayOneShot(_footsteps[Random.Range(0, _footsteps.Length)]);
                _moveParticles.Play();

                //_landParticles.transform.localScale = Vector3.one * Mathf.InverseLerp(0, 40, impact);
                //_landParticles.Play();
            }
            else
            {
                _moveParticles.Stop();
            }
        }

        private static readonly int GroundedKey = Animator.StringToHash("Grounded");
        private static readonly int IdleSpeedKey = Animator.StringToHash("IdleSpeed");
        private static readonly int JumpKey = Animator.StringToHash("Jump");
    }
}