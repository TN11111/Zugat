using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossEnemy : MonoBehaviour {

    public Animator animator;

	public GameObject target;
	[SerializeField] float speed;

	bool WalkStart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
		{
			transform.LookAt(target.transform);
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			transform.LookAt(target.transform);
		}


		if (WalkStart)
		{
			animator.SetBool("Walk_Bool", true);
		}
		else
		{
			animator.SetBool("Walk_Bool", false);
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			if (WalkStart) { return; }
			animator.SetInteger("Attack_Int", Random.Range(0, 3));
		}
	}

	public void WalkStartSet(bool walkStart)
	{
		WalkStart = walkStart;
	}

	//オブジェクトと接触した瞬間に呼び出される
	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Terrain" || collision.gameObject.name == "MediumMechStriker") { return; }
		
			
			GetComponent<EnemyHpManager>().TakeDamage(100);
		
	}

	public void DieEnemy()
	{
		if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
		{
			animator.SetTrigger("Die_Trigger");
		}
	}
}
