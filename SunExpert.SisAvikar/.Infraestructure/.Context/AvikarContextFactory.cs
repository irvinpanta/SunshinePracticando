namespace SunExpert.SisAvikar.Repository
{
    public static class AvikarContextFactory
    {
        public static AvikarContext GetContext(){
            return new AvikarContext();
        }
        public static AvikarContext GetContext(string nameOrConnectionString){
            return new AvikarContext(nameOrConnectionString);
        }
    }
}
