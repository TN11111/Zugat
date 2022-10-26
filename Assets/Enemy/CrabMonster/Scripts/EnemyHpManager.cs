using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHpManager : MonoBehaviour
{

	//�@�ő�HP
	[SerializeField]
	private int maxHP = 10000;
	//�@�ŏI�I��hp�v���Ɏg��
	private int finalHP;
	//�@HP�\���p�X���C�_�[
	private Slider hpSlider;
	
	void Start()
	{
		hpSlider = transform.Find("Canvas/HpBar").GetComponent<Slider>();
		finalHP = maxHP;
		hpSlider.value = 1;
	}

	//�@�_���[�W�l��ǉ����郁�\�b�h
	public void TakeDamage(int damage)
	{
		//�@�_���[�W���󂯂����ɈꊇHP�p�̃o�[�̒l��ύX����
		var tempHP = Mathf.Max(finalHP -= damage, 0);
		hpSlider.value = (float)tempHP / maxHP;
		
		//�@HP��0�ȉ��ɂȂ�����G���폜
		if (tempHP <= 0)
		{
			GetComponent<BossEnemy>().DieEnemy();
		}
	}
}