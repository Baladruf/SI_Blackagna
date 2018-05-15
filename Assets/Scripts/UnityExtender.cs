using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UnityExtender {

/* ---------------------- TRANSFORM ---------------------- */

	/// <summary>
		/// Sets the x position of a transform.
		/// </summary>
		/// <param name="value">The new x position.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetPosX(this Transform transform, float value) {
		transform.position = new Vector3(value, transform.position.y, transform.position.z);
		return transform;
	}

	/// <summary>
		/// Sets the y position of a transform.
		/// </summary>
		/// <param name="value">The new y position.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetPosY(this Transform transform, float value) {
		transform.position = new Vector3(transform.position.x, value, transform.position.z);
		return transform;
	}

	/// <summary>
		/// Sets the z position of a transform.
		/// </summary>
		/// <param name="value">The new z position.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetPosZ(this Transform transform, float value) {
		transform.position = new Vector3(transform.position.x, transform.position.y, value);
		return transform;
	}

	/// <summary>
		/// Sets the x position of a transform relative to the actual x position.
		/// </summary>
		/// <param name="value">The x position shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativePosX(this Transform transform, float value) {
		transform.position += new Vector3(value, 0, 0);
		return transform;
	}

	/// <summary>
		/// Sets the y position of a transform relative to the actual y position.
		/// </summary>
		/// <param name="value">The y position shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativePosY(this Transform transform, float value) {
		transform.position += new Vector3(0, value, 0);
		return transform;
	}

	/// <summary>
		/// Sets the z position of a transform relative to the actual z position.
		/// </summary>
		/// <param name="value">The z position shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativePosZ(this Transform transform, float value) {
		transform.position += new Vector3(0, 0, value);
		return transform;
	}

	/// <summary>
		/// Sets the x local position of a transform.
		/// </summary>
		/// <param name="value">The new x local position.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetLocalPosX(this Transform transform, float value) {
		transform.localPosition = new Vector3(value, transform.localPosition.y, transform.localPosition.z);
		return transform;
	}

	/// <summary>
		/// Sets the y local position of a transform.
		/// </summary>
		/// <param name="value">The new y local position.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetLocalPosY(this Transform transform, float value) {
		transform.localPosition = new Vector3(transform.localPosition.x, value, transform.localPosition.z);
		return transform;
	}

	/// <summary>
		/// Sets the z local position of a transform.
		/// </summary>
		/// <param name="value">The new z local position.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetLocalPosZ(this Transform transform, float value) {
		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, value);
		return transform;
	}

	/// <summary>
		/// Sets the x local position of a transform relative to the actual x local position.
		/// </summary>
		/// <param name="value">The x local position shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativeLocalPosX(this Transform transform, float value) {
		transform.localPosition += new Vector3(value, 0, 0);
		return transform;
	}

	/// <summary>
		/// Sets the y local position of a transform relative to the actual y local position.
		/// </summary>
		/// <param name="value">The y local position shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativeLocalPosY(this Transform transform, float value) {
		transform.localPosition += new Vector3(0, value, 0);
		return transform;
	}

	/// <summary>
		/// Sets the z local position of a transform relative to the actual z local position.
		/// </summary>
		/// <param name="value">The z local position shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativeLocalPosZ(this Transform transform, float value) {
		transform.localPosition += new Vector3(0, 0, value);
		return transform;
	}

	/// <summary>
		/// Sets the x rotation of a transform.
		/// </summary>
		/// <param name="value">The new x rotation.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRotationX(this Transform transform, float value) {
		Vector3 euler = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(value, euler.y, euler.z);
		return transform;
	}

	/// <summary>
		/// Sets the y rotation of a transform.
		/// </summary>
		/// <param name="value">The new y rotation.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRotationY(this Transform transform, float value) {
		Vector3 euler = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(euler.x, value, euler.z);
		return transform;
	}

	/// <summary>
		/// Sets the z rotation of a transform.
		/// </summary>
		/// <param name="value">The new z rotation.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRotationZ(this Transform transform, float value) {
		Vector3 euler = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(euler.x, euler.y, value);
		return transform;
	}

	/// <summary>
		/// Sets the x rotation of a transform relative to the actual x rotation.
		/// </summary>
		/// <param name="value">The x rotation shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativeRotationX(this Transform transform, float value) {
		Vector3 euler = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(euler.x + value, euler.y, euler.z);
		return transform;
	}

	/// <summary>
		/// Sets the y rotation of a transform relative to the actual y rotation.
		/// </summary>
		/// <param name="value">The y rotation shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativeRotationY(this Transform transform, float value) {
		Vector3 euler = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(euler.x, euler.y + value, euler.z);
		return transform;
	}

	/// <summary>
		/// Sets the z rotation of a transform relative to the actual z rotation.
		/// </summary>
		/// <param name="value">The z rotation shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativeRotationZ(this Transform transform, float value) {
		Vector3 euler = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(euler.x, euler.y, euler.z + value);
		return transform;
	}

	/// <summary>
		/// Sets the x local rotation of a transform.
		/// </summary>
		/// <param name="value">The new x local rotation.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetLocalRotationX(this Transform transform, float value) {
		Vector3 euler = transform.localRotation.eulerAngles;
		transform.localRotation = Quaternion.Euler(value, euler.y, euler.z);
		return transform;
	}

	/// <summary>
		/// Sets the y local rotation of a transform.
		/// </summary>
		/// <param name="value">The new y local rotation.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetLocalRotationY(this Transform transform, float value) {
		Vector3 euler = transform.localRotation.eulerAngles;
		transform.localRotation = Quaternion.Euler(euler.x, value, euler.z);
		return transform;
	}

	/// <summary>
		/// Sets the z local rotation of a transform.
		/// </summary>
		/// <param name="value">The new z local rotation.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetLocalRotationZ(this Transform transform, float value) {
		Vector3 euler = transform.localRotation.eulerAngles;
		transform.localRotation = Quaternion.Euler(euler.x, euler.y, value);
		return transform;
	}

	/// <summary>
		/// Sets the x local rotation of a transform relative to the actual x local rotation.
		/// </summary>
		/// <param name="value">The x local rotation shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativeLocalRotationX(this Transform transform, float value) {
		Vector3 euler = transform.localRotation.eulerAngles;
		transform.localRotation = Quaternion.Euler(euler.x + value, euler.y, euler.z);
		return transform;
	}

	/// <summary>
		/// Sets the y local rotation of a transform relative to the actual y local rotation.
		/// </summary>
		/// <param name="value">The y local rotation shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativeLocalRotationY(this Transform transform, float value) {
		Vector3 euler = transform.localRotation.eulerAngles;
		transform.localRotation = Quaternion.Euler(euler.x, euler.y + value, euler.z);
		return transform;
	}

	/// <summary>
		/// Sets the z local rotation of a transform relative to the actual z local rotation.
		/// </summary>
		/// <param name="value">The z local rotation shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativeLocalRotationZ(this Transform transform, float value) {
		Vector3 euler = transform.localRotation.eulerAngles;
		transform.localRotation = Quaternion.Euler(euler.x, euler.y, euler.z + value);
		return transform;
	}

	/// <summary>
		/// Sets the x scale of a transform.
		/// </summary>
		/// <param name="value">The new x scale.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetScaleX(this Transform transform, float value) {
		transform.localScale = new Vector3(value, transform.localScale.y, transform.localScale.z);
		return transform;
	}

	/// <summary>
		/// Sets the y scale of a transform.
		/// </summary>
		/// <param name="value">The new y scale.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetScaleY(this Transform transform, float value) {
		transform.localScale = new Vector3(transform.localScale.x, value, transform.localScale.z);
		return transform;
	}

	/// <summary>
		/// Sets the z scale of a transform.
		/// </summary>
		/// <param name="value">The new z scale.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetScaleZ(this Transform transform, float value) {
		transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, value);
		return transform;
	}

	/// <summary>
		/// Sets the x scale of a transform relative to the actual x scale.
		/// </summary>
		/// <param name="value">The x scale shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativeScaleX(this Transform transform, float value) {
		transform.localScale = new Vector3(transform.localScale.x + value, transform.localScale.y, transform.localScale.z);
		return transform;
	}

	/// <summary>
		/// Sets the y scale of a transform relative to the actual y scale.
		/// </summary>
		/// <param name="value">The y scale shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativeScaleY(this Transform transform, float value) {
		transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + value, transform.localScale.z);
		return transform;
	}

	/// <summary>
		/// Sets the z scale of a transform relative to the actual z scale.
		/// </summary>
		/// <param name="value">The z scale shift value.</param>
		/// <returns>Returns the transform so you can chain the functions.</returns>
	public static Transform SetRelativeScaleZ(this Transform transform, float value) {
		transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + value);
		return transform;
	}

	/// <summary>
		/// Returns the root parent (first parent in the hierarchy)
		/// </summary>
		/// <param name="name">The name that the parent must have.</param>
	public static Transform GetRootParent(this Transform transform) {
		if (transform.parent) {
			return transform.parent.GetRootParent();
		}
		else {
			return transform;
		}
	}

	/// <summary>
		/// Returns the first parent that has the requested name, from the actual transform up.
		/// </summary>
		/// <param name="name">The name that the parent must have.</param>
	public static Transform GetParentWithName(this Transform transform, string name) {
		if (transform.parent == null) {
			return null;
		}
		if (transform.parent.name == name) {
			return transform.parent;
		}
		else {
			return transform.parent.GetParentWithName(name);
		}
	}

	/// <summary>
		/// Returns the first parent that has the requested tag, from the actual transform up.
		/// </summary>
		/// <param name="tag">The tag that the parent must have.</param>
	public static Transform GetParentWithTag(this Transform transform, string tag) {
		if (transform.parent == null) {
			return null;
		}
		if (transform.parent.tag == tag) {
			return transform.parent;
		}
		else {
			return transform.parent.GetParentWithTag(tag);
		}
	}

	/// <summary>
		/// Returns all parents that have the requested name, from the actual transform up.
		/// </summary>
		/// <param name="name">The name that the parents must have.</param>
	public static List<Transform> GetParentsWithName(this Transform transform, string name) {
		if (transform.parent == null) {
			return null;
		}
		List<Transform> returnValue = new List<Transform>();
		Transform actualTransform = transform.parent;

		while (actualTransform.parent != null) {
			actualTransform = actualTransform.parent;
			if (actualTransform.name == name) {
				returnValue.Add(actualTransform);
			}
		}
		return returnValue.Count > 0 ? returnValue : null;
	}

	/// <summary>
		/// Returns all parents that have the requested tag, from the actual transform up.
		/// </summary>
		/// <param name="tag">The tag that the parents must have.</param>
	public static List<Transform> GetParentsWithTag(this Transform transform, string tag) {
		if (transform.parent == null) {
			return null;
		}
		List<Transform> returnValue = new List<Transform>();
		Transform actualTransform = transform.parent;

		while (actualTransform.parent != null) {
			actualTransform = actualTransform.parent;
			if (actualTransform.tag == tag) {
				returnValue.Add(actualTransform);
			}
		}
		return returnValue.Count > 0 ? returnValue : null;
	}

	/// <summary>
		/// Returns the first child that has the requested name, using in-depth search. This can get quite slow with a huge children list.
		/// </summary>
		/// <param name="name">The name that the child must have.</param>
	public static Transform GetChildWithName(this Transform transform, string name) {
		if (transform.name == name) {
			return transform;
		}

		if (transform.childCount == 0) {
			return null;
		}

		for (int i = 0; i < transform.childCount; i++) {
			Transform value = transform.GetChild(i).GetChildWithName(name);
			if (value != null) {
				return value;
			}
		}

		return null;
	}

	/// <summary>
		/// Returns all children that have the requested tag, using in-depth search. This can get quite slow with a huge children list.
		/// </summary>
		/// <param name="tag">The tag that the child must have.</param>
	public static Transform GetChildWithTag(this Transform transform, string tag) {
		if (transform.tag == tag) {
			return transform;
		}

		if (transform.childCount == 0) {
			return null;
		}

		for (int i = 0; i < transform.childCount; i++) {
			Transform value = transform.GetChild(i).GetChildWithTag(tag);
			if (value != null) {
				return value;
			}
		}

		return null;
	}

