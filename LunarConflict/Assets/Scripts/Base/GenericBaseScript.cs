using System.Collections.Generic;
using UnityEngine;
using static GameRoundData;
using static SettingsScript;
using UnityEngine.SceneManagement;

public class GenericBaseScript : MonoBehaviour, IHittable
{
    public int Health { get; set; }
    public int maxHealth;
    
    [field: SerializeField] public PlayerFaction BaseFaction { get; private set; }
    [SerializeField] private List<GameObject> aiUnitPrefabs;
    
    public GameObject spawner;
    private GameUIScript _UI;

    private void Start()
    {
        if (IsPlayer(BaseFaction))
        {
            _UI = FindObjectOfType<GameUIScript>();
            _UI.baseHealthSlider.maxValue = maxHealth;
            _UI.baseHealthSlider.value = maxHealth;
            _UI.baseHealthSlider.onValueChanged.Invoke(_UI.baseHealthSlider.value);
        }
        else
        {
            var ai = gameObject.AddComponent<EnemyAIScript>();
            ai.SetAI(aiUnitPrefabs, transform.GetChild(1), 7);
        }
        _UI = IsPlayer(BaseFaction) ? FindObjectOfType<GameUIScript>() : null;
        Health = maxHealth;
    }
    
    public virtual void OnHit(int damage)
    {
        Health -= damage;

        if (_UI != null)
        {
            _UI.baseHealthSlider.value = Mathf.Max(0, Health);
            baseHP = Mathf.Max(0, Health);
        }
        
        if (Health <= 0)
            OnDeath();
        
        Debug.Log($"{(_UI != null ? "Player" : "Enemy")} base HP: {Health}");
    }

    public virtual void OnDeath()
    {
        Destroy(gameObject);
        Time.timeScale = 0;
        playerWon = !IsPlayer(BaseFaction);
        SceneManager.LoadSceneAsync(2);
    }
}
