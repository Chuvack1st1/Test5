public interface ISaveLoad 
{
    public void Save();

    T Load<T>();

    void Load();
}