/* ---------------------- SPRITE RENDERER ---------------------- */

	/// <summary>
		/// Sets the red value of the color of a sprite renderer.
		/// </summary>
		/// <param name="value">The new red value</param>
		/// <returns>Returns the sprite renderer so you can chain the functions.</returns>
	public static SpriteRenderer SetRed(this SpriteRenderer renderer, float value) {
		renderer.color = new Color(Mathf.Clamp(value, 0, 1), renderer.color.g, renderer.color.b, renderer.color.a);
		return renderer;
	}

	/// <summary>
		/// Sets the green value of the color of a sprite renderer.
		/// </summary>
		/// <param name="value">The new green value</param>
		/// <returns>Returns the sprite renderer so you can chain the functions.</returns>
	public static SpriteRenderer SetGreen(this SpriteRenderer renderer, float value) {
		renderer.color = new Color(renderer.color.r, Mathf.Clamp(value, 0, 1), renderer.color.b, renderer.color.a);
		return renderer;
	}

	/// <summary>
		/// Sets the blue value of a sprite renderer.
		/// </summary>
		/// <param name="value">The new blue value</param>
		/// <returns>Returns the sprite renderer so you can chain the functions.</returns>
	public static SpriteRenderer SetBlue(this SpriteRenderer renderer, float value) {
		renderer.color = new Color(renderer.color.r, renderer.color.g, Mathf.Clamp(value, 0, 1), renderer.color.a);
		return renderer;
	}

	/// <summary>
		/// Sets the alpha value of a sprite renderer.
		/// </summary>
		/// <param name="value">The new alpha value</param>
		/// <returns>Returns the sprite renderer so you can chain the functions.</returns>
	public static SpriteRenderer SetAlpha(this SpriteRenderer renderer, float value) {
		renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, Mathf.Clamp(value, 0, 1));
		return renderer;
	}

	/// <summary>
		/// Sets the red value of the color of a sprite renderer relative to the actual red value.
		/// </summary>
		/// <param name="value">The red shift value.</param>
		/// <returns>Returns the sprite renderer so you can chain the functions.</returns>
	public static SpriteRenderer SetRelativeRed(this SpriteRenderer renderer, float value) {
		renderer.color = new Color(Mathf.Clamp(renderer.color.r + value, 0, 1), renderer.color.g, renderer.color.b, renderer.color.a);
		return renderer;
	}

	/// <summary>
		/// Sets the green value of the color of a sprite renderer relative to the actual green value.
		/// </summary>
		/// <param name="value">The green shift value.</param>
		/// <returns>Returns the sprite renderer so you can chain the functions.</returns>
	public static SpriteRenderer SetRelativeGreen(this SpriteRenderer renderer, float value) {
		renderer.color = new Color(renderer.color.r, Mathf.Clamp(renderer.color.g + value, 0, 1), renderer.color.b, renderer.color.a);
		return renderer;
	}

	/// <summary>
		/// Sets the blue value of the color of a sprite renderer relative to the actual blue value.
		/// </summary>
		/// <param name="value">The blue shift value.</param>
		/// <returns>Returns the sprite renderer so you can chain the functions.</returns>
	public static SpriteRenderer SetRelativeBlue(this SpriteRenderer renderer, float value) {
		renderer.color = new Color(renderer.color.r, renderer.color.g, Mathf.Clamp(renderer.color.b + value, 0, 1), renderer.color.a);
		return renderer;
	}

	/// <summary>
		/// Sets the alpha value of the color of a sprite renderer relative to the actual alpha value.
		/// </summary>
		/// <param name="value">The alpha shift value.</param>
		/// <returns>Returns the sprite renderer so you can chain the functions.</returns>
	public static SpriteRenderer SetRelativeAlpha(this SpriteRenderer renderer, float value) {
		renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, Mathf.Clamp(renderer.color.a + value, 0, 1));
		return renderer;
	}

