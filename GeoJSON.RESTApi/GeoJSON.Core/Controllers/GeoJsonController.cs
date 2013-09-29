using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Practices.Unity;
using System.Web.Http;
using jGIS.GeoJsonApi.Core.Models;

namespace GeoJSON.Core.Controllers
{
	public class GeoJsonController : ApiController
	{
		private readonly IGeoJsonRepository _flickrrepository;
		private readonly IGeoJsonRepository _geodatasetrepository;


		public GeoJsonController([Dependency("Flickr")]IGeoJsonRepository flickrrepository, [Dependency("Geodataset")] IGeoJsonRepository geodatasetrepository)
		{
			if (flickrrepository == null)
			{
				throw new ArgumentNullException("GeoRSS repository injection is null");
			}
			this._flickrrepository = flickrrepository;
			if (geodatasetrepository == null)
			{
				throw new ArgumentNullException("Geodata repository injection is null");
			}
			this._geodatasetrepository = geodatasetrepository;
		}

		public FeatureCollection GetGeodataset(string datasetname)
		{
			return _geodatasetrepository.GetAll(datasetname);
		}

		public FeatureCollection GetGeoRss(string georssurl)
		{
			return _flickrrepository.GetAll(georssurl);
		}
	}
}
