namespace MyClassLibrary
{
    using MyNamespace;

    public class Demo
    {
        //accessing internal members from inside the assembly

        MyClass myClass = new();

        MyStruct myStruct = new ();

        IMyInterface myInterface;

        MyEnum enumValue = MyEnum.A;
    }
}

namespace MyNamespace
{
    //a namespace may contain the following
    class MyClass
    {

    }

    struct MyStruct
    {

    }

    interface IMyInterface
    {

    }

    enum MyEnum
    {
        A, B, C
    }
    //and are declared internal by default

    //but can be declare as public
    public class MyPublicClass
    {

    }

    public struct MyPublicStruct
    {

    }

    public interface IMyPublicInterface
    {

    }

    public enum MyPublicEnum
    {
        X, Y, Z
    }
}

namespace MyNamespace2
{
    public class DemoClass
    {
        public DemoClass()
        {
            Start();
        }
        //a class may include the following

        //attribute / member variable / field
        int x;

        // function / method
        void Start()
        {
            _private = 50;

            Console.WriteLine(_private);
        }

        //property (full / auto / indexer)
        int y { get; set; }

        // event

        // and are declared as private by default

        //access modifiers
        private int _private;
        private protected int _privateProtected;
        protected int _protected;
        internal int _internal;
        protected internal int _protectedInternal;
        public int _public;
    }

    public class ClassA : DemoClass
    {
        public ClassA()
        {
            // can't access becuase its private
            //_private = 1;

            //accessible from outside the class but only to ClassB because
            //it inherit from DemoClass
            _privateProtected = 2;

            //accessible because ClassB inherit from DemoClass
            _protected = 3;

            //accessible because its internal
            _internal = 4;

            //accessible because its internal + inheritance
            _protectedInternal = 5;

            //accessible because its public
            _public = 6;
        }
    }

    class ClassB
    {
        ClassB()
        {
            DemoClass demo = new();
            // can't access becuase its private
            //demo._private = 1;

            //compile error: inaccessible due to its protection level
            //can't access because ClassC don't inherit from DemoClass
            //demo._privateProtected = 2;

            //compile error: inaccessible due to its protection level
            // ClassC don't inherit from DemoClass
            //demo._protected = 3;

            //accessible despite not being inheriting from DemoClass due to being internal
            demo._internal = 4;

            //accessible because its protected internal
            demo._protectedInternal = 5;

            //accessible because its public
            demo._public = 6;
        }
    }

    //interfaces
    interface IAssignment
    {
        //may contain

        //signature of a method
        void Solve();

        //signature of a property
        int Difficulty { get; set; }

        //Default Implemented Method
        void Submit()
        {
            Console.WriteLine("Commit => Push => Email");
        }
    }

    //interfaces may have internal or public access modifiers
}