/* ---------------------- RIGIDBODY ---------------------- */

	/// <summary>
		/// Sets the x velocity of a rigidbody.
		/// </summary>
		/// <param name="value">The new x velocity.</param>
		/// <returns>Returns the rigidbody so you can chain the functions.</returns>
	public static Rigidbody SetVelocityX(this Rigidbody rigidbody, float value) {
		rigidbody.velocity = new Vector3(value, rigidbody.velocity.y, rigidbody.velocity.z);
		return rigidbody;
	}

	/// <summary>
		/// Sets the y velocity of a rigidbody.
		/// </summary>
		/// <param name="value">The new y velocity.</param>
		/// <returns>Returns the rigidbody so you can chain the functions.</returns>
	public static Rigidbody SetVelocityY(this Rigidbody rigidbody, float value) {
		rigidbody.velocity = new Vector3(rigidbody.velocity.x, value, rigidbody.velocity.z);
		return rigidbody;
	}

	/// <summary>
		/// Sets the z velocity of a rigidbody.
		/// </summary>
		/// <param name="value">The new z velocity.</param>
		/// <returns>Returns the rigidbody so you can chain the functions.</returns>
	public static Rigidbody SetVelocityZ(this Rigidbody rigidbody, float value) {
		rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, value);
		return rigidbody;
	}

	/// <summary>
		/// Sets the x velocity of a rigidbody relative to the actual x velocity.
		/// </summary>
		/// <param name="value">The x velocity shift value.</param>
		/// <returns>Returns the rigidbody so you can chain the functions.</returns>
	public static Rigidbody SetRelativeVelocityX(this Rigidbody rigidbody, float value) {
		rigidbody.velocity += new Vector3(value, 0, 0);
		return rigidbody;
	}

	/// <summary>
		/// Sets the y velocity of a rigidbody relative to the actual y velocity.
		/// </summary>
		/// <param name="value">The y velocity shift value.</param>
		/// <returns>Returns the rigidbody so you can chain the functions.</returns>
	public static Rigidbody SetRelativeVelocityY(this Rigidbody rigidbody, float value) {
		rigidbody.velocity += new Vector3(0, value, 0);
		return rigidbody;
	}

	/// <summary>
		/// Sets the z velocity of a rigidbody relative to the actual z velocity.
		/// </summary>
		/// <param name="value">The z velocity shift value.</param>
		/// <returns>Returns the rigidbody so you can chain the functions.</returns>
	public static Rigidbody SetRelativeVelocityZ(this Rigidbody rigidbody, float value) {
		rigidbody.velocity += new Vector3(0, 0, value);
		return rigidbody;
	}

	/// <summary>
		/// Change the moving direction of a rigidbody without modifying speed.
		/// </summary>
		/// <returns>Returns the rigidbody so you can chain the functions.</returns>
	public static Rigidbody ChangeDirection(this Rigidbody rigidbody, Vector3 newDirection) {
		rigidbody.velocity = rigidbody.velocity.magnitude * newDirection.normalized;
		return rigidbody;
	}

