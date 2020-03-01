using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;

namespace node_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Create a new viewmodel for the NetworkView
            var network = new NetworkViewModel();

            //Create the node for the first node, set its name and add it to the network.
            var node1 = new NodeViewModel();
            node1.Name = "Node 1";
            network.Nodes.Add(node1);

            //Create the viewmodel for the input on the first node, set its name and add it to the node.
            var node1Input = new ValueNodeInputViewModel<string>();
            node1Input.Name = "Node 1 input";
            node1.Inputs.Add(node1Input);

            //Print value on change
            node1Input.ValueChanged.Subscribe(newValue =>
            {
                Console.WriteLine(newValue);
            });


            //Create the second node viewmodel, set its name, add it to the network and add an output in a similar fashion.
            var node2 = new NodeViewModel();
            node2.Name = "Node 2";
            network.Nodes.Add(node2);

            var node2Output = new ValueNodeOutputViewModel<string>();
            node2Output.Name = "Node 2 output";
            node2.Outputs.Add(node2Output);
            node2Output.Value = Observable.Return("Example string");

            //Create the third test node viewmodel 
            //Its I/O is already set in the HelloWorldNode class, so no need to declare new ones

            var node3 = new HelloWorldNode();
            node2.Name = "Node 3";
            network.Nodes.Add(node3);


            //Assign the viewmodel to the view.
            networkView.ViewModel = network;

        }

    }
}
