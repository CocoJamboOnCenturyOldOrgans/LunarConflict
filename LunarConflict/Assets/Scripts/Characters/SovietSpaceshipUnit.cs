using System.Collections;
using UnityEngine;
using static SettingsScript;

public class SovietSpaceshipUnit : GenericUnitScript
{
	private Rigidbody2D _rb;
	private BoxCollider2D _col;
	private SpriteRenderer _renderer;
	private bool _destroyed;

	[SerializeField] private Transform bombParent;
	[SerializeField] private GameObject bombPrefab;
	[SerializeField, Range(2.0f, 10.0f)] private float retreatSpeed;
	[SerializeField, Range(10.0f, 40.0f)] private float rotationSpeed;

	protected override void Start()
	{
		base.Start();
		_rb = GetComponent<Rigidbody2D>();
		_col = GetComponent<BoxCollider2D>();
		_renderer = GetComponent<SpriteRenderer>();
	}

	protected void FixedUpdate()
	{
		if (_destroyed)
			transform.Translate(transform.right * (speed * retreatSpeed * Time.deltaTime));
	}

	public void DropBomb()
	{
		Instantiate(
			bombPrefab, 
			bombParent.position, 
			unitFaction == PlayerFaction.USA ? Quaternion.Euler(0,0,-90) : Quaternion.Euler(0,0,90));
	}

	public void Escape()
	{
		StartCoroutine(StartEscaping());
	}

	private IEnumerator StartEscaping()
	{
		yield return null;
		
		_rb.bodyType = RigidbodyType2D.Kinematic;
		_col.enabled = false;
		_destroyed = true;

		var rot = 0f;
		while (transform.localEulerAngles.z is > 340 or <= 10)
		{
			rot += -rotationSpeed * Time.deltaTime;
			transform.rotation = Quaternion.Euler(Vector3.forward * rot);
			
			yield return null;
		}
		
		yield return new WaitForSeconds(4.0f);
        
		OnDeath();
	}
}