using System;
using NUnit.Framework;

namespace TestAPI.Utility
{
    public class DataGenerator
    {
       
            static string a1 = "abcdefghiklmnopqrstuvwxyz";
            static String a2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            static string num = "0123456789";

        public static string RandomString(int len = 10)
        {

            return TestContext.CurrentContext.Random.GetString(len, $"{a1}{a2}");

        }

        public static string RandomStringInt(int len = 10)
        {

            return TestContext.CurrentContext.Random.GetString(len, $"{num}");

        }

        //Function
        public static string FullName()
        {
            return Faker.Name.FullName();
        }

        //Property
        //public static string FullName1 => Faker.Name.FullName();

    }
}
