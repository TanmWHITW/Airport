using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public class UserFlightsListDesignModel : UserFlightsListViewModel
    {
        public static UserFlightsListDesignModel Instance = new UserFlightsListDesignModel();

        public UserFlightsListDesignModel()
        {
            Items = new ObservableCollection<UserFlightsItemViewModel>
            {
                new UserFlightsItemViewModel()
                {
                    Id = "BON228",
                    Plane = "Boeing 777-300ER",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "12:00",

                    ArrivalCity = "Санкт-Петербург",
                    ArrivalAirport = "LED",
                    ArrivalDateTime = "14:00",

                    Passengers = 110,
                },
                new UserFlightsItemViewModel()
                {
                    Id = "DSA421",
                    Plane = "Airbus A350-900",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "11:00",

                    ArrivalCity = "Екатеринбург",
                    ArrivalAirport = "SVX",
                    ArrivalDateTime = "16:00",

                    Passengers = 154,
                },new UserFlightsItemViewModel()
                {
                    Id = "FDASF328",
                    Plane = "Airbus A321neo",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "15:40",

                    ArrivalCity = "Липецк",
                    ArrivalAirport = "LPK",
                    ArrivalDateTime = "19:00",

                    Passengers = 190,
                },new UserFlightsItemViewModel()
                {
                    Id = "BOF432",
                    Plane = "Boeing 777-300ER",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "00:00",

                    ArrivalCity = "Нижнекамск",
                    ArrivalAirport = "NBC",
                    ArrivalDateTime = "02:20",

                    Passengers = 135,
                },new UserFlightsItemViewModel()
                {
                    Id = "ARB492",
                    Plane = "Airbus А321",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "15:30",

                    ArrivalCity = "Саранск",
                    ArrivalAirport = "SKX",
                    ArrivalDateTime = "18:57",

                    Passengers = 232,
                },new UserFlightsItemViewModel()
                {
                    Id = "BOIG432",
                    Plane = "Boeing 767-200",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "09:55",

                    ArrivalCity = "Череповец",
                    ArrivalAirport = "CEE",
                    ArrivalDateTime = "11:20",

                    Passengers = 142,
                },new UserFlightsItemViewModel()
                {
                    Id = "AIR232",
                    Plane = "Airbus A350-900",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "15:40",

                    ArrivalCity = "Анапа",
                    ArrivalAirport = "AAQ",
                    ArrivalDateTime = "17:50",

                    Passengers = 253,
                },new UserFlightsItemViewModel()
                {
                    Id = "BOR533",
                    Plane = "Boeing 737-800",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "18:40",

                    ArrivalCity = "Иркутск",
                    ArrivalAirport = "IKT",
                    ArrivalDateTime = "23:55",

                    Passengers = 195,
                },new UserFlightsItemViewModel()
                {
                    Id = "SSP322",
                    Plane = "Sukhoi SuperJet 100",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "10:10",

                    ArrivalCity = "Магнитогорск",
                    ArrivalAirport = "MQF",
                    ArrivalDateTime = "14:32",

                    Passengers = 65,
                },new UserFlightsItemViewModel()
                {
                    Id = "BOE342",
                    Plane = "Boeing 767-200",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "19:00",

                    ArrivalCity = "Ростов-на-Дону",
                    ArrivalAirport = "ROV",
                    ArrivalDateTime = "22:30",

                    Passengers = 164,
                },new UserFlightsItemViewModel()
                {
                    Id = "BON348",
                    Plane = "Boeing 777-300ER",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "12:50",

                    ArrivalCity = "Архангельск",
                    ArrivalAirport = "ARH",
                    ArrivalDateTime = "14:50",

                    Passengers = 126,
                },new UserFlightsItemViewModel()
                {
                    Id = "BBD238",
                    Plane = "Boeing 737-400",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "13:00",

                    ArrivalCity = "Магадан",
                    ArrivalAirport = "GDX",
                    ArrivalDateTime = "19:50",

                    Passengers = 100,
                },new UserFlightsItemViewModel()
                {
                    Id = "BFD438",
                    Plane = "Airbus А321",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "03:00",

                    ArrivalCity = "Мурманск",
                    ArrivalAirport = "MMK",
                    ArrivalDateTime = "06:40",

                    Passengers = 169,
                },
            };
        }
    }
}
