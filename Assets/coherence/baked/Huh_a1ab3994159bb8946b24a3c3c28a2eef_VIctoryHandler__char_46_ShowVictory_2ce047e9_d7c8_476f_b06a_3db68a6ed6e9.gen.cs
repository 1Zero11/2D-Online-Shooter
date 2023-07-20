// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using Coherence.ProtocolDef;
	using Coherence.Serializer;
	using Coherence.Brook;
	using UnityEngine;
	using Coherence.Entity;

	public struct Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9 : IEntityCommand
	{
		public Color color;
		public int coins;

		public MessageTarget Routing => MessageTarget.All;
		public uint GetComponentType() => Definition.InternalHuh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9;

		public Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9
		(
			Color datacolor,
			int datacoins
		)
		{
			color = datacolor;
			coins = datacoins;
		}

		public static void Serialize(Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9 commandData, IOutProtocolBitStream bitStream)
		{
			var converted_color = commandData.color.ToCoreColor();
			bitStream.WriteColor(converted_color, FloatMeta.ForFixedPoint(0, 1, 2.3283064370807973753052522170037E-10));
			bitStream.WriteIntegerRange(commandData.coins, 32, -2147483648);
		}

		public static Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9 Deserialize(IInProtocolBitStream bitStream)
		{
			var converted_color = bitStream.ReadColor(FloatMeta.ForFixedPoint(0, 1, 2.3283064370807973753052522170037E-10));
			var datacolor = converted_color.ToUnityColor();
			var datacoins = bitStream.ReadIntegerRange(32, -2147483648);

			return new Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9
			(
				datacolor,
				datacoins
			){};
		}
	}
}
