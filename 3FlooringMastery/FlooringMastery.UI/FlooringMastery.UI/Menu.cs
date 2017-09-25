using FlooringMastery.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Flooring Mastery Application");
                Console.WriteLine("------------------------");
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("5. Q to quit");

                Console.Write("\nEnter selection: ");

                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        DisplayOrderWorkflow displayWorkflow = new DisplayOrderWorkflow();
                        displayWorkflow.GetDate();
                        break;
                    //case "2":
                    //    AddOrdertWorkflow addOrderWorkflow = new AddOrdertWorkflow();
                    //    addOrderWorkflow.Execute();
                    //    break;
                    //case "3":
                    //    EditOrdertWorkflow editOrderWorkflow = new EditOrdertWorkflow();
                    //    editOrderWorkflow.Execute();
                    //    break;
                    //case "4":
                    //    RemoveOrdertWorkflow removeOrderWorkflow = new RemoveOrdertWorkflow();
                    //    removeOrderWorkflow.Execute();
                        break;
                    case "Q":
                        return;
                }

            }

        }
    }
}
