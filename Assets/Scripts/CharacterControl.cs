using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    public float speed = 1.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos; // physic kullanmadan karakter hareketi.
    [SerializeField] private GameObject _camera;
    private SpriteRenderer _spriteRanderer;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        //Caching işlemi
        _spriteRanderer = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>();
        // _animator = GetComponent<Animator>();
        charPos = transform.position;
    }

    private void FixedUpdate()
    {
        //r2d.velocity=new Vector2(speed,0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        // her frame'de çalışır. Fizik hesaplamaları update'ten önce yapılmalıdır.
        /*
        //Space tuşu ile hoz kontrolü yapılan örnek.
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 1.0f;
            //Debug.Log("Speed = 1.0f");
        }
        else
        {
            speed = 0.0f;
            //Debug.Log("Speed = 0.0f");
        }*/
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y);
        transform.position = charPos;// hesaplanan pozisyonu karaktere entegre ettik.


        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", speed);
            if (Input.GetAxis("Horizontal") > 0.01f)
            {
                _spriteRanderer.flipX = false;
            }
            else
            {
                _spriteRanderer.flipX = true;
            }


        }

    }

    private void LateUpdate()
    {
        //Kamerayı karaktere odaklayarak karakterin hareketi ile eş zamanlı hareket etmesi sağlandı.
        // Önemli!! kameranın z pozisyonu karakterden geride başlamalı tam üst üste olunca karakter görünmüyor.
        //_camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);
    }


}
