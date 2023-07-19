// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using Coherence.ProtocolDef;
	using Coherence.Serializer;
	using Coherence.SimulationFrame;
	using Coherence.Entity;
	using Coherence.Utils;
	using Coherence.Brook;
	using Coherence.Toolkit;
	using UnityEngine;

	public struct Player_acaa15b2fd77b2a4080fa3b9f1088f0e_UnityEngine__char_46_Transform_2827779321465607974 : ICoherenceComponentData
	{
		public Vector3 position;

		public override string ToString()
		{
			return $"Player_acaa15b2fd77b2a4080fa3b9f1088f0e_UnityEngine__char_46_Transform_2827779321465607974(position: {position})";
		}

		public uint GetComponentType() => Definition.InternalPlayer_acaa15b2fd77b2a4080fa3b9f1088f0e_UnityEngine__char_46_Transform_2827779321465607974;

		public const int order = 0;

		public uint FieldsMask => 0b00000000000000000000000000000001;

		public int GetComponentOrder() => order;
		public bool IsSendOrdered() { return false; }

		public AbsoluteSimulationFrame Frame;
	

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (Player_acaa15b2fd77b2a4080fa3b9f1088f0e_UnityEngine__char_46_Transform_2827779321465607974)data;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				position = other.position;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			throw new System.NotSupportedException($"{nameof(DiffWith)} is not supported in Unity");

		}

		public static uint Serialize(Player_acaa15b2fd77b2a4080fa3b9f1088f0e_UnityEngine__char_46_Transform_2827779321465607974 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				var fieldValue = (data.position.ToCoreVector3());

				bitStream.WriteVector3(fieldValue, FloatMeta.NoCompression());
			}
			mask >>= 1;

			return mask;
		}

		public static (Player_acaa15b2fd77b2a4080fa3b9f1088f0e_UnityEngine__char_46_Transform_2827779321465607974, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new Player_acaa15b2fd77b2a4080fa3b9f1088f0e_UnityEngine__char_46_Transform_2827779321465607974();
	
			if (bitStream.ReadMask())
			{
				val.position = (bitStream.ReadVector3(FloatMeta.NoCompression())).ToUnityVector3();
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask);
		}

		/// <summary>
		/// Resets byte array references to the local array instance that is kept in the lastSentData.
		/// If the array content has changed but remains of same length, the new content is copied into the local array instance.
		/// If the array length has changed, the array is cloned and overwrites the local instance.
		/// If the array has not changed, the reference is reset to the local array instance.
		/// Otherwise, changes to other fields on the component might cause the local array instance reference to become permanently lost.
		/// </summary>
		public void ResetByteArrays(ICoherenceComponentData lastSent, uint mask)
		{
			var last = lastSent as Player_acaa15b2fd77b2a4080fa3b9f1088f0e_UnityEngine__char_46_Transform_2827779321465607974?;
	
		}
	}
}