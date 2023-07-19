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

	public struct Counter_58c1faddde8234d4692bc96b9f9ba54c_Counter_6355730035801338076 : ICoherenceComponentData
	{
		public int counter;

		public override string ToString()
		{
			return $"Counter_58c1faddde8234d4692bc96b9f9ba54c_Counter_6355730035801338076(counter: {counter})";
		}

		public uint GetComponentType() => Definition.InternalCounter_58c1faddde8234d4692bc96b9f9ba54c_Counter_6355730035801338076;

		public const int order = 0;

		public uint FieldsMask => 0b00000000000000000000000000000001;

		public int GetComponentOrder() => order;
		public bool IsSendOrdered() { return false; }

		public AbsoluteSimulationFrame Frame;
	
		private static readonly int _counter_Min = -2147483648;
		private static readonly int _counter_Max = 2147483647;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (Counter_58c1faddde8234d4692bc96b9f9ba54c_Counter_6355730035801338076)data;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				counter = other.counter;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			throw new System.NotSupportedException($"{nameof(DiffWith)} is not supported in Unity");

		}

		public static uint Serialize(Counter_58c1faddde8234d4692bc96b9f9ba54c_Counter_6355730035801338076 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.counter, _counter_Min, _counter_Max, "Counter_58c1faddde8234d4692bc96b9f9ba54c_Counter_6355730035801338076.counter");
				data.counter = Coherence.Utils.Bounds.Clamp(data.counter, _counter_Min, _counter_Max);
				var fieldValue = data.counter;

				bitStream.WriteIntegerRange(fieldValue, 32, -2147483648);
			}
			mask >>= 1;

			return mask;
		}

		public static (Counter_58c1faddde8234d4692bc96b9f9ba54c_Counter_6355730035801338076, uint) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new Counter_58c1faddde8234d4692bc96b9f9ba54c_Counter_6355730035801338076();
	
			if (bitStream.ReadMask())
			{
				val.counter = bitStream.ReadIntegerRange(32, -2147483648);
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
			var last = lastSent as Counter_58c1faddde8234d4692bc96b9f9ba54c_Counter_6355730035801338076?;
	
		}
	}
}