/* ---------------------- RIGIDBODY 2D ---------------------- */

	/// <summary>
		/// Sets the x velocity of a rigidbody2D.
		/// </summary>
		/// <param name="value">The new x velocity.</param>
		/// <returns>Returns the rigidbody2D so you can chain the functions.</returns>
	public static Rigidbody2D SetVelocityX(this Rigidbody2D rigidbody, float value) {
		rigidbody.velocity = new Vector2(value, rigidbody.velocity.y);
		return rigidbody;
	}

	/// <summary>
		/// Sets the y velocity of a rigidbody2D.
		/// </summary>
		/// <param name="value">The new y velocity.</param>
		/// <returns>Returns the rigidbody2D so you can chain the functions.</returns>
	public static Rigidbody2D SetVelocityY(this Rigidbody2D rigidbody, float value) {
		rigidbody.velocity = new Vector2(rigidbody.velocity.x, value);
		return rigidbody;
	}

	/// <summary>
		/// Sets the x velocity of a rigidbody2D relative to the actual y velocity.
		/// </summary>
		/// <param name="value">The x velocity shift value.</param>
		/// <returns>Returns the rigidbody2D so you can chain the functions.</returns>
	public static Rigidbody2D SetRelativeVelocityX(this Rigidbody2D rigidbody, float value) {
		rigidbody.velocity += new Vector2(value, 0);
		return rigidbody;
	}

	/// <summary>
		/// Sets the y velocity of a rigidbody2D relative to the actual y velocity.
		/// </summary>
		/// <param name="value">The y velocity shift value.</param>
		/// <returns>Returns the rigidbody2D so you can chain the functions.</returns>
	public static Rigidbody2D SetRelativeVelocityY(this Rigidbody2D rigidbody, float value) {
		rigidbody.velocity += new Vector2(0, value);
		return rigidbody;
	}

