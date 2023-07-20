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

	public class Binding_e64e8343430fdef489c9172a49651adc_6b28b2cd_6698_46f9_a00f_a9b65c5681fa : PositionBinding
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
	public class CoherenceSyncGame__char_32_Manager_e64e8343430fdef489c9172a49651adc : CoherenceSyncBaked
	{
		private SerializeEntityID entityId;
		private Logger logger = Log.GetLogger<CoherenceSyncGame__char_32_Manager_e64e8343430fdef489c9172a49651adc>();

		// Cached targets for commands		
		private global::MainGameManager Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0_CommandTarget;		
		private global::MainGameManager Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b_CommandTarget;

		private IClient client;
		private CoherenceBridge bridge;

		private readonly Dictionary<string, Binding> bakedValueBindings = new Dictionary<string, Binding>()
		{
			["6b28b2cd-6698-46f9-a00f-a9b65c5681fa"] = new Binding_e64e8343430fdef489c9172a49651adc_6b28b2cd_6698_46f9_a00f_a9b65c5681fa(),
		};

		private Dictionary<string, Action<CommandBinding, CommandsHandler>> bakedCommandBindings =
			new Dictionary<string, Action<CommandBinding, CommandsHandler>>();

		public CoherenceSyncGame__char_32_Manager_e64e8343430fdef489c9172a49651adc()
		{
			bakedCommandBindings.Add("80d0961a-d2ce-4280-81b5-cd8d04601bc0", BakeCommandBinding_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0);
			bakedCommandBindings.Add("efc232bb-f749-4310-8c26-9b0d24cb3f1b", BakeCommandBinding_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b);
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
		private void BakeCommandBinding_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0(CommandBinding commandBinding, CommandsHandler commandsHandler)
		{
			Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0_CommandTarget = (global::MainGameManager)commandBinding.UnityComponent;
			commandsHandler.AddBakedCommand("MainGameManager.ShowVictory", "(UnityEngine.ColorSystem.Int32)",
				SendCommand_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0, ReceiveLocalCommand_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0, MessageTarget.All, Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0_CommandTarget,false);
		}
		private void BakeCommandBinding_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b(CommandBinding commandBinding, CommandsHandler commandsHandler)
		{
			Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b_CommandTarget = (global::MainGameManager)commandBinding.UnityComponent;
			commandsHandler.AddBakedCommand("MainGameManager.Victory", "()",
				SendCommand_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b, ReceiveLocalCommand_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b, MessageTarget.All, Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b_CommandTarget,false);
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
			this.logger = logger.With<CoherenceSyncGame__char_32_Manager_e64e8343430fdef489c9172a49651adc>();
			this.bridge = bridge;
			this.entityId = entityId;
			this.client = client;
		}
		void SendCommand_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0(MessageTarget target, object[] args)
		{
			var command = new Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0();
			int i = 0;
			command.color = (Color)((UnityEngine.Color)args[i++]);
			command.coins = (int)((System.Int32)args[i++]);
			client.SendCommand(command, target, entityId);
		}

		void ReceiveLocalCommand_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0(MessageTarget target, object[] args)
		{
			var command = new Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0();
			int i = 0;
			command.color = (Color)((UnityEngine.Color)args[i++]);
			command.coins = (int)((System.Int32)args[i++]);
			ReceiveCommand_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0(command);
		}

		void ReceiveCommand_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0(Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0 command)
		{
			var target = Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0_CommandTarget;
			target.ShowVictory((UnityEngine.Color)(command.color),(System.Int32)(command.coins));
		}
		void SendCommand_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b(MessageTarget target, object[] args)
		{
			var command = new Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b();
			client.SendCommand(command, target, entityId);
		}

		void ReceiveLocalCommand_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b(MessageTarget target, object[] args)
		{
			var command = new Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b();
			ReceiveCommand_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b(command);
		}

		void ReceiveCommand_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b(Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b command)
		{
			var target = Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b_CommandTarget;
			target.Victory();
		}

		public override void ReceiveCommand(IEntityCommand command)
		{
			switch(command)
			{
				case Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0 castedCommand:
					ReceiveCommand_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_ShowVictory_80d0961a_d2ce_4280_81b5_cd8d04601bc0(castedCommand);
					break;
				case Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b castedCommand:
					ReceiveCommand_Game__char_32_Manager_e64e8343430fdef489c9172a49651adc_MainGameManager__char_46_Victory_efc232bb_f749_4310_8c26_9b0d24cb3f1b(castedCommand);
					break;
				default:
					logger.Warning($"[CoherenceSyncGame__char_32_Manager_e64e8343430fdef489c9172a49651adc] Unhandled command: {command.GetType()}.");
					break;
			}
		}
	}
}
