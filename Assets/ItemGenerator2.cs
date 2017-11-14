using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator2 : MonoBehaviour
{
    [SerializeField]
    GameObject m_horizontalLinePrefab;

    [SerializeField]
    Transform m_spawnPosition;

    GameObject m_lastGeneratedLine;

	// Use this for initialization
	void Start ()
    {

	}

	// Update is called once per frame
	void Update ()
    {
        if (!m_lastGeneratedLine)
            m_lastGeneratedLine = Instantiate(m_horizontalLinePrefab, m_spawnPosition.position, Quaternion.identity);
        else if (m_lastGeneratedLine.transform.position.y < m_spawnPosition.position.y - m_lastGeneratedLine.transform.localScale.y)
            m_lastGeneratedLine = Instantiate(m_horizontalLinePrefab, m_spawnPosition.position, Quaternion.identity);
    }
}
