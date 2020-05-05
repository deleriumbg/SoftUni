namespace Database
{
    public interface IDatabase
    {
        void Add(int element);
        void Remove();
        int[] Fetch();
    }
}