/* ---------------------- VECTOR 3 ---------------------- */

	/// <summary>
		/// Returns a new vector3 with a new x value.
		/// </summary>
	public static Vector3 WithX(this Vector3 vector, float value) {
		return new Vector3(value, vector.y, vector.z);
	}

	/// <summary>
		/// Returns a new vector3 with a new y value.
		/// </summary>
	public static Vector3 WithY(this Vector3 vector, float value) {
		return new Vector3(vector.x, value, vector.z);
	}

	/// <summary>
		/// Returns a new vector3 with a new z value.
		/// </summary>
	public static Vector3 WithZ(this Vector3 vector, float value) {
		return new Vector3(vector.x, vector.y, value);
	}

	/// <summary>
		/// Returns a new vector3 with a new x value relative to the actual x value.
		/// </summary>
	public static Vector3 WithRelativeX(this Vector3 vector, float value) {
		return new Vector3(vector.x + value, vector.y, vector.z);
	}

	/// <summary>
		/// Returns a new vector3 with a new y value relative to the actual y value.
		/// </summary>
	public static Vector3 WithRelativeY(this Vector3 vector, float value) {
		return new Vector3(vector.x, vector.y + value, vector.z);
	}

	/// <summary>
		/// Returns a new vector3 with a new z value relative to the actual z value.
		/// </summary>
	public static Vector3 WithRelativeZ(this Vector3 vector, float value) {
		return new Vector3(vector.x, vector.y, vector.z + value);
	}

	/// <summary>
		/// Returns a new vector3 composed of all components rounded to the nearest integer.
		/// </summary>
	public static Vector3 Round(this Vector3 vector) {
		return new Vector3(Mathf.Round(vector.x), Mathf.Round(vector.y), Mathf.Round(vector.z));
	}
	
	/// <summary>
		/// Returns a new vector3 composed of all components rounded up.
		/// </summary>
	public static Vector3 Ceil(this Vector3 vector) {
		return new Vector3(Mathf.Ceil(vector.x), Mathf.Ceil(vector.y), Mathf.Ceil(vector.z));
	}

	/// <summary>
		/// Returns a new vector3 composed of all components rounded down.
		/// </summary>
	public static Vector3 Floor(this Vector3 vector) {
		return new Vector3(Mathf.Floor(vector.x), Mathf.Floor(vector.y), Mathf.Floor(vector.z));
	}

	/// <summary>
		/// Returns a new vector3 composed of all components rounded down.
		/// </summary>
	public static Vector3 Clamp(this Vector3 vector, Vector3 clampVector1, Vector3 clampVector2) {
		return new Vector3(Mathf.Clamp(vector.x, Mathf.Min(clampVector1.x, clampVector2.x), Mathf.Max(clampVector1.x, clampVector2.x)),
		Mathf.Clamp(vector.y, Mathf.Min(clampVector1.y, clampVector2.y), Mathf.Max(clampVector1.y, clampVector2.y)),
		Mathf.Clamp(vector.z, Mathf.Min(clampVector1.z, clampVector2.z), Mathf.Max(clampVector1.z, clampVector2.z)));
	}

	/// <summary>
		/// Returns a new vector2 composed of the x and y coordinates.
		/// </summary>
	public static Vector2 XY(this Vector3 vector) {
		return new Vector2(vector.x, vector.y);
	}

	/// <summary>
		/// Returns a new vector2 composed of the x and z coordinates.
		/// </summary>
	public static Vector2 XZ(this Vector3 vector) {
		return new Vector2(vector.x, vector.z);
	}

	/// <summary>
		/// Returns a new vector2 composed of the y and z coordinates.
		/// </summary>
	public static Vector2 YZ(this Vector3 vector) {
		return new Vector2(vector.y, vector.z);
	}

