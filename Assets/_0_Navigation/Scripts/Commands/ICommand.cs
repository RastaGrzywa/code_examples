using System;
using System.Collections.Generic;

namespace _0_Navigation.Scripts.Commands
{
    public interface ICommand
    {
        event Action OnFinished;
        
        void Execute(List<ICommand> commands);
        void Update();
        void Finish();
    }
}