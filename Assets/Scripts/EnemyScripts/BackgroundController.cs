using UnityEngine;
using System.Collections;
/// <summary>
/// 背景を動かすスクリプト
/// </summary>
public class BackgroundController : MonoBehaviour {

	void Update () {
		transform.Translate (0, -0.05f, 0);
		if (transform.position.y < -21f) {
			transform.position = new Vector3 (0, 21f, 0);
		}
	}
}