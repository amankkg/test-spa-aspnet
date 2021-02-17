namespace CustomIdentityMvc.Controllers
{
    static class Singleton
    {
        public static bool Flag { get; set; }

        public static void Toggle()
        {
            Flag = !Flag;
        }
    }
}
