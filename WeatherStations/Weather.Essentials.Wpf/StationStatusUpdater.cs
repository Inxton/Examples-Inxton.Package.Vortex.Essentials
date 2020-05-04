using HansPlc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Essentials.Wpf
{
    sealed class StationStatusUpdater
    {

        private readonly static StationStatusUpdater _instance = new StationStatusUpdater();
        public static StationStatusUpdater Get { get { return _instance;  } }

        HansPlc.fbWorldWeatherWatch Stations = Entry.HansPlc.prgWeatherStations._weatherStations;
       
        internal void WriteWeatherStationData()
        {
            foreach (structWeatherStation station in GetWeatherStations())
            {
                UpdateStationData(station);
            }
        }

        /// <summary>
        /// Updates station's data.
        /// </summary>
        /// <param name="station">Station to update.</param>
        private void UpdateStationData(structWeatherStation station)
        {
            try
            {
                // Reads Weather Data from the internet.              
                var icao = OpenWeather.MetarStationLookup.Instance.Lookup(station.StationICAO.Synchron);

                station.StationStatus.Cyclic = (short)enumStationStatus.Available;
                station.DewPoint.Cyclic = (float)icao.Weather.Dewpoint;
                station.Temp.Cyclic = (float)icao.Weather.Temperature;
                station.Pressure.Cyclic = (float)icao.Weather.Pressure;
                station.WindSpeed.Cyclic = (float)icao.Weather.WindSpeed;
                station.WindHeading.Cyclic = (ushort)icao.Weather.WindHeading;
                station.Visibility.Cyclic = (float)icao.Weather.Visibility;
            }
            catch (Exception ex)
            {
                // When online data not available we simulate the values.

                station.StationStatus.Cyclic = (short)enumStationStatus.Unknown;
                SimulateValues(station, new Random().Next());
            }
        }

        /// <summary>
        /// Simulates values when no online data are available.
        /// </summary>
        /// <param name="station">Station to update.</param>
        /// <param name="x">Randomizer.</param>
        private void SimulateValues(structWeatherStation station, float x)
        {
            station.StationStatus.Cyclic = (short)enumStationStatus.Unknown;
            station.DewPoint.Cyclic = 0;
            station.Temp.Cyclic = 0;
            station.Pressure.Cyclic = 0;
            station.WindSpeed.Cyclic = 0;
            station.WindHeading.Cyclic = 0;
            station.Visibility.Cyclic = 0;
        }

        private IEnumerable<object> GetWeatherStations()
        {
            return Stations.GetChildren().Where(p => p.GetType() == typeof(structWeatherStation));
        }
    }
}
