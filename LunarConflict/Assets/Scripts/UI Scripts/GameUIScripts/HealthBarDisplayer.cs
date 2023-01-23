using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplayer : MonoBehaviour
{
    [SerializeField] private Vector2 hpSliderOffset;
    
    [SerializeField] private Transform hpSliderParent;
    private GameObject _currentHpSliderParent;
    private Slider _currentHpSlider;
    
    private Transform _dynamicUI;
    private Camera _camera;
    private BoxCollider2D _coll;
    
    private GenericUnitScript _unit;
    private GenericBaseScript _base;

    private void Start()
    {
        _unit = GetComponent<GenericUnitScript>();
        _base = GetComponent<GenericBaseScript>();

        if (_unit == null && (_base == null || (_base != null && SettingsScript.IsPlayer(_base.BaseFaction))))
        {
            Destroy(this);
            return;
        }
        
        
        _camera = Camera.main;
        _coll = GetComponent<BoxCollider2D>();
        
        _dynamicUI = GameObject.Find("DynamicUI").transform;
        _currentHpSliderParent = Instantiate(hpSliderParent, _dynamicUI).gameObject;
        _currentHpSlider = _currentHpSliderParent.GetComponentInChildren<Slider>();
    }

    private void LateUpdate()
    {
        var unitWorldPos = _camera.WorldToScreenPoint(transform.position);
        var collBounds = Mathf.Abs(_camera.WorldToScreenPoint(_coll.bounds.max).y) + 30;

        _currentHpSliderParent.transform.position = new Vector3(
            unitWorldPos.x + hpSliderOffset.x,
            collBounds + hpSliderOffset.y,
            unitWorldPos.z
        );
            
        _currentHpSlider.maxValue = _unit != null ? _unit.maxHealth : _base.maxHealth;
        _currentHpSlider.value = _unit != null ? _unit.Health : _base.Health;

        if (!_currentHpSliderParent.activeInHierarchy) _currentHpSliderParent.SetActive(true);
    }

    public void DestroySlider() => Destroy(_currentHpSliderParent);
}
