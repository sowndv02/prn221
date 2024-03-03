namespace SEP_Management.Enums
{
    public enum SettingGroup
    {
        SEMESTER = 1,
        USER_ROLE = 2,
        PERMITTED_EMAIL = 3
    }

    class Program
    {
        static void Main()
        {
            SettingGroup setting = SettingGroup.SEMESTER;
            Console.WriteLine("Name: " + setting); // Output: SEMESTER
            Console.WriteLine("Value: " + (int)setting); // Output: 1

            // Simulating display name and description using a switch statement
            switch (setting)
            {
                case SettingGroup.SEMESTER:
                    Console.WriteLine("Display Name: Semester Settings");
                    Console.WriteLine("Description: Settings related to the current semester");
                    break;
                case SettingGroup.USER_ROLE:
                    Console.WriteLine("Display Name: User Role Settings");
                    Console.WriteLine("Description: Settings related to user roles");
                    break;
                case SettingGroup.PERMITTED_EMAIL:
                    Console.WriteLine("Display Name: Permitted Email Settings");
                    Console.WriteLine("Description: Settings related to permitted email addresses");
                    break;
                default:
                    break;
            }
        }
    }
}
