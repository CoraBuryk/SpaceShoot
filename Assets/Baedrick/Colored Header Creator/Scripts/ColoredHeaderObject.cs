using UnityEditor;
using UnityEngine;

namespace Baedrick.ColoredHeaderCreator
{
	[ExecuteAlways]
	public class ColoredHeaderObject : MonoBehaviour
	{

#if UNITY_EDITOR

		public HeaderSettings headerSettings = new HeaderSettings();

		// If values change when in Edit Mode
		void OnValidate()
		{
			EditorApplication.RepaintHierarchyWindow();
		}

		void Update()
		{
			if (headerSettings.editorOnly)
				gameObject.tag = "EditorOnly";
			else
				gameObject.tag = "Untagged";
		}

#endif // UNITY_EDITOR

	} // class ColoredHeaderObject

} // namespace