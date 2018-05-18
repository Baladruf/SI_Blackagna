using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
	public Transform Target;
	public float Height = 10.0f;
	public float Damping = 2.0f;

	void LateUpdate ()
	{
		float wantedX = Target.position.x;
		float wantedZ = Target.position.z;

		float currentX = transform.position.x;
		float currentZ = transform.position.z;
		
		currentX = Mathf.Lerp(currentX, wantedX, Damping * Time.deltaTime);
		currentZ = Mathf.Lerp(currentZ, wantedZ, Damping * Time.deltaTime);

		transform.position = new Vector3 (currentX, Height, currentZ);
	}
}
