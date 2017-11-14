using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalLineController : MonoBehaviour
{
    float m_fallingSpeed = 1.0f;

    [SerializeField]
    GameObject m_enemyPrefab;

    [SerializeField]
    GameObject m_defencePrefab;

    [SerializeField]
    Transform[] m_itemSpawnPositions;

    [SerializeField]
    int m_limitOfDefencesInALine = 1;

    [SerializeField]
    float m_probablityForDefence = 0.2f;    // 1 = 100 %

    public float FallingSpeed //読み取り専用
    {
        get
        {
            return m_fallingSpeed;
        }

        set
        {
            m_fallingSpeed = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        GenerateItems();
    }

	//FixedUpdate()は、秒間に呼ばれる回数が一定.Updateは移動が安定しない
	//Updateはフレームの進行で、FixedUpdateは物理シミュレータの進行で使用
    void FixedUpdate()
    {
		//Y軸は1秒あたりm_fallingSpeed（1.0f）でマイナス方向（上に）進む
        transform.position = new Vector3(transform.position.x, transform.position.y - m_fallingSpeed * Time.deltaTime, transform.position.z);
    }

    void GenerateItems()
    {
		//gameobjectを格納する配列itemArray
        GameObject[] itemArray = PrepareItems();

        for (int i = 0; i < m_itemSpawnPositions.Length; i++)
        {
			//Instantiate( 生成するオブジェクト,  場所)
			Instantiate(itemArray[i], m_itemSpawnPositions[i]); //オブジェクトを生成
        }
    }

	//？
    GameObject[] PrepareItems()
    {
		//動的に要素の数を増減できるListの宣言(動的配列)
        List<GameObject> goList = new List<GameObject>();
        int defenceCounter = 0;
        for (int i = 0; i < m_itemSpawnPositions.Length; i++)//5回までループ
        {
            bool isDefence = false;
            if (defenceCounter < m_limitOfDefencesInALine)//0 < 1
            {
                float dice = Random.Range(0f, 1.0f); //ランダムに生産
                if (dice < m_probablityForDefence)//らんだむ値0-1.0 < 0.2 0.2以下の場合ディフェンスを生成する選択肢へ
                {
                    defenceCounter++;
                    isDefence = true;
                }
            }

			//毎回どっちを生成するかの判定
            if (isDefence)//true
                goList.Add(m_defencePrefab);
            else
                goList.Add(m_enemyPrefab);

        }
        return goList.ToArray();
    }
}
