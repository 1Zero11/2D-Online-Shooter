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

	public class Binding_8d9e8cf9c99d8da49bf515e68b4c8602_f7a1b7a2_9899_4e65_ae86_cc0cc3ded0da : PositionBinding
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
	public class CoherenceSyncCoin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602 : CoherenceSyncBaked
	{
		private SerializeEntityID entityId;
		private Logger logger = Log.GetLogger<CoherenceSyncCoin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602>();

		// Cached targets for commands		
		private global::CoinSpawner Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5_CommandTarget;

		private IClient client;
		private CoherenceBridge bridge;

		private readonly Dictionary<string, Binding> bakedValueBindings = new Dictionary<string, Binding>()
		{
			["f7a1b7a2-9899-4e65-ae86-cc0cc3ded0da"] = new Binding_8d9e8cf9c99d8da49bf515e68b4c8602_f7a1b7a2_9899_4e65_ae86_cc0cc3ded0da(),
		};

		private Dictionary<string, Action<CommandBinding, CommandsHandler>> bakedCommandBindings =
			new Dictionary<string, Action<CommandBinding, CommandsHandler>>();

		public CoherenceSyncCoin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602()
		{
			bakedCommandBindings.Add("677b316c-5815-448b-b793-cd86f1bf81c5", BakeCommandBinding_Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5);
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
		private void BakeCommandBinding_Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5(CommandBinding commandBinding, CommandsHandler commandsHandler)
		{
			Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5_CommandTarget = (global::CoinSpawner)commandBinding.UnityComponent;
			commandsHandler.AddBakedCommand("CoinSpawner.Init", "()",
				SendCommand_Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5, ReceiveLocalCommand_Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5, MessageTarget.AuthorityOnly, Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5_CommandTarget,false);
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
			this.logger = logger.With<CoherenceSyncCoin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602>();
			this.bridge = bridge;
			this.entityId = entityId;
			this.client = client;
		}
		void SendCommand_Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5(MessageTarget target, object[] args)
		{
			var command = new Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5();
			client.SendCommand(command, target, entityId);
		}

		void ReceiveLocalCommand_Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5(MessageTarget target, object[] args)
		{
			var command = new Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5();
			ReceiveCommand_Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5(command);
		}

		void ReceiveCommand_Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5(Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5 command)
		{
			var target = Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5_CommandTarget;
			target.Init();
		}

		public override void ReceiveCommand(IEntityCommand command)
		{
			switch(command)
			{
				case Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5 castedCommand:
					ReceiveCommand_Coin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602_CoinSpawner__char_46_Init_677b316c_5815_448b_b793_cd86f1bf81c5(castedCommand);
					break;
				default:
					logger.Warning($"[CoherenceSyncCoin__char_32_Spawner_8d9e8cf9c99d8da49bf515e68b4c8602] Unhandled command: {command.GetType()}.");
					break;
			}
		}
	}
}