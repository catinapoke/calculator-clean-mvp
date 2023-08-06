namespace Data
{
    public interface IInputStorage
    {
        public void Set(Equation parts);
        public Equation Get();
    }
}