using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Ability : MonoBehaviour
{
	
	internal PlayerStats playerStats;
	
	private void Start() {
		playerStats = FindAnyObjectByType<PlayerStats>();
	}
	internal virtual void AbilityBuff(float BuffStrenght)
	{
		
		
	}
	
}
