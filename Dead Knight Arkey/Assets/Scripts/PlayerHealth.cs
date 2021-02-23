using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int totalhealth = 100;
    public RectTransform heartUI;
    public Transform _transformtele;
    public TextMeshProUGUI lifepoints;

    private int health;

    private SpriteRenderer _renderer;
    private Animator _animator;
    private PlayerController _playerController;

    // Start is called before the first frame update

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = totalhealth;
    }

    public void AddDamage(int amount)
    {
        health = health - amount;
        Debug.Log(health);
        StartCoroutine("VisualFeedback");

        //Game Over
        if (health <= 0)
        {
            health = 0;
            gameObject.SetActive(false);
        }

        heartUI.sizeDelta = new Vector2(health, 10);

        lifepoints.text = health.ToString();

        Debug.Log("Player got damage. His current health is " + health);

    }
    private IEnumerator VisualFeedback()
    {
        _renderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _renderer.color = Color.white;
    }

    private void OnEnable()
    {
        health = totalhealth;
    }

    private void OnDisable()
    {
        //gameOverMenu.gameObject.SetActive(true);
       // horda.SetActive(false);
       // Destroy(_enemy);
        _animator.enabled = false;
        _playerController.enabled = false;
       // finishscore.text = scoreLabel.text;
       // scoreLabel.text = "0";

        _renderer.color = Color.white;

        health = 0;
        heartUI.sizeDelta = new Vector2(health, 10);
        lifepoints.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
