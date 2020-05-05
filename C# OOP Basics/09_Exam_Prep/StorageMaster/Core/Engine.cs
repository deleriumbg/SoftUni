using System;
using System.Linq;

namespace StorageMaster.Core
{
    public class Engine
    {
        private readonly StorageMaster storageMaster;
        private bool isRunning;

        public Engine(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string input = Console.ReadLine();
                string[] inputArgs = input.Split();
                string command = inputArgs[0];
                string output = String.Empty;

                try
                {
                    switch (command)
                    {
                        case "AddProduct":
                            output = this.storageMaster.AddProduct(inputArgs[1], double.Parse(inputArgs[2]));
                            break;
                        case "RegisterStorage":
                            output = this.storageMaster.RegisterStorage(inputArgs[1], inputArgs[2]);
                            break;
                        case "SelectVehicle":
                            output = this.storageMaster.SelectVehicle(inputArgs[1], int.Parse(inputArgs[2]));
                            break;
                        case "LoadVehicle":
                            output = this.storageMaster.LoadVehicle(inputArgs.Skip(1));
                            break;
                        case "SendVehicleTo":
                            output = this.storageMaster.SendVehicleTo(inputArgs[1], int.Parse(inputArgs[2]), inputArgs[3]);
                            break;
                        case "UnloadVehicle":
                            output = this.storageMaster.UnloadVehicle(inputArgs[1], int.Parse(inputArgs[2]));
                            break;
                        case "GetStorageStatus":
                            output = this.storageMaster.GetStorageStatus(inputArgs[1]);
                            break;
                        case "END":
                            output = this.storageMaster.GetSummary();
                            this.isRunning = false;
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    output = $"Error: {ioe.Message}";
                }

                Console.WriteLine(output);
            }
        }
    }
}
