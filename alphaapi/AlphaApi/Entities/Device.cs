namespace AlphaApi.Entities
{
    public abstract class Device
    {
        protected bool isConnected() => true;

        //abstract obriga classes filha a implementarem esse metodo
        public abstract string GetBrand();

        //virtual permite classes filhas sobreescreverem esse metodo
        public virtual string GetStorageSize()
        {
            return "256GB";
        }
    }
}
