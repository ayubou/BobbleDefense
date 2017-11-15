using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapBehaviour : MonoBehaviour {

	// タッチしたときに呼ばれる。
	public virtual void TapDown(ref RaycastHit hit){}
	// タッチを離したときに呼ばれる。
	public virtual void TapUp(ref RaycastHit hit){}
}
