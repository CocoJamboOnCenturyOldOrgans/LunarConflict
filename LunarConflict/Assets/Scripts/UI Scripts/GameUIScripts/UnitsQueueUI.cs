using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UnitsQueueUI : MonoBehaviour
{
    [SerializeField] private Sprite emptyFieldSprite;
    
    private List<Image> _queueFields = new();
    private Queue<Sprite> _unitIcons = new();

    private void Start()
    {
        _queueFields.AddRange(GetComponentsInChildren<Image>());
        _queueFields.RemoveAt(0);

        _queueFields.Select(x => x.sprite = emptyFieldSprite);
    }

    public void Enqueue(Sprite sprite)
    {
        _unitIcons.Enqueue(sprite);
        UpdateQueueFields();
    }

    public void Dequeue()
    {
        _unitIcons.Dequeue();
        UpdateQueueFields();
    }

    private void UpdateQueueFields()
    {
        var iconArray = _unitIcons.ToArray();
        for (int i = 0; i < _queueFields.Count; i++)
            _queueFields[i].sprite = i < iconArray.Length ? iconArray[i] : emptyFieldSprite;
    }
}
