using System;

namespace StackAndHeap {

	class ReferenceType{
		public int Amount;
	}

	struct ValueType{
		public static bool isRunning;

		float height;
		int age;

		public string Name;
	}

	class StackAndHeap {


		static void Main(string[] args) {

			//rule 1: local variables (variables declared in functions) and their values are stored on the stack
			//both of these are on the stack
			int a = 5;
			ValueType value = new ValueType();

			//rule 2: objects of a reference type are ALWAYS stored on the heap
			//variable called reference is on the stack. It points to an object on the heap
			ReferenceType reference = new ReferenceType();

			//rule 3: objects of a value type are stored wherever their enclosing scope is stored
			//reference.Amount is stored on the HEAP, because the reference object is on the HEAP
			reference.Amount = 10;

			//(unofficial)rule 4: static variables are stored on the heap
			//isRunning is stored on the heap
			ValueType.isRunning = true;


			//the 'name' variable is on the stack
			//the value is a reference to a string, it's on the stack
			//the data ("Joao") is on the heap
			string name = "Joao";


			//the 'intArray' is on the stack
			//the value is a reference to an int array, it's on the stack
			//the data is on the heap
			int[] intArray = new int[10];
			//the value 999 is on the heap, directly in the array
			intArray[0] = 999;


			//the 'referenceArray' is on the stack
			//the value is a reference to a ReferenceType ARRAY, on the stack
			//the data is on the heap
			ReferenceType[] referenceArray = new ReferenceType[10];
			//the index 0 element of the array stores a reference to a new object. That new object is SOMEWHERE ELSE on the heap
			referenceArray[0] = new ReferenceType();


			//v is on the stack
			ValueType v = new ValueType();
			//v.Name is on the stack, pointing to a string on the heap
			v.Name = "Mario";



			ReferenceType var1 = new ReferenceType();
			ReferenceType var2 = new ReferenceType();
			var2 = var1;


			Recurse(0);
		}

		static void Recurse(int counter){
			counter++;

			if(counter < 10)
				Recurse(counter);
		}
	}
}
