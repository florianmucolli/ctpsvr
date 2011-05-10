using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Citiport.Place
{
    public class PlacesFetcherFactory
    {
        public static IPlacesFetcher getFetcher(object sender)
        {
            //return new DummyPlacesFetcherImpl() { Count = 30};
            return new FakePlacesFetcherImpl();
        }
    }
}
