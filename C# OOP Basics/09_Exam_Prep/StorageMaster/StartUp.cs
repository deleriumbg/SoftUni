namespace StorageMaster
{
    using Core;
    public class StartUp
    {
        static void Main(string[] args)
        {
            StorageMaster storageMaster = new StorageMaster();
            Engine engine = new Engine(storageMaster);
            engine.Run();
        }
    }
}
