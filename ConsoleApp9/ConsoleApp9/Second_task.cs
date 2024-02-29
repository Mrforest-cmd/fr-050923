using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public string Brand { get; set; }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnStatusChanged();
                }
            }
        }

        public event EventHandler StatusChanged;

        protected virtual void OnStatusChanged()
        {
            StatusChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public class VehicleMonitor
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            vehicle.StatusChanged += Vehicle_StatusChanged;
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            Console.WriteLine($"Removing vehicle {vehicle.RegistrationNumber} from the monitor...");
            vehicles.Remove(vehicle);
            vehicle.StatusChanged -= Vehicle_StatusChanged;
        }

        public void DisplayVehicles()
        {
            Console.WriteLine("Vehicles:");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"- {vehicle.Brand} ({vehicle.RegistrationNumber}): {vehicle.Status}");
            }
        }

        public void DisableVehicle(Vehicle vehicle)
        {
            Console.WriteLine($"Changing status of vehicle {vehicle.RegistrationNumber} to Stopped...");
            vehicle.Status = "Stopped";
        }

        private void Vehicle_StatusChanged(object sender, EventArgs e)
        {
            Vehicle vehicle = (Vehicle)sender;
            Console.WriteLine($"Status changed for vehicle {vehicle.Brand} ({vehicle.RegistrationNumber}): {vehicle.Status}");

            if (vehicle.Status == "Stopped")
            {
                Console.WriteLine($"Sending notification to the owner of vehicle {vehicle.Brand} ({vehicle.RegistrationNumber})");
            }
        }
    }
    class Second_task
    {
        static void Main2(string[] args)
        {
            VehicleMonitor monitor = new VehicleMonitor();

            Vehicle vehicle1 = new Vehicle { RegistrationNumber = "ABC123", Brand = "Toyota", Status = "Running" };
            Vehicle vehicle2 = new Vehicle { RegistrationNumber = "DEF456", Brand = "Ford", Status = "Running" };

            monitor.AddVehicle(vehicle1);
            monitor.AddVehicle(vehicle2);

            monitor.DisplayVehicles();

            monitor.DisableVehicle(vehicle1);

            monitor.DisplayVehicles();

            monitor.RemoveVehicle(vehicle2);

            monitor.DisplayVehicles();
        }
    }
}
/*
 №5
Опис:
Створіть консольну програму, яка моделює систему автоматизованого моніторингу за станом транспортних засобів, використовуючи делегати для обробки подій.

Вимоги:
Створення структури даних:
Створіть клас Vehicle з полями для номеру автомобіля, марки та статусу (наприклад, "у русі" або "припинено").
Створіть клас VehicleMonitor, який буде містити список транспортних засобів та базові операції з ними (додавання, видалення, виведення на екран).

Створення делегатів:
Створіть делегат VehicleStatusChangeHandler, який приймає об'єкт класу Vehicle.
Створіть два методи, що відповідають сигнатурі делегата: один для виведення повідомлення про зміну статусу транспортного засобу,
інший - для відправлення сповіщення власникові транспортного засобу, якщо статус змінився на "припинено".

Обробка подій:
В класі VehicleMonitor створіть подію VehicleStatusChanged, яка буде викликатися при зміні статусу транспортного засобу.
Додайте метод OnVehicleStatusChanged, який буде викликати подію VehicleStatusChanged та передавати в неї транспортний засіб, статус якого змінився.

Використання делегатів:
Створіть об'єкт класу VehicleMonitor.
Створіть делегат та підпишіть його на метод виведення повідомлення про зміну статусу транспортного засобу.
Додайте кілька транспортних засобів до монітора та спостерігайте за виведенням повідомлень при зміні їхнього статусу.

Додаткова функціональність:
Реалізуйте можливість видалення транспортних засобів з монітора та виклику відповідних подій.
Додайте можливість зміни статусу транспортного засобу та виклику подій при такій зміні.

Критерії успішності:
Програма повинна коректно обробляти введені дані та виводити повідомлення про події.
Використання делегатів для виклику методів обробки подій.
Чітко визначені операції зі списком транспортних засобів та їх реалізація.

Додаткові вказівки:
Заохочуйте студентів експериментувати з іншими операціями та використанням делегатів для розширення функціоналу.
Пропонуйте використовувати делегати для відправлення сповіщень власникам транспортних засобів.
 */
