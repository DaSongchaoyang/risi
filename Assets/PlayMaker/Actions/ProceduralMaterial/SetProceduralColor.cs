// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Substance")]
	[Tooltip("Set a named color property in a Substance material. NOTE: Use Rebuild Textures after setting Substance properties.")]
	public class SetProceduralColor : FsmStateAction
	{
		[RequiredField]
        [Tooltip("The Substance Material.")]
		public FsmMaterial substanceMaterial;

		[RequiredField]
        [Tooltip("The named color property in the material.")]
		public FsmString colorProperty;

		[RequiredField]
        [Tooltip("The value to set the property to.")]
		public FsmColor colorValue;

		[Tooltip("NOTE: Updating procedural materials every frame can be very slow!")]
		public bool everyFrame;

		public override void Reset()
		{
			substanceMaterial = null;
			colorProperty = "";
			colorValue = Color.white;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoSetProceduralFloat();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoSetProceduralFloat();
		}

	    private void DoSetProceduralFloat()
        {
#if !(UNITY_IPHONE || UNITY_IOS || UNITY_ANDROID || UNITY_NACL || UNITY_FLASH || UNITY_PS3 || UNITY_PS4 || UNITY_XBOXONE || UNITY_BLACKBERRY || UNITY_METRO || UNITY_WP8 || UNITY_WIIU || UNITY_PSM || UNITY_WEBGL)

            var substance = substanceMaterial.Value as ProceduralMaterial;
			if (substance == null)
			{
                LogError("The Material is not a Substance Material!");
                return;
			}

			substance.SetProceduralColor(colorProperty.Value, colorValue.Value);
#endif
        }
	}
}