using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace node_test
{
    class HelloWorldNode : NodeViewModel
    {
        public ValueNodeInputViewModel<string> nameInput { get; }
        public ValueNodeOutputViewModel<string> textOutput { get; }
        public HelloWorldNode()
        {
            this.Name = "Hello World Node!";

            nameInput = new ValueNodeInputViewModel<string>();
            {
                Name = "Input";
            }

            this.Inputs.Add(nameInput);

            textOutput = new ValueNodeOutputViewModel<string>()
            {
                Name = "Output",
                Value = this.WhenAnyObservable(vm => vm.nameInput.ValueChanged)
                    .Select(name => $"Hello {name}!")
            };

            this.Outputs.Add(textOutput);
        }

        static HelloWorldNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<HelloWorldNode>));
        }
    }
}
