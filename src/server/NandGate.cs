
using LogicAPI.Server.Components;

namespace YesOrNand.Server
{
    public class NandGate : LogicComponent
    {
        protected override void DoLogicUpdate() {
            for (int i=0; i < Inputs.Count; i++) {
                if (!Inputs[i].On) {
                    Outputs[0].On = true;
                    return;
                }
            }
            Outputs[0].On = false;
        }
    }
}
