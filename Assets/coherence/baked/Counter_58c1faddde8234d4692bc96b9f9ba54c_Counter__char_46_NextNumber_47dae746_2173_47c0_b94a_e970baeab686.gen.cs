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

	public struct Counter_58c1faddde8234d4692bc96b9f9ba54c_Counter__char_46_NextNumber_47dae746_2173_47c0_b94a_e970baeab686 : IEntityCommand
	{
		public SerializeEntityID requester;

		public MessageTarget Routing => MessageTarget.AuthorityOnly;
		public uint GetComponentType() => Definition.InternalCounter_58c1faddde8234d4692bc96b9f9ba54c_Counter__char_46_NextNumber_47dae746_2173_47c0_b94a_e970baeab686;

		public Counter_58c1faddde8234d4692bc96b9f9ba54c_Counter__char_46_NextNumber_47dae746_2173_47c0_b94a_e970baeab686
		(
			SerializeEntityID datarequester
		)
		{
			requester = datarequester;
		}

		public static void Serialize(Counter_58c1faddde8234d4692bc96b9f9ba54c_Counter__char_46_NextNumber_47dae746_2173_47c0_b94a_e970baeab686 commandData, IOutProtocolBitStream bitStream)
		{
			bitStream.WriteEntity(commandData.requester);
		}

		public static Counter_58c1faddde8234d4692bc96b9f9ba54c_Counter__char_46_NextNumber_47dae746_2173_47c0_b94a_e970baeab686 Deserialize(IInProtocolBitStream bitStream)
		{
			var datarequester = bitStream.ReadEntity();

			return new Counter_58c1faddde8234d4692bc96b9f9ba54c_Counter__char_46_NextNumber_47dae746_2173_47c0_b94a_e970baeab686
			(
				datarequester
			){};
		}
	}
}
