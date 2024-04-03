using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class  Weapon : MonoBehaviour
{
	protected  WeaponPositioner weaponPositioner;
	[SerializeField] internal bool canattack = true;
	[SerializeField] internal float AttackCoolDown = 5f;
	protected  Animator myAnimator;
	protected  PlayerController playerController;
	protected PlayerControls playerControls;
	[SerializeField] protected AttackCooldownIndicator attackCooldownIndicator;
	protected  ActiveWeapon activeWeapon;
	public GameObject currentWeapon;
	
internal virtual void WeaponOn()
{
    Debug.Log($"Activated a weapon named" + this.gameObject.name);
    this.gameObject.SetActive(true);
    canattack = true; // reset posssibility of weapon using
}
	
	internal virtual void WeaponOff()
	{ // Method for ActiveWeapon setting.
	Debug.Log($"Deactivated a weapon named"+ this.gameObject.name);
		//currentWeapon.gameObject.SetActive(false);
		this.gameObject.SetActive(false);
			}
	protected virtual void Awake()
	{
		myAnimator = GetComponent<Animator>();
		playerController = GetComponentInParent<PlayerController>();
		weaponPositioner = GetComponent<WeaponPositioner>();
		playerControls = new PlayerControls();
		activeWeapon = GetComponentInParent<ActiveWeapon>();
		currentWeapon = this.gameObject;
	}
		private void OnEnable()
	{
		playerControls.Enable();
	}
	
		void Start()
	{
				playerControls.Combat.Attack.started += _ => Attack(); // Activate attack method after player attack input from mouse.
	}
	
	protected virtual void Attack()
	{
		if (this.gameObject.activeInHierarchy)
	{
		attackCooldownIndicator.StartCounting(AttackCoolDown);
		myAnimator.SetTrigger("Attack"); //Attack animation trigger. 
		
		StartCoroutine(AttackCooldownRoutine());
		//attackCooldownIndicator.StartCounting();
	}
	else
		{
			Debug.Log("Cannot attack yet. Cooldown in progress.");
		}
			}
	
	protected virtual IEnumerator AttackCooldownRoutine()
	{
		
		canattack=false;
		
		yield return new WaitForSeconds(AttackCoolDown);
	
	}
}