/* ---------------------- VECTOR 2 ---------------------- */

	/// <summary>
		/// Returns a new vector2 with a new x value.
		/// </summary>
	public static Vector2 WithX(this Vector2 vector, float value) {
		return new Vector2(value, vector.y);
	}

	/// <summary>
		/// Returns a new vector2 with a new y value.
		/// </summary>
	public static Vector2 WithY(this Vector2 vector, float value) {
		return new Vector2(vector.x, value);
	}

	/// <summary>
		/// Returns a new vector3 with a new z value.
		/// </summary>
	public static Vector3 WithZ(this Vector2 vector, float value) {
		return new Vector3(vector.x, vector.y, value);
	}

	/// <summary>
		/// Returns a new vector2 with a new x value relative to the actual x value.
		/// </summary>
	public static Vector2 WithRelativeX(this Vector2 vector, float value) {
		return new Vector2(vector.x + value, vector.y);
	}

	/// <summary>
		/// Returns a new vector2 with a new y value relative to the actual y value.
		/// </summary>
	public static Vector2 WithRelativeY(this Vector2 vector, float value) {
		return new Vector2(vector.x, vector.y + value);
	}

	/// <summary>
		/// Returns a new vector2 composed of all components rounded to the nearest integer.
		/// </summary>
	public static Vector2 Round(this Vector2 vector) {
		return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
	}
	
	/// <summary>
		/// Returns a new vector2 composed of all components rounded up.
		/// </summary>
	public static Vector2 Ceil(this Vector2 vector) {
		return new Vector2(Mathf.Ceil(vector.x), Mathf.Ceil(vector.y));
	}

	/// <summary>
		/// Returns a new vector2 composed of all components rounded down.
		/// </summary>
	public static Vector2 Floor(this Vector2 vector) {
		return new Vector2(Mathf.Floor(vector.x), Mathf.Floor(vector.y));
	}

