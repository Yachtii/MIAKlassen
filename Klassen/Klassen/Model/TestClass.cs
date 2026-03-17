namespace Klassen.Model
{
    public class TestClass
    {
        public string TestString {  get; set; }
        public int TestInt { get; set; }

        public TestClass(string test, int testInt)
        {
            TestString = test;
            TestInt = testInt;
        }

        public void TestVoidMethod() 
        {
            Console.WriteLine("This is a void method.");
        }

        public void UpdateTestString(string newValue)
        {
            TestString = newValue;
        }

        public string ReturnTestStringValue()
        {
            return TestString;
        }
    }
}
