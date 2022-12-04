public interface IHittable
{
    public int Health { get; set; }
    public void OnHit(int damage);
    public void OnDeath();
}
