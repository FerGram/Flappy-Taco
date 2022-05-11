using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    [SerializeField] GameObject _pipePrefab;
    [SerializeField] float _timeBetweenPipes = 1f;
    [SerializeField] TextMeshProUGUI _UIText;
    private PlayerMovement _player;
    private Queue<GameObject> _pipeQueue = new Queue<GameObject>();
    private int _counter = 0;
    private AudioSource _audioSource;

    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_pipeQueue.Count != 0)
        {
            if (_pipeQueue.Peek().transform.position.x <= _player.transform.position.x)
            {
                _counter++;
                _pipeQueue.Dequeue();
                _UIText.text = _counter.ToString();
                _audioSource.PlayOneShot(_audioSource.clip);
            }
        }

        if (!_player.IsAlive())
        {
            StopAllCoroutines();
        }
    }

    public IEnumerator SpawnPipes()
    {
        Vector2 _pos = new Vector2(10, Random.Range(1.75f, -1.75f));
        GameObject pipe = Instantiate(_pipePrefab, _pos, Quaternion.identity);
        pipe.transform.SetParent(gameObject.transform);
        _pipeQueue.Enqueue(pipe);

        yield return new WaitForSeconds(_timeBetweenPipes);
        StartCoroutine(SpawnPipes());
    }
}
