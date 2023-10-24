using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoAI : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject attackTrigger;

    Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime < 5.0f)
        {
            Walk();
        }

        if (Time.deltaTime == 5.0f)
        {
            Attack();
        }

        if (Time.deltaTime > 10.0f)
        {
            Time.deltaTime.Equals(0f);


        }
    }

    void Walk()
    {
        transform.position += new Vector3(-0.005f, 0f, 0f);
        transform.LookAt(_player.transform);
    }

    void Attack()
    {
        attackTrigger.SetActive(true);
    }

    void Vulnerable()
    {
        _renderer.material.SetColor("_Color", Color.yellow);
    }

    void Invulnerable()
    {
        _renderer.material.SetColor("_Color", Color.red);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }
}
