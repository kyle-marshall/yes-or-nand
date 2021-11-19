// LogicWorld.ClientCode.AndGateVariantInfo
using System;
using System.Collections.Generic;
using JimmysUnityUtilities;
using LogicWorld.Interfaces;
using LogicWorld.Rendering.Dynamics;
using LogicWorld.SharedCode.Components;
using UnityEngine;

/** Shamelessly sourced from the game's AndGateVariantInfo in the first release <3 */
namespace YesOrNand.Client
{
    public class OrGateVariantInfo : PrefabVariantInfo
    {
        private static Color24 blockColor = new Color24(25, 109, 22);

        public override string ComponentTextID => "yes-or-nand.OrGate";

        public override PrefabVariantIdentifier GetDefaultComponentVariant()
        {
            return new PrefabVariantIdentifier(2, 1);
        }

        public override ComponentVariant GenerateVariant(PrefabVariantIdentifier identifier)
        {
            if (identifier.OutputCount != 1)
            {
                throw new Exception("Or gates must have exactly one output");
            }
            PlacingRules placingRules = new PlacingRules();
            placingRules.AllowFineRotation = identifier.InputCount <= 2;
            Block prefabBlock = new Block
            {
                RawColor = blockColor
            };
            ComponentOutput prefabOutput = new ComponentOutput
            {
                Rotation = new Vector3(90f, 0f, 0f)
            };
            List<ComponentInput> prefabInputs = new List<ComponentInput>();
            if (identifier.InputCount == 3)
            {
                setBlockScaleX(1.5f);
                setOutputPositionX(0f);
                addInput(-0.5f);
                addInput(0f);
                addInput(0.5f);
                placingRules.GridPlacingDimensions = new Vector2Int(2, 2);
            }
            else
            {
                float num = Mathf.Ceil((float)identifier.InputCount / 2f - 0.01f);
                float num2 = (num - 1f) / 2f;
                setBlockScaleX(num);
                setBlockPositionX(num2);
                setOutputPositionX(num2);
                float num3 = (num - 0.5f) / ((float)identifier.InputCount - 1f);
                for (int i = 0; i < identifier.InputCount; i++)
                {
                    addInput(-0.25f + (float)i * num3);
                }
                placingRules.OffsetDimensions = new Vector2Int(num.RoundToInt(), 1);
                placingRules.GridPlacingDimensions = new Vector2Int(num.RoundToInt(), 2);
            }
            ComponentVariant componentVariant = new ComponentVariant();
            componentVariant.VariantPlacingRules = placingRules;
            componentVariant.VariantPrefab = new Prefab
            {
                Blocks = new Block[1] { prefabBlock },
                Outputs = new ComponentOutput[1] { prefabOutput },
                Inputs = prefabInputs.ToArray()
            };
            return componentVariant;
            void addInput(float xPosition)
            {
                prefabInputs.Add(new ComponentInput
                {
                    Position = new Vector3(xPosition, 0.5f, -0.5f),
                    Rotation = new Vector3(-90f, 0f, 0f),
                    Length = 0.6f
                });
            }
            void setBlockPositionX(float blockPositionX)
            {
                prefabBlock.Position = new Vector3(blockPositionX, 0f, 0f);
            }
            void setBlockScaleX(float blockScaleX)
            {
                prefabBlock.Scale = new Vector3(blockScaleX, 1f, 1f);
            }
            void setOutputPositionX(float outputPositionX)
            {
                prefabOutput.Position = new Vector3(outputPositionX, 0.5f, 0.5f);
            }
        }
    }


    public class OrGateVariantInfo_3 : OrGateVariantInfo
    {
        public override string ComponentTextID => "yes-or-nand.OrGate3";

        public override PrefabVariantIdentifier GetDefaultComponentVariant()
        {
            return new PrefabVariantIdentifier(3, 1);
        }
    }

    public class OrGateVariantInfo_4 : OrGateVariantInfo
    {
        public override string ComponentTextID => "yes-or-nand.OrGate4";

        public override PrefabVariantIdentifier GetDefaultComponentVariant()
        {
            return new PrefabVariantIdentifier(4, 1);
        }
    }
}
