using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    AudioSource _audio;
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _text.text = Score.totalScore.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Elmas"))
        {
            _audio.Play();
            Destroy(other.gameObject);
            Score.totalScore++;
            _text.text = Score.totalScore.ToString();
            /*if (_text.CompareTag("Score"))
            {
                _text.text = Score.totalScore.ToString();
            }*/

        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
