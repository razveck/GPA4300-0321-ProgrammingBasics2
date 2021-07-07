using System;
using System.Collections.Generic;

namespace Generics {

	//in C++ it's called templates
	//templated types

	class Generics {
		static void Main(string[] args) {
			List<int> intList = new List<int>();

			//the generic type MUST be known at compile time

			AaronPaul<bool> paul = new AaronPaul<bool>();
			paul.TryToEat();
			paul.TheWhatNow(true);

			AaronPaul<List<int>> listPaul = new AaronPaul<List<int>>();
			listPaul.TheWhatNow(intList);
			listPaul.TryToEat();

			AaronPaul<MyStruct> structPaul = new AaronPaul<MyStruct>();

			//GetComponent<int>(1);
			GetComponent<Collider>();

			Foo<int, bool, int, Component, string>();

			Collider c;
			if(TryGetComponent<Collider>(out c)){
				//do stuff
			}
			//can use the c variable
			c = null;

			//in this case, the compiler extracts the col variable into a local variable
			if(TryGetComponent(out Collider col)){

			}
			//can use the col variable
			col = null;
		}

		static T GetComponent<T>() where T : Component
			//,new()
			{
			//T t = new T();
			return default;
		}

		static T Foo<T, U, V, T1, T2>(){
			return default;
		}

		static bool TryGetComponent<T>(out T component) where T : Component{
			//if the component was found, return true
			component = default;

			//if not, return false


			return true;

		}
	}

	class Component {
		public Component(int a) {

		}
	}

	class Collider : Component {
		public Collider(int a, int b) : base(a) {

		}
	}

	struct MyStruct {

	}

	class AaronPaul<T>
		//we can restrict what T can be, by using the where keyword
		//where T: class
		//where T: struct
		{
		public T What;

		public AaronPaul() {
			//cannot ensure that T is a nullable type
			//What = null;
		}

		public void TryToEat() {
			Random rand = new Random();
			int coinFlip = rand.Next(0, 2);
			if(coinFlip == 0) {
				Console.WriteLine($"AaronPaul ate the {What.GetType()}");
			} else {
				Console.WriteLine($"AaronPaul threw the {What.GetType()} down the toilet");
			}
		}

		public T ReturnWhat() {
			return What;
		}

		public void TheWhatNow(T that) {
			What = that;
		}
	}
}
