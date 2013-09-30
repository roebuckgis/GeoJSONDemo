using System;
using Microsoft.Practices.Unity;
using System.Web.Http;
using jGIS.GeoJsonApi.Core.Models;

namespace jGIS.GeoJsonApi.Core.Controllers
{
	public class GeoJsonController : ApiController
	{
		private readonly IGeoJsonRepository _georssrepository;
		private readonly IGeoJsonRepository _geodatasetrepository;


		public GeoJsonController([Dependency("GeoRss")]IGeoJsonRepository georssrepository, [Dependency("Geodataset")] IGeoJsonRepository geodatasetrepository)
		{
			if (georssrepository == null)
			{
				throw new ArgumentNullException("GeoRSS repository injection is null");
			}
			_georssrepository = georssrepository;
			if (geodatasetrepository == null)
			{
				throw new ArgumentNullException("Geodata repository injection is null");
			}
			_geodatasetrepository = geodatasetrepository;
		}

		public FeatureCollection GetGeodataset(string datasetname)
		{
			return _geodatasetrepository.GetAll(datasetname);
		}

		public FeatureCollection GetGeoRss(string georssurl)
		{
			return _georssrepository.GetAll(georssurl);
		}

		public FeatureCollection GetIntersecting(string focuslayer, string overlaylayer)
		{
			return _geodatasetrepository.GetIntersecting(focuslayer, overlaylayer);
		}

	}
}
