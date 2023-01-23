using System.Linq;
using UnityEngine;

public class GenericSpaceshipScript : GenericUnitScript
{
    private readonly float _initialBombCooldown = 1.0f;
    private float _bombCooldown = 0;

    protected override void Update()
    {
        base.Update();

        if (_bombCooldown > 0)
        {
            _bombCooldown -= Time.deltaTime;
        }
        else if (CanDropBomb())
        {
            DropBomb();
        }
    }

    private bool CanDropBomb()
    {
        var pos = new Vector3(transform.position.x + raycastOffset.x, transform.position.y + raycastOffset.y, transform.position.z);
        RaycastHit2D[] hit = Physics2D.RaycastAll(
            pos, 
            Vector2.down,
            attackRange, 
            mask);

        return hit.Any(x => 
            (x.collider.TryGetComponent<GenericUnitScript>(out var unitScript) && unitScript.unitFaction != unitFaction) ||
            (x.collider.TryGetComponent<GenericBaseScript>(out var baseScript) && baseScript.BaseFaction != unitFaction));
    }

    protected virtual void DropBomb()
    {
        _bombCooldown = _initialBombCooldown;
    }
}
