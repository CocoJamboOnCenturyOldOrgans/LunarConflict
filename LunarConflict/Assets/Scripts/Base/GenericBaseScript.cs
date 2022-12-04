using UnityEngine;

public class GenericBaseScript : MonoBehaviour, IHittable
{
    public int Health { get; set; }
    
    [SerializeField] private int maxHealth;

    private GameUIScript _UI;

    private void Start()
    {
        if (gameObject.CompareTag("PlayerUnit"))
        {
            _UI = FindObjectOfType<GameUIScript>();
            _UI.baseHealthSlider.maxValue = maxHealth;
            _UI.baseHealthSlider.value = maxHealth;
            _UI.baseHealthSlider.onValueChanged.Invoke(_UI.baseHealthSlider.value);
        }
        _UI = gameObject.CompareTag("PlayerUnit") ? FindObjectOfType<GameUIScript>() : null;
        Health = maxHealth;
    }
    
    public virtual void OnHit(int damage)
    {
        Health -= damage;

        if (_UI != null)
            _UI.baseHealthSlider.value = Mathf.Max(0, Health);
        
        if (Health <= 0)
            OnDeath();
        
        Debug.Log(Health);
    }

    public virtual void OnDeath()
    {
        Destroy(gameObject);
        Time.timeScale = 0;
    }
}