/* ---------------------- STRING ---------------------- */

	/// <summary>
		/// Returns a new string composed of the same string with the first character to upper case.
		/// </summary>
	public static String Capitalize(this String str) {
		return char.ToUpper(str[0]) + str.Substring(1);
	}

	/// <summary>
		/// Returns a new string with the given color.
		/// </summary>
	public static string Colored(this string message, Color color) {
		return string.Format("<color={0}>{1}</color>", color.ToHex(true), message);
	}

	/// <summary>
		/// Returns a new string in bold.
		/// </summary>
	public static string Bold(this string message) {
		return string.Format("<b>{0}</b>", message);
	}

	/// <summary>
		/// Returns a new string in italic.
		/// </summary>
	public static string Italic(this string message) {
		return string.Format("<i>{0}</i>", message);
	}

	/// <summary>
		/// Returns a new string with the given size.
		/// </summary>
	public static string Sized(this string message, int size) {
		return string.Format("<size={0}>{1}</size>", size, message);
	}

	/// <summary>
		/// Returns a colorized string of the Vector3 (x component in red, y component in green, z component in blue).
		/// </summary>
		/// <param name="format">The string format for the components.</param>
	public static string ToColorizedString(this Vector3 vector, string format = "F2") {
		return string.Format("Vector3(<color=#FF0000>X: {0}</color>,<color=#00FF00> Y: {1}</color>, <color=#0088FF>Z: {2}</color>)", vector.x.ToString(format), vector.y.ToString(format), vector.z.ToString(format));
	}

	public static bool IsNullOrEmpty(this string str) {
		return str == string.Empty || str == null;
	}

	/// <summary>
		/// Returns a string value as an enum field
		/// </summary>
	public static T ToEnum<T>(this string value, T defaultValue) where T : struct, IConvertible {
		if (!typeof(T).IsEnum) {
			Debug.LogError("Generic type T must be an enum");
			return defaultValue;
		}

		T test;
		
		try {
			test = (T)Enum.Parse (typeof(T), value);
		}
		catch {
			Debug.LogError(value + " could not be parsed into an enum of generic type T");
			return defaultValue;
		}
		
		return test;
	}

/* ---------------------- BOOLEAN ---------------------- */

   
	/// <summary>
		/// Returns a float depending on the boolean status.
		/// </summary>
		/// <param name="valueIfFalse">The value to return if it is false.</param>
		/// <param name="valueIfTrue">The value to return if it is true.</param>
		/// <returns></returns>
	public static float ToFloat(this bool boolean, float valueIfFalse, float valueIfTrue) {
		if (boolean) {
			return valueIfTrue;
		}
		return valueIfFalse;
	}

