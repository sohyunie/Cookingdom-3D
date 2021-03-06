using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEditor.UI;

[CustomEditor(typeof(UEButton), true)]
[CanEditMultipleObjects]
public class UEButtonEditor : ButtonEditor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        UEButton button = (UEButton)target;
        UEReactionType oldType = button.ReactionType;
        UEReactionType newType = (UEReactionType)EditorGUILayout.EnumPopup("Reaction Type", button.ReactionType);

        if (newType != oldType)
        {
            foreach (Object obj in targets)
            {
                button = (UEButton)obj;
                button.ReactionType = newType;
                EditorUtility.SetDirty(obj);
            }
        }
    }
}
