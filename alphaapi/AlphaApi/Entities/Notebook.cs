namespace AlphaApi.Entities
{
    //sealed não permite que esse classe seja herdada
    public sealed class Notebook : Device
    {
        public string GetModel()
        {
            if (isConnected())
                return "Macbook";

            return "Unknown";
        }

        // sobrescrever metodo abstrato
        public override string GetBrand()
        {
            return "Apple";
        }

        // sobrescrever metodo virtual
        public override string GetStorageSize()
        {
            return "512GB";
        }
    }
}
