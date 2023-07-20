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

	public class Binding_a1ab3994159bb8946b24a3c3c28a2eef_0bb04887_693f_4449_84e6_4debd0977215 : PositionBinding
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
	public class CoherenceSyncHuh_a1ab3994159bb8946b24a3c3c28a2eef : CoherenceSyncBaked
	{
		private SerializeEntityID entityId;
		private Logger logger = Log.GetLogger<CoherenceSyncHuh_a1ab3994159bb8946b24a3c3c28a2eef>();

		// Cached targets for commands		
		private global::VIctoryHandler Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9_CommandTarget;

		private IClient client;
		private CoherenceBridge bridge;

		private readonly Dictionary<string, Binding> bakedValueBindings = new Dictionary<string, Binding>()
		{
			["0bb04887-693f-4449-84e6-4debd0977215"] = new Binding_a1ab3994159bb8946b24a3c3c28a2eef_0bb04887_693f_4449_84e6_4debd0977215(),
		};

		private Dictionary<string, Action<CommandBinding, CommandsHandler>> bakedCommandBindings =
			new Dictionary<string, Action<CommandBinding, CommandsHandler>>();

		public CoherenceSyncHuh_a1ab3994159bb8946b24a3c3c28a2eef()
		{
			bakedCommandBindings.Add("2ce047e9-d7c8-476f-b06a-3db68a6ed6e9", BakeCommandBinding_Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9);
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
		private void BakeCommandBinding_Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9(CommandBinding commandBinding, CommandsHandler commandsHandler)
		{
			Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9_CommandTarget = (global::VIctoryHandler)commandBinding.UnityComponent;
			commandsHandler.AddBakedCommand("VIctoryHandler.ShowVictory", "(UnityEngine.ColorSystem.Int32)",
				SendCommand_Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9, ReceiveLocalCommand_Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9, MessageTarget.All, Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9_CommandTarget,false);
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
			this.logger = logger.With<CoherenceSyncHuh_a1ab3994159bb8946b24a3c3c28a2eef>();
			this.bridge = bridge;
			this.entityId = entityId;
			this.client = client;
		}
		void SendCommand_Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9(MessageTarget target, object[] args)
		{
			var command = new Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9();
			int i = 0;
			command.color = (Color)((UnityEngine.Color)args[i++]);
			command.coins = (int)((System.Int32)args[i++]);
			client.SendCommand(command, target, entityId);
		}

		void ReceiveLocalCommand_Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9(MessageTarget target, object[] args)
		{
			var command = new Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9();
			int i = 0;
			command.color = (Color)((UnityEngine.Color)args[i++]);
			command.coins = (int)((System.Int32)args[i++]);
			ReceiveCommand_Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9(command);
		}

		void ReceiveCommand_Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9(Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9 command)
		{
			var target = Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9_CommandTarget;
			target.ShowVictory((UnityEngine.Color)(command.color),(System.Int32)(command.coins));
		}

		public override void ReceiveCommand(IEntityCommand command)
		{
			switch(command)
			{
				case Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9 castedCommand:
					ReceiveCommand_Huh_a1ab3994159bb8946b24a3c3c28a2eef_VIctoryHandler__char_46_ShowVictory_2ce047e9_d7c8_476f_b06a_3db68a6ed6e9(castedCommand);
					break;
				default:
					logger.Warning($"[CoherenceSyncHuh_a1ab3994159bb8946b24a3c3c28a2eef] Unhandled command: {command.GetType()}.");
					break;
			}
		}
	}
}