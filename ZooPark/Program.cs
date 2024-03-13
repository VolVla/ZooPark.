using System;
using System.Collections.Generic;

namespace Zoo
{
    internal class Program
    {
        static void Main()
        {
            ConsoleKey _exitButton = ConsoleKey.Enter;
            Zoo zooPark = new Zoo();
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Добро пожаловать в зоопарк.Выберите барьер к которому хотите подойти");
                zooPark.SelectAviary();
                Console.WriteLine($"\nВы хотите выйти из программы?Нажмите {_exitButton}.\nДля продолжение работы нажмите любую другую клавишу");

                if (Console.ReadKey().Key == _exitButton)
                {
                    Console.WriteLine("Вы вышли из программы");
                    isWork = false;
                }

                Console.Clear();
            }
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();

        public Zoo()
        {
            _aviaries.Add(new Aviary("Львы", "Лев", 5, "Рычат"));
            _aviaries.Add(new Aviary("Антилопы", "Антилопа", 3, "Цокают"));
            _aviaries.Add(new Aviary("Зебры", "Зебра", 7, "Брыгаются"));
            _aviaries.Add(new Aviary("Верблюды", "Верблюд", 9, "Харкаются"));
            _aviaries.Add(new Aviary("Бегемоты", "Бегемот", 2, "Зевают"));
            _aviaries.Add(new Aviary("Пингвины", "Пингвин", 10, "Хлопают в ладоши"));
            _aviaries.Add(new Aviary("Крокодилы", "Крокодил", 2, "Скрипят зубами"));
        }

        public void SelectAviary()
        {
            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"{i + 1} -  {_aviaries[i].Name}");
            }

            int.TryParse(Console.ReadLine(), out int numberAvary);

            if (0 < numberAvary && numberAvary - 1 < _aviaries.Count)
            {
                Console.Clear();
                _aviaries[numberAvary - 1].ShowInfo();
            }
            else
            {
                Console.WriteLine("Вывели не правильное значение вольера попробуйте заново");
            }
        }
    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();

        public Aviary(string nameAviary, string nameAnimal, int numberAnimal, string soundAnimal)
        {
            Name = nameAviary;
            NumberAnimal = numberAnimal;
            CreateAnimals(nameAnimal, soundAnimal);
        }

        public string Name { get; private set; }
        public int NumberAnimal { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Вольер - {Name}\nКоличество животных {_animals.Count}");

            for (int i = 0; i < _animals.Count; i++)
            {
                Console.WriteLine($"{_animals[i].Gender} \nЗвук - {_animals[i].Sound}\nТип животного - {_animals[i].Name}");
            }
        }

        private void CreateAnimals(string nameAnimal, string soundAnimal)
        {
            string nameGender = "Мужской пол";
            int numberGender = 2;

            for (int i = 0; i < NumberAnimal; i++)
            {
                Animal animal = new Animal(nameGender, soundAnimal, nameAnimal);
                _animals.Add(animal);

                if (NumberAnimal / numberGender <= i)
                {
                    nameGender = "Женский пол";
                }
            }
        }
    }

    class Animal
    {
        public Animal(string gender, string sound, string name)
        {
            Gender = gender;
            Sound = sound;
            Name = name;
        }

        public string Name { get; private set; }
        public string Sound { get; private set; }
        public string Gender { get; private set; }
    }
}
