using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Utils
{
    public static Vector2 VecFromAngleMagnitude(float angle, float magnitude)
    {
        return new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle) * magnitude, Mathf.Sin(Mathf.Deg2Rad * angle) * magnitude);
    }

    /*
     From http://answers.unity3d.com/questions/523409/strategy-pattern-with-monobehaviours.html
    */
    public static List<T> GetBehaviorsWithInterface<T>(GameObject objectToSearch) where T : class
    {
        MonoBehaviour[] list = objectToSearch.GetComponents<MonoBehaviour>();
        List<T> resultList = new List<T>();
        foreach (MonoBehaviour mb in list)
        {
            if (mb is T)
            {
                //found one
                resultList.Add((T)((System.Object)mb));
            }
        }

        return resultList;
    }

	public static List<T> GetComponentsInChildren<T>(GameObject objectToSearch) where T : class
	{
		List<T> resultList = new List<T>();

		if(objectToSearch.transform.childCount > 0)
		{
			foreach (Transform child in objectToSearch.transform)
			{
				resultList.AddRange(child.gameObject.GetComponents<T>());
				GetComponentsInChildren_recursive(ref resultList, child.gameObject);
			}
		}
		
		return resultList;
	}

	private static void GetComponentsInChildren_recursive<T>(ref List<T> resultList, GameObject objectToSearch) where T : class
	{
		if(objectToSearch.transform.childCount == 0)
		{
			return;
		}

		foreach (Transform child in objectToSearch.transform)
		{
			resultList.AddRange(child.gameObject.GetComponents<T>());
			GetComponentsInChildren_recursive(ref resultList, child.gameObject);
        }
	}
	
	/*
		Get the behavior with an interface from an object.  If it has multiple behaviors with the interface, the first one is returned.

		If no behaviours can be found, returns null.
    */
	public static T GetBehaviorWithInterface<T>(GameObject objectToSearch) where T : class
	{
		MonoBehaviour[] list = objectToSearch.GetComponents<MonoBehaviour>();
		foreach (MonoBehaviour mb in list)
		{
			if (mb is T)
			{
				//found one
				return (T)((System.Object)mb);
			}
		}
		
		return null;
	}

    /*
        Wait for the current animation clip to f
    */
    public static IEnumerator WaitForAnimation(Animator animator)
    {
		var state = animator.GetCurrentAnimatorStateInfo (0);
        yield return new WaitForSeconds(state.length - state.normalizedTime - .1f);
    }

	public static string DictionaryToString<K, V>(Dictionary<K, V> dict)
	{
		StringBuilder text = new StringBuilder();
		text.Append('{');
		foreach(KeyValuePair<K, V> pair in dict)
		{
			text.Append('[');
			text.Append(pair.Key.ToString());
			text.Append(", ");
			text.Append(pair.Value.ToString());
			text.Append("],");

		}
		text.Append('}');

		
		return text.ToString();
	}
}

