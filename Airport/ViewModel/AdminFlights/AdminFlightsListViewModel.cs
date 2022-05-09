using Airport.NET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Airport
{
    public class AdminFlightsListViewModel : BaseViewModel
    {
        protected ObservableCollection<AdminFlightsItemViewModel> mItems;

        protected string filePath = "C:/Users/Public/Documents/data.json";

        public string Id { get; set; }

        public PlanesItemViewModel Plane { get; set; }

        public string DepartureDateTime { get; set; }

        public CitiesItemViewModel City { get; set; }

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
                FlightTime = TimeSpan.Parse("07:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Анадырь",
                Airport = "DYR",
                FlightTime = TimeSpan.Parse("12:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Анапа",
                Airport = "AAQ",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Архангельск",
                Airport = "ARH",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Астрахань",
                Airport = "ASF",
                FlightTime = TimeSpan.Parse("04:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Барнаул",
                Airport = "BAX",
                FlightTime = TimeSpan.Parse("07:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Белгород",
                Airport = "EGO",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Благовещенск",
                Airport = "BQS",
                FlightTime = TimeSpan.Parse("09:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Братск",
                Airport = "BTK",
                FlightTime = TimeSpan.Parse("08:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Брянск",
                Airport = "BZK",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Варандей",
                Airport = "VRI",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Владивосток",
                Airport = "VVO",
                FlightTime = TimeSpan.Parse("10:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Владикавказ",
                Airport = "OGZ",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Волгоград",
                Airport = "VOG",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Воронеж",
                Airport = "VOZ",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Грозный",
                Airport = "GRV",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Екатеринбург",
                Airport = "SVX",
                FlightTime = TimeSpan.Parse("05:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Иркутск",
                Airport = "IKT",
                FlightTime = TimeSpan.Parse("08:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Казань",
                Airport = "KZN",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Калининград",
                Airport = "KGD",
                FlightTime = TimeSpan.Parse("02:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Калуга",
                Airport = "KLF",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Кемерово",
                Airport = "KEJ",
                FlightTime = TimeSpan.Parse("07:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Краснодар",
                Airport = "KRR",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Красноярск",
                Airport = "KJA",
                FlightTime = TimeSpan.Parse("07:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Курган",
                Airport = "KRO",
                FlightTime = TimeSpan.Parse("05:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Курск",
                Airport = "URS",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Липецк",
                Airport = "LPK",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Магадан",
                Airport = "GDX",
                FlightTime = TimeSpan.Parse("11:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Магнитогорск",
                Airport = "MQF",
                FlightTime = TimeSpan.Parse("05:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Махачкала",
                Airport = "MCX",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Минеральные Воды",
                Airport = "MRV",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Мурманск",
                Airport = "MMK",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Нижневартовск",
                Airport = "NJC",
                FlightTime = TimeSpan.Parse("05:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Нижнекамск",
                Airport = "NBC",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Нижний Новгород",
                Airport = "GOJ",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Новокузнецк",
                Airport = "NOZ",
                FlightTime = TimeSpan.Parse("07:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Новосибирск",
                Airport = "OVB",
                FlightTime = TimeSpan.Parse("07:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Омск",
                Airport = "OMS",
                FlightTime = TimeSpan.Parse("06:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Оренбург",
                Airport = "REN",
                FlightTime = TimeSpan.Parse("05:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Орск",
                Airport = "OSW",
                FlightTime = TimeSpan.Parse("05:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Остафьево",
                Airport = "OSF",
                FlightTime = TimeSpan.Parse("09:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Пермь",
                Airport = "PEE",
                FlightTime = TimeSpan.Parse("05:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Петрозаводск",
                Airport = "PES",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Петропавловск-Камчатский",
                Airport = "PKC",
                FlightTime = TimeSpan.Parse("12:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Псков",
                Airport = "PKV",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Ростов-на-Дону",
                Airport = "ROV",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Самара",
                Airport = "KUF",
                FlightTime = TimeSpan.Parse("04:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Санкт-Петербург",
                Airport = "LED",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Саранск",
                Airport = "SKX",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Саратов",
                Airport = "GSV",
                FlightTime = TimeSpan.Parse("04:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Симферополь",
                Airport = "SIP",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Сочи",
                Airport = "AER",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Ставрополь",
                Airport = "STW",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Сургут",
                Airport = "SGC",
                FlightTime = TimeSpan.Parse("05:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Сыктывкар",
                Airport = "SCW",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Томск",
                Airport = "TOF",
                FlightTime = TimeSpan.Parse("07:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Тюмень",
                Airport = "TJM",
                FlightTime = TimeSpan.Parse("05:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Улан-Удэ",
                Airport = "UUD",
                FlightTime = TimeSpan.Parse("08:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Ульяновск",
                Airport = "ULV",
                FlightTime = TimeSpan.Parse("04:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Уфа",
                Airport = "UFA",
                FlightTime = TimeSpan.Parse("05:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Хабаровск",
                Airport = "KHV",
                FlightTime = TimeSpan.Parse("10:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Ханты-Мансийск",
                Airport = "HMA",
                FlightTime = TimeSpan.Parse("05:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Чебоксары",
                Airport = "CSY",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Челябинск",
                Airport = "CEK",
                FlightTime = TimeSpan.Parse("05:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Череповец",
                Airport = "CEE",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Чита",
                Airport = "HTA",
                FlightTime = TimeSpan.Parse("09:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Элиста",
                Airport = "ESL",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Южно-Сахалинск",
                Airport = "UUS",
                FlightTime = TimeSpan.Parse("03:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Якутск",
                Airport = "YKS",
                FlightTime = TimeSpan.Parse("09:00:00"),
            } ,
            new CitiesItemViewModel
            {
                City = "Ярославль",
                Airport = "IAR",
                FlightTime = TimeSpan.Parse("03:00:00"),
            }
        };
        public List<PlanesItemViewModel> Planes { get; set; } = new List<PlanesItemViewModel> {
            new PlanesItemViewModel
            {
                Plane = "Boeing 777-300ER",
                Id = 1,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Airbus А330-300",
                Id = 2,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Airbus А330-300",
                Id = 3,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Airbus А321",
                Id = 4,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Boeing 737-800",
                Id = 5,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Airbus A350-900",
                Id = 6,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Airbus A320",
                Id = 7,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Sukhoi SuperJet 100",
                Id = 8,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Embraer 170",
                Id = 9,
            },
            new PlanesItemViewModel
            {
                Plane = "Airbus A320neo",
                Id = 10,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Airbus A321neo",
                Id = 11,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Boeing 767-200",
                Id = 12,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Boeing 737-400",
                Id = 13,
            } ,
            new PlanesItemViewModel
            {
                Plane = "Boeing 777-300ER",
                Id = 14,
            }
        };

        public ICommand AddNewFlightCommand { get; set; }
        public ICommand DeleteChosenFlightCommand { get; set; }


        public AdminFlightsListViewModel()
        {
            AddNewFlightCommand = new RelayCommand(AddNewFlight);
            DeleteChosenFlightCommand = new RelayCommand(DeleteChosenFlight);

            LoadData(filePath);
        }

        public void AddNewFlight()
        {


            if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(Plane.Plane) || string.IsNullOrEmpty(City.City) || !DateTime.TryParse(DepartureDateTime, out _) || !Int32.TryParse(Passengers, out _))
            {
                MessageBox.Show("Введите корректные данные", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Items == null)
                Items = new ObservableCollection<AdminFlightsItemViewModel>();


            var flight = new AdminFlightsItemViewModel
            {
                Id = Id,
                Plane = Plane.Plane,
                PlaneId = Plane.Id,
                DepartureAirport = "SVO",
                DepartureCity = "Москва",
                DepartureDateTime = DateTimeOffset.Parse(DepartureDateTime),
                ArrivalAirport = City.Airport,
                ArrivalCity = City.City,
                ArrivalDateTime = DateTimeOffset.Parse(DepartureDateTime).Add(City.FlightTime),
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
