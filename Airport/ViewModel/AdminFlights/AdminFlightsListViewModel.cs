using Airport.NET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
namespace Airport
{
    public class AdminFlightsListViewModel : BaseViewModel
    {
        private readonly string filePath = "C:/Users/Public/Documents/data.json";
        protected ObservableCollection<AdminFlightsItemViewModel> mItems;
        public string Id { get; set; }
        public PlanesItemViewModel Plane { get; set; }
        public string DepartureDateTime { get; set; }
        public CitiesItemViewModel City { get; set; } = null;
        public string Passengers { get; set; }
        public ObservableCollection<AdminFlightsItemViewModel> Items
        {
            get => mItems;
            set
            {
                // Make sure list has changed
                if (mItems == value)
                    return;
                // Update value
                mItems = value;
            }
        }
        public List<CitiesItemViewModel> Cities { get; set; } = new List<CitiesItemViewModel> {
            new CitiesItemViewModel
            {
                City = "Абакан",
                Airport = "ABA",
                FlightTime = TimeSpan.Parse("04:35:00"),
                TimeZoneDifference = TimeSpan.Parse("04:00:00")
            },
            new CitiesItemViewModel
            {
                City = "Анадырь",
                Airport = "DYR",
                FlightTime = TimeSpan.Parse("05:30:00"),
                TimeZoneDifference = TimeSpan.Parse("12:00:00")
            },
            new CitiesItemViewModel
            {
                City = "Анапа",
                Airport = "AAQ",
                FlightTime = TimeSpan.Parse("02:10:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            },
            new CitiesItemViewModel
            {
                City = "Архангельск",
                Airport = "ARH",
                FlightTime = TimeSpan.Parse("03:00:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            },
            new CitiesItemViewModel
            {
                City = "Астрахань",
                Airport = "ASF",
                FlightTime = TimeSpan.Parse("01:55:00"),
                TimeZoneDifference = TimeSpan.Parse("01:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Барнаул",
                Airport = "BAX",
                FlightTime = TimeSpan.Parse("04:10:00"),
                TimeZoneDifference = TimeSpan.Parse("04:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Белгород",
                Airport = "EGO",
                FlightTime = TimeSpan.Parse("01:20:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Благовещенск",
                Airport = "BQS",
                FlightTime = TimeSpan.Parse("06:30:00"),
                TimeZoneDifference = TimeSpan.Parse("07:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Братск",
                Airport = "BTK",
                FlightTime = TimeSpan.Parse("05:05:00"),
                TimeZoneDifference = TimeSpan.Parse("05:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Брянск",
                Airport = "BZK",
                FlightTime = TimeSpan.Parse("01:10:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Варандей",
                Airport = "VRI",
                FlightTime = TimeSpan.Parse("02:10:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Владивосток",
                Airport = "VVO",
                FlightTime = TimeSpan.Parse("08:15:00"),
                TimeZoneDifference = TimeSpan.Parse("07:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Владикавказ",
                Airport = "OGZ",
                FlightTime = TimeSpan.Parse("02:25:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Волгоград",
                Airport = "VOG",
                FlightTime = TimeSpan.Parse("01:45:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Воронеж",
                Airport = "VOZ",
                FlightTime = TimeSpan.Parse("01:05:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Грозный",
                Airport = "GRV",
                FlightTime = TimeSpan.Parse("02:30:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Екатеринбург",
                Airport = "SVX",
                FlightTime = TimeSpan.Parse("02:40:00"),
                TimeZoneDifference = TimeSpan.Parse("02:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Иркутск",
                Airport = "IKT",
                FlightTime = TimeSpan.Parse("05:35:00"),
                TimeZoneDifference = TimeSpan.Parse("05:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Казань",
                Airport = "KZN",
                FlightTime = TimeSpan.Parse("01:30:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Калининград",
                Airport = "KGD",
                FlightTime = TimeSpan.Parse("00:55:00"),
                TimeZoneDifference = TimeSpan.Parse("-01:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Калуга",
                Airport = "KLF",
                FlightTime = TimeSpan.Parse("00:55:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Кемерово",
                Airport = "KEJ",
                FlightTime = TimeSpan.Parse("04:35:00"),
                TimeZoneDifference = TimeSpan.Parse("04:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Краснодар",
                Airport = "KRR",
                FlightTime = TimeSpan.Parse("01:00:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Красноярск",
                Airport = "KJA",
                FlightTime = TimeSpan.Parse("04:35:00"),
                TimeZoneDifference = TimeSpan.Parse("04:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Курган",
                Airport = "KRO",
                FlightTime = TimeSpan.Parse("02:50:00"),
                TimeZoneDifference = TimeSpan.Parse("02:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Курск",
                Airport = "URS",
                FlightTime = TimeSpan.Parse("01:15:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Липецк",
                Airport = "LPK",
                FlightTime = TimeSpan.Parse("01:05:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Магадан",
                Airport = "GDX",
                FlightTime = TimeSpan.Parse("07:20:00"),
                TimeZoneDifference = TimeSpan.Parse("08:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Магнитогорск",
                Airport = "MQF",
                FlightTime = TimeSpan.Parse("02:10:00"),
                TimeZoneDifference = TimeSpan.Parse("02:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Махачкала",
                Airport = "MCX",
                FlightTime = TimeSpan.Parse("02:20:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Минеральные Воды",
                Airport = "MRV",
                FlightTime = TimeSpan.Parse("00:55:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Мурманск",
                Airport = "MMK",
                FlightTime = TimeSpan.Parse("02:30:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Нижневартовск",
                Airport = "NJC",
                FlightTime = TimeSpan.Parse("03:25:00"),
                TimeZoneDifference = TimeSpan.Parse("02:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Нижнекамск",
                Airport = "NBC",
                FlightTime = TimeSpan.Parse("01:40:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Нижний Новгород",
                Airport = "GOJ",
                FlightTime = TimeSpan.Parse("01:05:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Новокузнецк",
                Airport = "NOZ",
                FlightTime = TimeSpan.Parse("04:15:00"),
                TimeZoneDifference = TimeSpan.Parse("04:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Новосибирск",
                Airport = "OVB",
                FlightTime = TimeSpan.Parse("03:45:00"),
                TimeZoneDifference = TimeSpan.Parse("04:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Омск",
                Airport = "OMS",
                FlightTime = TimeSpan.Parse("01:50:00"),
                TimeZoneDifference = TimeSpan.Parse("03:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Оренбург",
                Airport = "REN",
                FlightTime = TimeSpan.Parse("02:15:00"),
                TimeZoneDifference = TimeSpan.Parse("02:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Орск",
                Airport = "OSW",
                FlightTime = TimeSpan.Parse("02:30:00"),
                TimeZoneDifference = TimeSpan.Parse("02:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Пермь",
                Airport = "PEE",
                FlightTime = TimeSpan.Parse("01:55:00"),
                TimeZoneDifference = TimeSpan.Parse("02:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Петрозаводск",
                Airport = "PES",
                FlightTime = TimeSpan.Parse("01:40:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Петропавловск-Камчатский",
                Airport = "PKC",
                FlightTime = TimeSpan.Parse("08:20:00"),
                TimeZoneDifference = TimeSpan.Parse("09:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Псков",
                Airport = "PKV",
                FlightTime = TimeSpan.Parse("01:20:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Ростов-на-Дону",
                Airport = "ROV",
                FlightTime = TimeSpan.Parse("01:45:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Самара",
                Airport = "KUF",
                FlightTime = TimeSpan.Parse("01:25:00"),
                TimeZoneDifference = TimeSpan.Parse("01:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Санкт-Петербург",
                Airport = "LED",
                FlightTime = TimeSpan.Parse("01:10:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Саранск",
                Airport = "SKX",
                FlightTime = TimeSpan.Parse("01:25:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Саратов",
                Airport = "GSV",
                FlightTime = TimeSpan.Parse("01:30:00"),
                TimeZoneDifference = TimeSpan.Parse("01:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Симферополь",
                Airport = "SIP",
                FlightTime = TimeSpan.Parse("01:25:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Сочи",
                Airport = "AER",
                FlightTime = TimeSpan.Parse("01:50:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Ставрополь",
                Airport = "STW",
                FlightTime = TimeSpan.Parse("02:00:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Сургут",
                Airport = "SGC",
                FlightTime = TimeSpan.Parse("03:10:00"),
                TimeZoneDifference = TimeSpan.Parse("02:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Сыктывкар",
                Airport = "SCW",
                FlightTime = TimeSpan.Parse("01:55:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Томск",
                Airport = "TOF",
                FlightTime = TimeSpan.Parse("04:55:00"),
                TimeZoneDifference = TimeSpan.Parse("04:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Тюмень",
                Airport = "TJM",
                FlightTime = TimeSpan.Parse("02:20:00"),
                TimeZoneDifference = TimeSpan.Parse("02:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Улан-Удэ",
                Airport = "UUD",
                FlightTime = TimeSpan.Parse("05:45:00"),
                TimeZoneDifference = TimeSpan.Parse("05:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Ульяновск",
                Airport = "ULV",
                FlightTime = TimeSpan.Parse("01:30:00"),
                TimeZoneDifference = TimeSpan.Parse("01:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Уфа",
                Airport = "UFA",
                FlightTime = TimeSpan.Parse("01:50:00"),
                TimeZoneDifference = TimeSpan.Parse("02:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Хабаровск",
                Airport = "KHV",
                FlightTime = TimeSpan.Parse("07:35:00"),
                TimeZoneDifference = TimeSpan.Parse("07:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Ханты-Мансийск",
                Airport = "HMA",
                FlightTime = TimeSpan.Parse("03:15:00"),
                TimeZoneDifference = TimeSpan.Parse("02:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Чебоксары",
                Airport = "CSY",
                FlightTime = TimeSpan.Parse("01:20:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Челябинск",
                Airport = "CEK",
                FlightTime = TimeSpan.Parse("02:20:00"),
                TimeZoneDifference = TimeSpan.Parse("02:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Череповец",
                Airport = "CEE",
                FlightTime = TimeSpan.Parse("00:50:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Чита",
                Airport = "HTA",
                FlightTime = TimeSpan.Parse("06:15:00"),
                TimeZoneDifference = TimeSpan.Parse("06:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Элиста",
                Airport = "ESL",
                FlightTime = TimeSpan.Parse("01:55:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Южно-Сахалинск",
                Airport = "UUS",
                FlightTime = TimeSpan.Parse("08:10:00"),
                TimeZoneDifference = TimeSpan.Parse("08:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Якутск",
                Airport = "YKS",
                FlightTime = TimeSpan.Parse("06:20:00"),
                TimeZoneDifference = TimeSpan.Parse("06:00:00")
            } ,
            new CitiesItemViewModel
            {
                City = "Ярославль",
                Airport = "IAR",
                FlightTime = TimeSpan.Parse("00:55:00"),
                TimeZoneDifference = TimeSpan.Parse("00:00:00")
            }
        };
        public List<PlanesItemViewModel> Planes { get; set; } = new List<PlanesItemViewModel> {
            new PlanesItemViewModel
            {
                Plane = "Airbus A320",
                Id = 1,
                PlaneWithId = "Airbus A320, 1",
                MaxPassengers = 158,
            } ,
           new PlanesItemViewModel
            {
                Plane = "Airbus A320",
                Id = 20,
                PlaneWithId = "Airbus A320, 20",
                MaxPassengers = 158,
            } ,new PlanesItemViewModel
            {
                Plane = "Airbus A320",
                Id = 21,
                PlaneWithId = "Airbus A320, 21",
                MaxPassengers = 158,
            } ,new PlanesItemViewModel
            {
                Plane = "Airbus A320",
                Id = 23,
                PlaneWithId = "Airbus A320, 23",
                MaxPassengers = 158,
            } ,new PlanesItemViewModel
            {
                Plane = "Airbus A320",
                Id = 25,
                PlaneWithId = "Airbus A320, 25",
                MaxPassengers = 158,
            } ,new PlanesItemViewModel
            {
                Plane = "Airbus A320",
                Id = 24,
                PlaneWithId = "Airbus A320, 24",
                MaxPassengers = 158,
            } ,new PlanesItemViewModel
            {
                Plane = "Airbus A320",
                Id = 22,
                PlaneWithId = "Airbus A320, 22",
                MaxPassengers = 158,
            } , new PlanesItemViewModel
            {
                Plane = "Airbus A320neo",
                Id = 2,
                PlaneWithId = "Airbus A320neo, 2",
                MaxPassengers = 164,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Airbus A321neo",
                Id = 3,
                PlaneWithId = "Airbus A321neo, 3",
                MaxPassengers = 203,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Airbus A350-900",
                Id = 4,
                PlaneWithId = "Airbus A350-900, 4",
                MaxPassengers = 316,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Airbus A321",
                Id = 5,
                PlaneWithId = "Airbus A321, 5",
                MaxPassengers = 183,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Airbus A330-300",
                Id = 6,
                PlaneWithId = "Airbus A330-300, 6",
                MaxPassengers = 301,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Boeing 737-400",
                Id = 7,
                PlaneWithId = "Boeing 737-400, 7",
                MaxPassengers = 159,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Boeing 737-800",
                Id = 8,
                PlaneWithId = "Boeing 737-800, 8",
                MaxPassengers = 158,
            },
            new PlanesItemViewModel
            {
                Plane = "Boeing 767-200",
                Id = 9,
                PlaneWithId = "Boeing 767-200, 9",
                MaxPassengers = 249,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Boeing 777-300ER",
                Id = 10,
                PlaneWithId = "Boeing 777-300ER, 10",
                MaxPassengers = 402,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Embraer 170",
                Id = 11,
                PlaneWithId = "Embraer 170, 11",
                MaxPassengers = 78,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Sukhoi SuperJet 100",
                Id = 99,
                PlaneWithId = "Sukhoi SuperJet 100, 99",
                MaxPassengers = 87,
            }
        };
        public ICommand AddNewFlightCommand { get; set; }
        public ICommand DeleteChosenFlightCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public AdminFlightsListViewModel()
        {
            AddNewFlightCommand = new RelayCommand(AddNewFlight);
            DeleteChosenFlightCommand = new RelayCommand(DeleteChosenFlight);
            LogoutCommand = new RelayCommand(Logout);
            LoadData(filePath);
        }
        public void AddNewFlight()
        {
            if (string.IsNullOrEmpty(Id))
            {
                MessageBox.Show("Поле номера рейса не может быть пустым", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Id.All(c => char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Поле номера рейса может содержать только буквы или цифры", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Plane == null)
            {
                MessageBox.Show("Выберите модель самолета", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (City == null)
            {
                MessageBox.Show("Выберите город прибытия", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(DepartureDateTime))
            {
                MessageBox.Show("Поле даты отправления не может быть пустым", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!DateTime.TryParse(DepartureDateTime, out _))
            {
                MessageBox.Show("Поле даты отправления содержит некорректные данные\nПример ввода данных:\n15:00 (для сегодняшенго дня)\n29.02.20 12:00 (для установки конкретной даты)", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(DateTime.Parse(DepartureDateTime) <= DateTime.Now)
            {
                MessageBox.Show("Дата не может быть прошедшей", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Int32.TryParse(Passengers, out _))
            {
                MessageBox.Show("Поле количество пассажиров должно содержать цифры", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Int32.Parse(Passengers) > Plane.MaxPassengers || Int32.Parse(Passengers) <= 0)
            {
                MessageBox.Show("Количество пассажиров превышает вместимость самолета\n" + "Вместимость " + Plane.Plane + " - " + Plane.MaxPassengers + " пассажиров", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(Items.Any(item => (item.PlaneId.Equals(Plane.Id) && ((item.DepartureDateTime <= DateTime.Parse(DepartureDateTime) && item.ArrivalDateTime >= DateTime.Parse(DepartureDateTime)) || 
            (item.DepartureDateTime <= DateTime.Parse(DepartureDateTime).Add(City.FlightTime) && item.ArrivalDateTime >= DateTime.Parse(DepartureDateTime).Add(City.FlightTime))
            || (DateTime.Parse(DepartureDateTime) <= item.DepartureDateTime && DateTime.Parse(DepartureDateTime).Add(City.FlightTime) >= item.ArrivalDateTime)))))
            {
                MessageBox.Show("Самолет будет в полете", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Items.Any(item => (item.PlaneId.Equals(Plane.Id) && ((item.DepartureDateTime.Add(item.ArrivalDateTime - item.DepartureDateTime) <= DateTime.Parse(DepartureDateTime) && item.ArrivalDateTime.Add(item.ArrivalDateTime - item.DepartureDateTime) >= DateTime.Parse(DepartureDateTime)) ||
             (item.DepartureDateTime.Add(item.ArrivalDateTime - item.DepartureDateTime) <= DateTime.Parse(DepartureDateTime).Add(City.FlightTime) && item.ArrivalDateTime.Add(item.ArrivalDateTime - item.DepartureDateTime) >= DateTime.Parse(DepartureDateTime).Add(City.FlightTime))
             || (DateTime.Parse(DepartureDateTime) <= item.DepartureDateTime.Add(item.ArrivalDateTime - item.DepartureDateTime) && DateTime.Parse(DepartureDateTime).Add(City.FlightTime) >= item.ArrivalDateTime.Add(item.ArrivalDateTime - item.DepartureDateTime))))))
            {
                MessageBox.Show("Самолет будет в обратном полете", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Items == null)
                Items = new ObservableCollection<AdminFlightsItemViewModel>();
            var flight = new AdminFlightsItemViewModel
            {
                Id = City.City[0].ToString().ToUpper() + City.City[3].ToString().ToUpper() + Plane.Id.ToString().PadLeft(2, '0') + Id.PadLeft(4, '0'),
                Plane = Plane.Plane,
                PlaneId = Plane.Id,
                DepartureAirport = "SVO",
                DepartureCity = "Москва",
                DepartureDateTime = DateTime.Parse(DepartureDateTime),
                ArrivalAirport = City.Airport,
                ArrivalCity = City.City,
                ArrivalDateTime = DateTime.Parse(DepartureDateTime).Add(City.FlightTime + City.TimeZoneDifference),
                ArrivingToDepartureCityDateTime = DateTime.Parse(DepartureDateTime).Add(City.FlightTime).Add(City.FlightTime + TimeSpan.FromMinutes(30)),
                Passengers = Int32.Parse(Passengers),
            };
            if (Items.Any(item => item.Id.Equals(flight.Id)))
            {
                Items.Remove(Items.First(item => item.Id.Equals(flight.Id)));
                Items.Add(flight);
                UploadData(filePath);
                return;
            }
            Items.Add(flight);
            UploadData(filePath);
        }
        public void DeleteChosenFlight()
        {
            foreach (var item in Items.ToArray())
                if (item.IsChosen == true)
                    Items.Remove(item);
            UploadData(filePath);
        }
        public void Logout()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.AdminLogin);
        }
        private void LoadData(string path)
        {
            if (File.Exists(path))
            {
                Items = JsonConvert.DeserializeObject<ObservableCollection<AdminFlightsItemViewModel>>(File.ReadAllText(path));
                Items = new ObservableCollection<AdminFlightsItemViewModel>(Items.OrderBy(o => o.Id));
            }
        }
        private void UploadData(string path) => File.WriteAllText(path, JsonConvert.SerializeObject(Items));
    }
}
