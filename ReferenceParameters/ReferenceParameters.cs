using System;
using System.Collections.Generic;
using System.Linq;

namespace ReferenceParameters {

	class Player{
		public int Health;
		public string Name;
	}

	struct Vector2{
		public float X;
		public float Y;
	}

	class ReferenceParameters {
		static void Main(string[] args) {
			string myString = "A";
			Foo(myString);
			FooRef(ref myString);
			FooOut(out myString);
			FooIn(in myString);
		}

		static void Foo(string name){
			name = "B";
		}

		//REF - parameter can be changed and it changes the variable in the calling scope
		//can be changed, but doesn't have to
		static void FooRef(ref string name){
			name = "C";
		}

		//OUT - parameter MUST be assigned to IN THE FUNCTION, it changes the calling scope
		static void FooOut(out string name){
			name = "D";
		}

		//out enforces assignment of the parameter
		static void ReturnPlayer(out string playerName){
			playerName = "Mario";
		}

		//IN - parameter CANNOT be changed
		static void FooIn(in string name){
			//compiler error, can't change the in parameter
			//name = "E";
		}

		//first use case: disallow changing the reference, but still allow using its members
		static void ChangeHealth(in Player player){
			//player = new Player();
			player.Health += 10;
		}

		//second use case: disallow changing structs or members of structs
		static void UseVector2(in Vector2 vector){
			//cannot change members of struct, because that would require the reference to the struct to be changed
			//vector.X = 10f;
		}
	}
}
