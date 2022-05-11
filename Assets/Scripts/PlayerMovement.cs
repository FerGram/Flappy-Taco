
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] ParticleSystem _tapParticles;
    [SerializeField] float _particleOffset = -0.6f;
    [SerializeField] float _upForce = 10f;
    [SerializeField] float _maxHeight = 7f;
    [SerializeField] GameObject _pipeSpawner;
    [SerializeField] ParticleSystem _tapParticles;

    private PlayerUI _UI;
    private Rigidbody2D _rigidbody;
    private bool _isAlive = true;
    private bool _isReady = false;

    public bool IsAlive() { return _isAlive; }
    public bool IsReady() { return _isReady; }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.isKinematic = true;
        _UI = GetComponent<PlayerUI>();
    }

    void Update()
    {
        StartGameInput();
        GameInput();

        if(transform.position.y >= _maxHeight)
        {
            transform.position = new Vector2(transform.position.x, _maxHeight);
        }
        if (!_isAlive)
        {
            Quaternion downRotation = Quaternion.Euler(0, 0, -90);
            transform.rotation = Quaternion.Slerp(transform.rotation, downRotation, Time.deltaTime * 5);
        }
    }

    private void StartGameInput()
    {
        if (Input.GetMouseButtonDown(0) && !_isReady)
        {
            _isReady = true;
            _rigidbody.isKinematic = false;

            PipesSpawner spawner = _pipeSpawner.GetComponent<PipesSpawner>();
            StartCoroutine(spawner.SpawnPipes());

            _tapParticles.Play();
            _UI.RemoveTap();
        }
    }
    private void GameInput()
    {
        if (Input.GetMouseButtonDown(0) && _isAlive && _isReady)
        {
            _rigidbody.velocity = new Vector2(0, 0);
            _rigidbody.velocity += new Vector2(0, _upForce);
            //InstantiateParticles();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isAlive = false;
        _UI.DeathUI();
        
        if (collision.tag == "Floor")
        {
            _rigidbody.bodyType = RigidbodyType2D.Static;
        }
    }
}
