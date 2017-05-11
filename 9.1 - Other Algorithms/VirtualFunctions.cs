 using System.Windows;
namespace DataStructuresAndAlgorithms
{
    //In OOP when a derived class inherits from a base class, an object of the derived class may be referred to via a pointer or reference of either the base class type or the derived class type. 
    //If there are base class methods overridden by the derived class, 
    //the method actually called by such a reference or pointer can be bound either 'early' (by the compiler), according to the declared type of the pointer or reference, or 'late' (i.e. by the runtime system of the language), according to the actual type of the object referred to.
    //Virtual functions are resolved 'late'. 
    //If the function in question is 'virtual' in the base class, the most-derived class's implementation of the function is called according to the actual type of the object referred to, regardless of the declared type of the pointer or reference. 
    //If it is not 'virtual', the method is resolved 'early' and the function called is selected according to the declared type of the pointer or reference.
    //Virtual functions allow a program to call methods that don't necessarily even exist at the moment the code is compiled.
    //A pure virtual function or pure virtual method is a virtual function that is required to be implemented by a derived class, if that class is not abstract. Classes containing pure virtual methods are termed "abstract"; they cannot be instantiated directly. A subclass of an abstract class can only be instantiated directly if all inherited pure virtual methods have been implemented by that class or a parent class. Pure virtual methods typically have a declaration (signature) and no definition (implementation).
    public class ClassA
    {
        public virtual void VDisplay()
        {
            MessageBox.Show("A VDisplay");
        }
        public void Display()
        {
            MessageBox.Show("A Display");
        }
        ~ClassA()
        {

        }
    }
    public class ClassB : ClassA
    {
        public override void VDisplay()
        {
            MessageBox.Show("B VDisplay");
        }

        public void Display()
        {
            MessageBox.Show("B Display");
        }

        public ClassB()
        {

        }
        ~ClassB()
        {

        }
    }
}