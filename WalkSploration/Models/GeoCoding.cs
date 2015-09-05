using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml;
using System.Net;

namespace WalkSploration.Models
{
    public class GeoCoding
    {
        public enum AccurateToTypes: int
        {
            Unknown = 0,
            Country = 1,
            Region = 2,
            SubRegion = 3,
            Town = 4,
            PostCode = 5,
            Street = 6,
            Intersection = 7,
            Address = 8,
            Premesises = 9
        }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        
        private AccurateToTypes _latLngAccuracy = 0;
        public AccurateToTypes LatLngAccuracy
        {
            get { return _latLngAccuracy; }
        }

        public void GeoCode()
        {
            StreamReader sr = null;

            //Key
            //Check to see if the map key exists
            if (string.IsNullOrEmpty(mapskey))
            {
                throw new Exception("No valid Google Maps API key to use for geocoding.");
            }
            //Create the url string to send our request to google.
            var url = string.Format("http://maps.google.com/maps/geo={0}+{1}+{2}+{3}+{4}&output=xml&oe=utf8&sensor=false&key={5}", Address1, City + ", ", State, Zip, Country, mapskey);

            // Create a web request client.
            var webclient = new WebClient();

            try
            {
                // retrieve result and put it in the streamreader
                sr = new StreamReader(WebClient.OpenRead(url));
            }
            catch (Exception ex)
            {
                // This is where we can assume they are evil?
                throw new Exception("the error was: " + ex.Message);
            }

            try
            {
                var xmlTextReader = new XmlTextReader(sr);

                var coordinateRead = false;
                var accread = false;

                // Start reading the xml document.
                while (xmlTextReader.Read())
                {
                    xmlTextReader.MoveToElement();
                    switch (xmlTextReader.Name)
                    {
                        case "AddressDetails:": //Check for the address details node
                            while (xmlTextReader.MoveToNextAttribute())
                            {
                                switch(xmlTextReader.Name)
                                {
                                    case "Accuracy":
                                        if (!accread)
                                        {
                                            // get the accuracy, convert it to our enum and save it
                                            this._latLngAccuracy = (AccurateToTypes)Convert.ToInt32(xmlTextReader.Value);
                                            accread = true;
                                        }
                                        break;
                                }
                            }
                            break;
                        case "coordinates": // The coordinates element
                            if (!coordinateRead)
                            {
                                // move the element value
                                xmlTextReader.Read();

                                // split the coords and then...
                                string[] coordinates = xmlTextReader.Value.Split(new char[] { ',' });

                                // save the vales
                                Longitude = coordinates[0];
                                Latitude = coordinates[1];

                                // after the reader is done, we don't want to process again on the same file.
                                coordinateRead = true;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            { throw new Exception("error was: " + ex.Message);
            }
        }
    }
}