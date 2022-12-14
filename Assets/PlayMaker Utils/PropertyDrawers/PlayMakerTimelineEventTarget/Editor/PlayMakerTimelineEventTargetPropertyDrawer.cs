// (c) Copyright HutongGames, LLC 2010-2015. All rights reserved.
#if UNITY_2017
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;


namespace HutongGames.PlayMaker.Ecosystem.Utils
{

	[CustomPropertyDrawer (typeof (PlayMakerTimelineEventTarget))]
	public class PlayMakerTimelineEventTargetDrawer : PlayMakerPropertyDrawerBaseClass 
	{

		/// <summary>
		/// The row count. Computed and set by inheriting class
		/// </summary>
		int rowCount;

		public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
		{

			SerializedProperty eventTarget = property.FindPropertyRelative("eventTarget");
	
			rowCount = 0;
			
			// draw the enum popup Field
			int oldEnumIndex = eventTarget.enumValueIndex;
	

			rowCount++;
			
			// Additional fields
			if (eventTarget.enumValueIndex==0) // targeting Owner: needs only the include children field
			{
				rowCount++;
			}else if(eventTarget.enumValueIndex==2) // targeting Broadcasting: needs no additional fields
			{
				//nothing
			}else{ // targeting GameObject or FsmComponent

				if (eventTarget.enumValueIndex==1) // GameObject target
				{
					rowCount++;
					rowCount++;
					
					
				}else if (eventTarget.enumValueIndex==3) // FsmComponent target
				{
					rowCount++;
				}
			}

			return base.GetPropertyHeight(property,label) * rowCount;
		}

		public override void OnGUI (Rect pos, SerializedProperty prop, GUIContent label) {


			SerializedProperty eventTarget = prop.FindPropertyRelative("eventTarget");
			SerializedProperty gameObject = prop.FindPropertyRelative("GameObject");
			SerializedProperty includeChildren = prop.FindPropertyRelative("includeChildren");
			SerializedProperty fsmComponent = prop.FindPropertyRelative("FsmComponent");

			int row = 0;

			// draw the enum popup Field
			int oldEnumIndex = eventTarget.enumValueIndex;


			EditorGUI.PropertyField(
				GetRectforRow(pos,++row -1),
				eventTarget,label,true);


			// Additional fields
			if (eventTarget.enumValueIndex==0) // targeting Owner: needs only the include children field
			{
				EditorGUI.indentLevel++;
				if (eventTarget.enumValueIndex==0)
				{
					EditorGUI.PropertyField(
						GetRectforRow(pos,++row -1),
						includeChildren,new GUIContent("Include Children"),true);
				}
				EditorGUI.indentLevel--;
			}else if(eventTarget.enumValueIndex==2) // targeting Broadcasting: needs no additional fields
			{
				//nothing
			}else{ // targeting GameObject or FsmComponent

				EditorGUI.indentLevel++;

				if (eventTarget.enumValueIndex==1) // GameObject target
				{
					EditorGUI.PropertyField(
						GetRectforRow(pos,++row -1),
						gameObject,new GUIContent("Game Object"),true);

					EditorGUI.PropertyField(
						GetRectforRow(pos,++row -1),
						includeChildren,new GUIContent("Include Children"),true);


				}else if (eventTarget.enumValueIndex==3) // FsmComponent target
				{
					EditorGUI.PropertyField(
						GetRectforRow(pos,++row -1),
						fsmComponent,new GUIContent("Fsm Component"),true);
				}
				EditorGUI.indentLevel--;
			}

			// attempt to refresh UI and avoid glitch
			if (row!=rowCount)
			{
				prop.serializedObject.ApplyModifiedProperties();
				prop.serializedObject.Update();
			}
			// update the rowCount to compute the right interface height
			rowCount = row;
		}


	}
}
#endif