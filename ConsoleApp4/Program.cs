namespace ConsoleApp4
{
   public class Program
    {
        public static void Main(string[] args)
        {
            var applicationContext = new ApplicationContext();
            applicationContext.SaveChanges();
        }
    }
}