/* ---------------------- COLOR ---------------------- */

	/// <summary>
		/// Converts a color into a hex string
		/// </summary>
	public static string ToHex(this Color color, bool includeHash = false) {
		string red = Mathf.FloorToInt(color.r * 255).ToString("X2");
		string green = Mathf.FloorToInt(color.g * 255).ToString("X2");
		string blue = Mathf.FloorToInt(color.b * 255).ToString("X2");
		return (includeHash ? "#" : "") + red + green + blue;
	}

	/// <summary>
		/// Converts a hex string into a color
		/// </summary>
	public static Color ToColor(this string color) {
		// remove the # character if there is one.
		color = color.TrimStart('#');
		float red = (HexToInt(color[1]) + HexToInt(color[0]) * 16f) / 255f;
		float green = (HexToInt(color[3]) + HexToInt(color[2]) * 16f) / 255f;
		float blue = (HexToInt(color[5]) + HexToInt(color[4]) * 16f) / 255f;
		Color finalColor = new Color(red, green, blue, 1);
		return finalColor;
	}

	/// <summary>
		/// Creates a color from a Vector3 with the 255 rgb values (sets alpha to 255).
		/// </summary>
	public static Color ToColor(this Vector3 vector) {
		return new Color(vector.x / 255f, vector.y / 255f, vector.z / 255f, 1);
	}

	/// <summary>
		/// Creates a color from a Vector4 with the 255 rgb values.
		/// </summary>
	public static Color ToColor(this Vector4 vector) {
		return new Color(vector.x / 255f, vector.y / 255f, vector.z / 255f, vector.w / 255f);
	}

	/// <summary>
		/// Returns the hexadecimal value of an character
		/// </summary>
	private static int HexToInt(char hexValue) {
		return int.Parse(hexValue.ToString(), System.Globalization.NumberStyles.HexNumber);
	}
/* -----------------------LIST------------------------ */
	
	/// <summary>
		/// Adds the element only if it's not already in the list.
		/// </summary>
		/// <returns>Returns true if the element was added.</returns>
	public static bool AddUnique<T>(this List<T> list, T element) {
		if (!list.Contains(element)) {
			list.Add(element);
			return true;
		}
		return false;
	}

	public static T GetRandom<T>(this List<T> list) {
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public static bool IsConsistent<T>(this List<T> list) {
		int i = 1;

		for (i = 1; i < list.Count; i++) {
			if (!list[i].Equals(list[i - 1])) {
				return false;
			}
		}

		return true;
	}

	public static void Fill<T>(this List<T> list, T element, int amount) {
		if (list == null) {
			return;
		}

		for (int i = 0; i < amount; i++) {
			list.Add(element);
		}
	}

	public static bool IsNullOrEmpty<T>(this List<T> list) {
		return (list == null || list.Count == 0);
	}

/* -----------------------ARRAY------------------------ */

    /* -----------------------ARRAY------------------------ */

    public static T GetRandom<T>(this T[] array) {
		return array[UnityEngine.Random.Range(0, array.Length)];
	}

	public static bool Contains<T>(this T[] array, T element) {
		if (array.Length == 0) {
			return false;
		}

		for (int i = 0; i < array.Length; i++) {
			if (array[i].Equals(element)) {
				return true;
			}
		}

		return false;
	}

	public static void Fill<T>(this T[] array, T element) {
		if (array.IsNullOrEmpty()) {
			return;
		}

		for (int i = 0; i < array.Length; i++) {
			array[i] = element;
		}
	}

	public static bool IsConsistent<T>(this T[] array) {
		int i = 1;

		for (i = 1; i < array.Length; i++) {
			if (!array[i].Equals(array[i - 1])) {
				return false;
			}
		}

		return true;
	}

	public static List<T> ToList<T>(this T[] array) {
		List<T> temp = new List<T>();

		foreach(T elem in array) {
			temp.Add(elem);
		}

		return temp;
	}

	public static bool IsNullOrEmpty<T>(this T[] array) {
		return array == null || array.Length == 0;
	}

/* ---------------------- OTHER ---------------------- */

	/// <summary>
		/// Returns true if source is between or equal to valueMin and valueMax.
		/// </summary>
		/// <param name="equalMin">True if source can be equal to valueMin.</param>
		/// <param name="equalMax">True if source can be equal to valueMax.</param>
	public static bool IsBetween<T>(this T source, T value1, T value2, bool equalValue1 = true, bool equalValue2 = true) where T : IComparable<T> {
		if (source == null) {
			throw new ArgumentNullException("source");
		}

		if (value1.CompareTo(value2) > 0) {
			T wait = value1;
			value1 = value2;
			value2 = wait;
			bool wait2 = equalValue1;
			equalValue1 = equalValue2;
			equalValue2 = wait2;
		}

		return (((equalValue1 && source.CompareTo(value1) >= 0) || (!equalValue1 && source.CompareTo(value1) > 0)) && ((equalValue2 && source.CompareTo(value2) <= 0) || (!equalValue2 && source.CompareTo(value2) < 0)));
	}
}