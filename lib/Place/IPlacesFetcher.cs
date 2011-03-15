using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Citiport.Place
{
    public interface IPlacesFetcher
    {
        List<PlaceObj> fetch(double lat, double lng);
    }
}
