// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using Coherence.Toolkit;
	using Coherence.Toolkit.Bindings;
	using Coherence.Entity;
	using Coherence.ProtocolDef;
	using Coherence.Brook;
	using Coherence.Toolkit.Bindings.ValueBindings;
	using Coherence.Toolkit.Bindings.TransformBindings;
	using Coherence.Connection;
	using Coherence.Log;
	using Logger = Coherence.Log.Logger;
	using UnityEngine.Scripting;

	public class Binding_9183cae5a9aea3f409ea10aa1e98898b_3ab98d2a_0967_4e51_93b7_0aeb2767e543 : PositionBinding
	{
		public override string CoherenceComponentName => "WorldPosition";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override Vector3 Value
		{
			get => (Vector3)(UnityEngine.Vector3)(coherenceSync.coherencePosition);
			set => coherenceSync.coherencePosition = (UnityEngine.Vector3)(value);
		}

		protected override Vector3 ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
		{
			var value = ((WorldPosition)coherenceComponent).value;
			if (!coherenceSync.HasParentWithCoherenceSync)
            {
                value += floatingOriginDelta;
            }
			return value;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, double time)
		{
			var update = (WorldPosition)coherenceComponent;
			if (RuntimeInterpolationSettings.IsInterpolationNone) 
			{
				update.value = Value;
			}
			else 
			{
				update.value = GetInterpolatedAt(time);
			}
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new WorldPosition();
		}
	}


	[Preserve]
	public class CoherenceSyncRequester_9183cae5a9aea3f409ea10aa1e98898b : CoherenceSyncBaked
	{
		private SerializeEntityID entityId;
		private Logger logger = Log.GetLogger<CoherenceSyncRequester_9183cae5a9aea3f409ea10aa1e98898b>();

		// Cached targets for commands		
		private global::NumberRequester Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc_CommandTarget;

		private IClient client;
		private CoherenceBridge bridge;

		private readonly Dictionary<string, Binding> bakedValueBindings = new Dictionary<string, Binding>()
		{
			["3ab98d2a-0967-4e51-93b7-0aeb2767e543"] = new Binding_9183cae5a9aea3f409ea10aa1e98898b_3ab98d2a_0967_4e51_93b7_0aeb2767e543(),
		};

		private Dictionary<string, Action<CommandBinding, CommandsHandler>> bakedCommandBindings =
			new Dictionary<string, Action<CommandBinding, CommandsHandler>>();

		public CoherenceSyncRequester_9183cae5a9aea3f409ea10aa1e98898b()
		{
			bakedCommandBindings.Add("d695b084-e661-4ae0-acc5-4b7a4ec195dc", BakeCommandBinding_Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc);
		}

		public override Binding BakeValueBinding(Binding valueBinding)
		{
			if (bakedValueBindings.TryGetValue(valueBinding.guid, out var bakedBinding))
			{
				valueBinding.CloneTo(bakedBinding);
				return bakedBinding;
			}

			return null;
		}

		public override void BakeCommandBinding(CommandBinding commandBinding, CommandsHandler commandsHandler)
		{
			if (bakedCommandBindings.TryGetValue(commandBinding.guid, out var commandBindingBaker))
			{
				commandBindingBaker.Invoke(commandBinding, commandsHandler);
			}
		}
		private void BakeCommandBinding_Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc(CommandBinding commandBinding, CommandsHandler commandsHandler)
		{
			Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc_CommandTarget = (global::NumberRequester)commandBinding.UnityComponent;
			commandsHandler.AddBakedCommand("NumberRequester.GotNumber", "(System.Int32)",
				SendCommand_Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc, ReceiveLocalCommand_Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc, MessageTarget.AuthorityOnly, Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc_CommandTarget,false);
		}

		public override List<ICoherenceComponentData> CreateEntity(bool usesLodsAtRuntime, string archetypeName)
		{
			if (!usesLodsAtRuntime)
			{
				return null;
			}

			if (Archetypes.IndexForName.TryGetValue(archetypeName, out int archetypeIndex))
			{
				var components = new List<ICoherenceComponentData>()
				{
					new ArchetypeComponent
					{
						index = archetypeIndex
					}
				};

				return components;
			}
	
			logger.Warning($"Unable to find archetype {archetypeName} in dictionary. Please, bake manually (coherence > Bake)");

			return null;
		}

		public override void Dispose()
		{
		}

		public override void Initialize(SerializeEntityID entityId, CoherenceBridge bridge, IClient client, CoherenceInput input, Logger logger)
		{
			this.logger = logger.With<CoherenceSyncRequester_9183cae5a9aea3f409ea10aa1e98898b>();
			this.bridge = bridge;
			this.entityId = entityId;
			this.client = client;
		}
		void SendCommand_Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc(MessageTarget target, object[] args)
		{
			var command = new Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc();
			int i = 0;
			command.number = (int)((System.Int32)args[i++]);
			client.SendCommand(command, target, entityId);
		}

		void ReceiveLocalCommand_Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc(MessageTarget target, object[] args)
		{
			var command = new Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc();
			int i = 0;
			command.number = (int)((System.Int32)args[i++]);
			ReceiveCommand_Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc(command);
		}

		void ReceiveCommand_Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc(Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc command)
		{
			var target = Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc_CommandTarget;
			target.GotNumber((System.Int32)(command.number));
		}

		public override void ReceiveCommand(IEntityCommand command)
		{
			switch(command)
			{
				case Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc castedCommand:
					ReceiveCommand_Requester_9183cae5a9aea3f409ea10aa1e98898b_NumberRequester__char_46_GotNumber_d695b084_e661_4ae0_acc5_4b7a4ec195dc(castedCommand);
					break;
				default:
					logger.Warning($"[CoherenceSyncRequester_9183cae5a9aea3f409ea10aa1e98898b] Unhandled command: {command.GetType()}.");
					break;
			}
		}
	}
}