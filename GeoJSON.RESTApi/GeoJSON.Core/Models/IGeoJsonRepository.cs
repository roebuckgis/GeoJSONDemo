namespace jGIS.GeoJsonApi.Core.Models
{
	public interface IGeoJsonRepository
	{
		FeatureCollection GetAll();
		FeatureCollection GetAll(string identifier);
		FeatureCollection GetIntersecting(Geometry geometry);
		Feature Get(int id);
		FeatureCollection Query(string parameters);
		Feature Add(FeatureCollection item);
		void Remove(int id);
		bool Update(FeatureCollection item);
	}
}
