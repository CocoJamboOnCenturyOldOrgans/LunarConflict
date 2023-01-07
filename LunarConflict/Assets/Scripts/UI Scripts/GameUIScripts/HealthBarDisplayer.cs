using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplayer : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    
    private Camera _camera;
    private GenericUnitScript _unit;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        DetectCollider();
    }

    private void DetectCollider()
    {
        var hit = Physics2D.GetRayIntersection(_camera.ScreenPointToRay(Input.mousePosition));
        var coll = hit.collider;

        if (coll != null && coll.TryGetComponent(out _unit))
        {
            var unitWorldPos = _camera.WorldToScreenPoint(_unit.transform.position);
            var collBounds = Mathf.Abs(_camera.WorldToScreenPoint(coll.bounds.max).y) + 30;

            hpSlider.transform.parent.position = new Vector3(
                    unitWorldPos.x,
                    collBounds,
                    unitWorldPos.z
                );
            
            UpdateSliderValue();

            if (!hpSlider.gameObject.activeInHierarchy)
                hpSlider.gameObject.SetActive(true);
        }
        else if(hpSlider.gameObject.activeInHierarchy)
        {
            hpSlider.gameObject.SetActive(false);
        }
        
    }

    private void UpdateSliderValue()
    {
        hpSlider.maxValue = _unit.maxHealth;
        hpSlider.value = _unit.Health;
    }
}
