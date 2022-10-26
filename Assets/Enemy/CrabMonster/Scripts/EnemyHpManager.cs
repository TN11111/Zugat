using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHpManager : MonoBehaviour
{

	//　最大HP
	[SerializeField]
	private int maxHP = 10000;
	//　最終的なhp計測に使う
	private int finalHP;
	//　HP表示用スライダー
	private Slider hpSlider;
	
	void Start()
	{
		hpSlider = transform.Find("Canvas/HpBar").GetComponent<Slider>();
		finalHP = maxHP;
		hpSlider.value = 1;
	}

	//　ダメージ値を追加するメソッド
	public void TakeDamage(int damage)
	{
		//　ダメージを受けた時に一括HP用のバーの値を変更する
		var tempHP = Mathf.Max(finalHP -= damage, 0);
		hpSlider.value = (float)tempHP / maxHP;
		
		//　HPが0以下になったら敵を削除
		if (tempHP <= 0)
		{
			GetComponent<BossEnemy>().DieEnemy();
		}
	}
}