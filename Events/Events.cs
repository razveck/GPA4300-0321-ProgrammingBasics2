using System;
using System.Collections.Generic;

namespace Events {

	//class type
	class Player{ }

	//delegate type
	delegate void Callback();

	delegate bool ValidationDelegate(string value);


	class Events {
		static void Main(string[] args) {
			//using the class type
			Player player1 = new Player();

			Callback callback = new Callback(PrintMyName);
			callback = PrintMyName;

			callback();

			Computer computer = new Computer();
			computer.Callback = PrintMyName;
			computer.ValidationDelegate = IsValid;


			//----EVENTS----
			//we could implement our own events like this
			
			computer.callbackEvent.Add(PrintMyName);
			computer.callbackEvent.Add(PrintMyName);
			computer.callbackEvent.Add(Foo);

			foreach(var func in computer.callbackEvent) {
				func();
			}
			computer.RunSomePrograms();

			//or we could use the C# built-in events
			//subscribing to the event
			computer.ProgramsFinished += PrintMyName;
			computer.ProgramsFinished += PrintMyName;
			computer.ProgramsFinished += Foo;

			//can only raise/invoke/trigger/call the event within the declaring class
			//computer.ProgramsFinished();

			computer.ActionDelegate = Foo;
			computer.FloatDelegate = Bar;
			computer.ValidateDelegate = IsValid;

		}

		static void PrintMyName(){
			Console.WriteLine("Joao");
		}

		static void Foo(){

		}

		static void Bar(float a){

		}

		static bool IsValid(string value){
			return !string.IsNullOrEmpty(value);
		}
	}

	class Computer{
		public Callback Callback;
		public ValidationDelegate ValidationDelegate;

		public List<Callback> callbackEvent = new List<Callback>();
		public event Callback ProgramsFinished;

		public Action ActionDelegate;
		public Action<float> FloatDelegate;

		public Func<string, bool> ValidateDelegate;

		public void RunSomePrograms(){
			//do stuff here
			//...

			if(Callback != null)
				Callback();

			bool isValid = ValidationDelegate("");

			//this could throw an error, if nothing is subscribed
			//ProgramsFinished();
			//ProgramsFinished.Invoke();
			
			if(ProgramsFinished != null)
				ProgramsFinished.Invoke(); //invoke is the same as just using the parenthesis

			//same thing as the previous null check
			ProgramsFinished?.Invoke();
		}
	}
}
