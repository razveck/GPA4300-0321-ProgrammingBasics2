using System;

namespace Properties {

	class Person {
		private string _name;

		public void SetName(string value) {
			if(string.IsNullOrEmpty(value))
				return; //do something, throw an error

			_name = value;
			Console.WriteLine($"Name is now {value}");
		}

		public string GetName() {
			return _name;
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if(string.IsNullOrEmpty(value))
					return; //do something, throw an error

				_name = value;
				Console.WriteLine($"Name is now {value}");
			}
		}

		//backing field
		private int _age;

		//full property
		public int Age
		{
			set { }
			get { return 1; }
		}

		//auto-property
		public string AutoProperty { get; set; }

		public string ReadOnlyProperty { get; private set; }
		public string WriteOnlyProperty { private get; set; }

		public readonly string ReadOnlyVariable = "uihu";

		void Foo() {
			ReadOnlyProperty = "jj";
			//not allowed
			//ReadOnlyVariable = "olkok";
		}

		public Person() {
			ReadOnlyVariable = "ok";
		}

		public int InitializedProperty { get; set; } = 10;

		public void DoTheThing(int howManyThings) => Console.WriteLine($"Doing {howManyThings} things!");

		public int PropertyWithArrows
		{
			get => 4238;
			set => Console.WriteLine(value);
		}

		private int _getterOnly;
		//public int GetterOnlyProperty { get => _getterOnly; }
		public int GetterOnlyProperty => _getterOnly;
	}

	class Properties {
		static void Main(string[] args) {
			Person a = new Person();
			a.SetName("Joao");
			Console.WriteLine(a.GetName());

			a.Name = "Masterchief";
			Console.WriteLine(a.Name);

			a.Age = 10;
			a.Age = 20;

			//inaccessible, the setter is private
			//a.ReadOnlyProperty = "njuh";
			//we can still read it and use it
			Console.WriteLine(a.ReadOnlyProperty);

			//inaccessible, the getter is private
			//Console.WriteLine(a.WriteOnlyProperty);
			//we can still write to it
			a.WriteOnlyProperty = "Something";

			a.DoTheThing(200);
			a.PropertyWithArrows = 666;

		}
	}
}
