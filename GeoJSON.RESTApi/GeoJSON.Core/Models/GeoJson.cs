namespace jGIS.GeoJsonApi.Core.Models
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
		
		public class Property
		{
			public string key { get; set; }
			public object value { get; set; }
		}
		
		public class PopupContent
		{
			public string popupContent { get; set; }
		}
		
	
}