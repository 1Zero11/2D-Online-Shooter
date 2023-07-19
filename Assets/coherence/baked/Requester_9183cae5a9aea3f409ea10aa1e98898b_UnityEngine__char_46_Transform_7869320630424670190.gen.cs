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

	public struct Requester_9183cae5a9aea3f409ea10aa1e98898b_UnityEngine__char_46_Transform_7869320630424670190 : ICoherenceComponentData
	{
		public Vector3 position;

		public override string ToString()
		{
			return $"Requester_9183cae5a9aea3f409ea10aa1e98898b_UnityEngine__char_46_Transform_7869320630424670190(position: {position})";
		}

		public uint GetComponentType() => Definition.InternalRequester_9183cae5a9aea3f409ea10aa1e98898b_UnityEngine__char_46_Transform_7869320630424670190;

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
			var other = (Requester_9183cae5a9aea3f409ea10aa1e98898b_UnityEngine__char_46_Transform_7869320630424670190)data;
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

		public static uint Serialize(Requester_9183cae5a9aea3f409ea10aa1e98898b_UnityEngine__char_46_Transform_7869320630424670190 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				var fieldValue = (data.position.ToCoreVector3());

				bitStream.WriteVector3(fieldValue, FloatMeta.NoCompression());
			}
			mask >>= 1;

			return mask;
		}

		public static (Requester_9183cae5a9aea3f409ea10aa1e98898b_UnityEngine__char_46_Transform_7869320630424670190, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new Requester_9183cae5a9aea3f409ea10aa1e98898b_UnityEngine__char_46_Transform_7869320630424670190();
	
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
			var last = lastSent as Requester_9183cae5a9aea3f409ea10aa1e98898b_UnityEngine__char_46_Transform_7869320630424670190?;
	
		}
	}
}