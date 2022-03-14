using UnityEngine;
using System.Collections;
/// <summary>
/// 背景を動かすスクリプト
/// </summary>
public class BackgroundController : MonoBehaviour {

    Vector3 backGroundHighest = new Vector3(0, 21f, 0);

	void FixedUpdate () {
		transform.Translate (0, -0.05f, 0);
		if (transform.position.y < -backGroundHighest.y) {
			transform.position = backGroundHighest;
		}
	}
}