using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoJSON.RESTApi.Models
{
	public class GeoJSON
	{
		public class FeatureCollection
		{
			public string type { get { return GetType().Name; } }
			public Feature[] features { get; set; }
		}

		public class Feature
		{
			public string type { get { return GetType().Name; } }
			public Geometry geometry { get; set; }
			public object properties { get; set; }
		}

		public class Geometry
		{
			public string type { get; set; }
			public object coordinates { get; set; }
		}

		public class InfoBoxItems
		{
			public InfoBoxItem[] infoBoxItems { get; set; }
		}
		public class InfoBoxItem
		{
			public string type { get; set; }
			public string value { get; set; }
		}
	}
}