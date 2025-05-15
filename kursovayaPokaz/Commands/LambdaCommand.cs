using kursovayaPokaz.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace kursovayaPokaz.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public LambdaCommand(Action Execute, Func<bool> CanExecute = null)
            : this(p => Execute(), CanExecute is null ? (Func<object, bool>)null : p => CanExecute())
        { }

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null, bool isExecutable = true)
            : this(Execute, CanExecute) => Executable = isExecutable;

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute)
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            canExecute = CanExecute;
        }


        protected override bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;
        protected override void Execute(object parameter) => execute?.Invoke(parameter);

    }
}