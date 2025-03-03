using DeckScaler.Scope;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class EmitMouseOrdersSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .Build();

        private static IInputService Input => ServiceLocator.Resolve<IInputService>();

        public void Execute()
        {
            foreach (var inputEntity in _inputs)
            {
                inputEntity
                    .Is<JustClickedOrder>(Input.JustClickedOrder)
                    ;
            }
        }
    }
}